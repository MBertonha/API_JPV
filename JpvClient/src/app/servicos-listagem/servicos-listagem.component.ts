import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PoTableAction, PoTableColumn } from '@po-ui/ng-components';
import { routing } from '../app.routing';
import { OrdemServicoService } from '../Services/ordem-servico.service';
import { ResponseApi } from '../Utilitarios/RetornoApiDto';
import { delay} from "rxjs/operators";

@Component({
  selector: 'app-servicos-listagem',
  templateUrl: './servicos-listagem.component.html',
  styleUrls: ['./servicos-listagem.component.css']
})
export class ServicosListagemComponent implements OnInit {

  listaServicos: Array<ResponseApi>;
  public itens: Array<any> = [];

  readonly colunas: Array<PoTableColumn> = this.service.colunas;
  readonly titulo = "Usuários";
  public dados: ResponseApi = {SeqUsuario : 0, ValorRenda: 0, Cpf: '', Nome: '', DtaNascimento: null };

  actions: Array<PoTableAction> = [
    { action: this.alterar.bind(this), label: 'Editar', icon: 'po-icon po-icon-edit'},
    { action: this.remove.bind(this), label: 'Excluir', icon: 'po-icon po-icon-delete' }
  ];

  constructor(private service: OrdemServicoService, private router: Router, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.router.navigate(['/listar']);
    this.listar();
  }

  listar(){
    this.service.listar().subscribe(dados => {
      this.itens = dados.items;
      return null;
    });
  }

  onClick() {
  }

  alterar(item){
    this.dados.SeqUsuario = item.seqUsuario;
    this.dados.Cpf = item.cpf;
    this.dados.Nome = item.nome;
    this.dados.DtaNascimento = item.dtaNascimento;
    this.dados.ValorRenda = item.valorRenda;
 
    this.service.setDados(this.dados);

    this.router.navigate(['/alterar']);
  }

  remove(item) {
    this.service.excluir(item.seqUsuario).subscribe(dados => {});
    delay(10000000);
    this.reloadComponent();
  }

  reloadComponent() {
        let currentUrl = this.router.url;
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate([currentUrl]);
    }
}
