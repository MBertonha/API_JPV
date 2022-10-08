import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PoModalComponent, PoNotificationService } from '@po-ui/ng-components';
import { OrdemServicoService } from '../Services/ordem-servico.service';
import { cpf, cnpj } from 'cpf-cnpj-validator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servicos-inserir',
  templateUrl: './servicos-inserir.component.html',
  styleUrls: ['./servicos-inserir.component.css']
})
export class ServicosInserirComponent implements OnInit {

  @ViewChild(PoModalComponent, { static: true }) modalCadastro: PoModalComponent;
  
  readonly titulo = "Cadastrar usuário";
  formulario: FormGroup;
  dataMinimaIni: string;

  constructor(private formBuilder: FormBuilder,
    private router: Router, 
    private service: OrdemServicoService, 
    private poNotification: PoNotificationService) { }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      valorRenda: [''],
      dtaNascimento: [''],
      nome: [''],
      cpf: ['']
    })

    this.dataMinimaIni = <any>new Date();
  }

  cadastrar(){    
    this.verificaCampos();
    let op = this.validarCpfECnpj();
    this.service.adicionarProduto(this.formulario.value, op);

    if(op == "0"){
      this.formulario.reset();
    }
    else if(op == "1"){
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
    if(this.formulario.controls["dtaNascimento"].value == ""){
      this.formulario.controls["dtaNascimento"].markAsDirty();
      return this.poNotification.warning("Data deve ser obrigatória");
    }
    if(this.formulario.controls["nome"].value == ""){
      this.formulario.controls["nome"].markAsDirty();
      return this.poNotification.warning("Nome deve ser obrigatório");
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
