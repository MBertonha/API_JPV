import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServicosListagemComponent } from './servicos-listagem/servicos-listagem.component';
import { OrdemServicoService } from './Services/ordem-servico.service';
import { PoModule } from '@po-ui/ng-components';
import { ServicosInserirComponent } from './servicos-inserir/servicos-inserir.component';
import { routing } from './app.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServicosAlterarComponent } from './servicos-alterar/servicos-alterar.component';
import { IndexComponent } from './index/index.component';

@NgModule({
  declarations: [
    AppComponent,
    ServicosListagemComponent,
    ServicosInserirComponent,
    ServicosAlterarComponent,
    IndexComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    PoModule,
    ReactiveFormsModule,
    routing
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [OrdemServicoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
