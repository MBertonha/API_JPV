import { Injectable, ViewChild } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { ResponseApi } from '../Utilitarios/RetornoApiDto';
import { PoModalComponent, PoNotificationService, PoTableColumn } from '@po-ui/ng-components';
import { ServicosInserirComponent } from '../servicos-inserir/servicos-inserir.component';

@Injectable({
  providedIn: 'root'
})
export class OrdemServicoService {

  public itensServico: ResponseApi;
  apiUrl = 'https://localhost:44368/api/v1/Jpv';

  get colunas(): Array<PoTableColumn> {
    return [
      { property: 'seqUsuario', label: 'Código' },
      { property: 'nome', label: 'Cliente' },
      { property: 'cpf', label: 'CPF' },
      { property: 'valorRenda', label: 'Valor'},
      { property: 'dtaNascimento', label: 'Data',type: 'dateTime', format: "dd/MM/yyyy"}
    ];
  }

  constructor(private http: HttpClient, private poNotification: PoNotificationService) { }

  listar(){
    return this.http.get<any>(`${this.apiUrl}`);
  }
  listarComFiltro(seq){
    return this.http.get<any>(`${this.apiUrl}?SeqOS=${seq}`);
  }
  excluir(id){
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }

  adicionarProduto(json, op) {
    this.http.post(`${ this.apiUrl }/`, json)
              .subscribe(
                resultado => {
                  this.poNotification.success("Usuário cadastrado com sucesso!");
                },
                erro => {
                  if(erro.status == 400) {
                    if(op == "1"){
                      this.poNotification.warning("Erro usuário, verifique se o CNPJ está válido ou nulo");
                    }else if(op == "2"){
                      this.poNotification.warning("Erro usuário, verifique se o CPF está válido ou nulo");
                    }else{
                      this.poNotification.warning("Erro usuário.");
                    }
                  }
                  if(erro.status == 500) {
                    this.poNotification.warning("Ocorreu algum erro ao se comunicar com a API");
                  }
                }
              );
  }

  alterarProduto(json, op, seq){
    this.http.put(`${ this.apiUrl }/${seq}`, json)
    .subscribe(
      resultado => {
        this.poNotification.success("Ordem atualizada com sucesso!");
      },
      erro => {
        if(erro.status == 400) {
          if(op == "1"){
            this.poNotification.warning("Erro ao atualizar usuário, verifique se o CNPJ está válido ou nulo");
          }else if(op == "2"){
            this.poNotification.warning("Erro ao atualizar usuário, verifique se o CPF está válido ou nulo");
          }else{
            this.poNotification.warning("Erro ao atualizar usuário.");
          }
        }
        if(erro.status == 500) {
          this.poNotification.warning("Ocorreu algum erro ao se comunicar com a API");
        }
      }
    );
  }

  getDados(){
    return this.itensServico;
  }

  setDados(item){
    this.itensServico = item;
  }
}
