import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from "./components/cliente/cliente.component";
import { AcompanhamentoComponent } from "./components/acompanhamento/acompanhamento.component";
import { PizzasComponent } from "./components/pizzas/pizzas.component";
import { CadastroComponent } from "./components/cadastro/cadastro.component";
import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";
import { CarrinhoComponent } from "./components/carrinho/carrinho.component";
import {InicioComponent} from "./components/inicio/inicio.component";

const routes: Routes = [
  { path: "", component: InicioComponent,
    children : [
      { path: "login", component: LoginComponent },
      { path: "cadastro", component: CadastroComponent },
    ]},
  { path: "home", component: HomeComponent,
    children: [
      { path: "clientes", component: ClienteComponent },
      { path: "acompanhamentos", component: AcompanhamentoComponent },
      { path: "sabores", component: PizzasComponent },
      { path: "carrinho", component: CarrinhoComponent },
    ]},
  { path: "**", component: LoginComponent } // Rota padrão para tratamento de rotas não reconhecidas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
