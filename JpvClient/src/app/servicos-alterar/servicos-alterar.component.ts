import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PoNotificationService } from '@po-ui/ng-components';
import { cnpj, cpf } from 'cpf-cnpj-validator';
import { OrdemServicoService } from '../Services/ordem-servico.service';
import { ResponseApi } from '../Utilitarios/RetornoApiDto';

@Component({
  selector: 'app-servicos-alterar',
  templateUrl: './servicos-alterar.component.html',
  styleUrls: ['./servicos-alterar.component.css']
})
export class ServicosAlterarComponent implements OnInit {

  readonly titulo = "Alterar usuário";
  formulario: FormGroup;
  dataMinimaIni: string;
  public itens: ResponseApi;

  constructor(private formBuilder: FormBuilder, 
    private router: Router,
    private service: OrdemServicoService, 
    private poNotification: PoNotificationService) { }

  ngOnInit(): void {
    
    this.itens = this.service.getDados();

    this.formulario = this.formBuilder.group({
      seqUsuario: this.itens.SeqUsuario,
      valorRenda: this.itens.ValorRenda,
      dtaNascimento: new Date(this.itens.DtaNascimento),
      nome: this.itens.Nome,
      cpf: this.itens.Cpf
    })
    this.dataMinimaIni = <any>new Date();
  }

  alterar(){
    this.verificaCampos();
    let op = this.validarCpfECnpj();
    let seq = this.itens.SeqUsuario;

    this.service.alterarProduto(this.formulario.value, op, seq);

    if(op == "1"){
      this.formulario.patchValue({
        cnpjCliente: null
      });
    }
    else if(op == "2"){
      this.formulario.patchValue({
        cpfPrestador: null
      });
    }

    this.router.navigate(['/listar']);
  }

  verificaCampos(){
    if(this.formulario.controls["valorRenda"].value == ""){
      this.formulario.controls["valorRenda"].markAsDirty();
      return this.poNotification.warning("Valor deve ser obrigatório");
    }
    if(this.formulario.controls["dtaNascimento"].value == null || this.formulario.controls["dtaNascimento"].value == ''){
      this.formulario.controls["dtaNascimento"].markAsDirty();
      return this.poNotification.warning("Data deve ser obrigatória");
    }
    if(this.formulario.controls["nome"].value == ""){
      this.formulario.controls["nome"].markAsDirty();
      return this.poNotification.warning("Nome do cliente deve ser obrigatório");
    }
    if(this.formulario.controls["cpf"].value == ""){
      this.formulario.controls["cpf"].markAsDirty();
      return this.poNotification.warning("CPF deve ser obrigatório");
    }
  }

  validarCpfECnpj(): string{
    let op = "0";
    const cpfForm = this.formulario.controls["cpf"].value;
    const cnpjForm = this.formulario.controls["cpf"].value;
    if(!cpf.isValid(cpfForm)){
      op = "2";
    };
    if(!cnpj.isValid(cnpjForm)){
      op = "1";
    }
    return op;
  }

}
