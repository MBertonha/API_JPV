import { ModuleWithProviders } from "@angular/compiler/src/core";
import { RouterModule, Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { ServicosAlterarComponent } from "./servicos-alterar/servicos-alterar.component";
import { ServicosInserirComponent } from "./servicos-inserir/servicos-inserir.component";
import { ServicosListagemComponent } from "./servicos-listagem/servicos-listagem.component";

const APP_ROUTES: Routes = [
    { path: 'listar', component: ServicosListagemComponent},
    { path: 'inserir', component: ServicosInserirComponent},
    { path: 'alterar', component: ServicosAlterarComponent},
    { path: '', component: IndexComponent}
]

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES); 