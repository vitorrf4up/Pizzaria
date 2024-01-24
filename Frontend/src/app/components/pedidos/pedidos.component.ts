import { Component, OnInit } from '@angular/core';
import {PedidoFinal} from "../../models/PedidoFinal";
import {ClienteService} from "../../services/cliente.service";
import {LoginService} from "../../services/login.service";
import {PizzaPedido} from "../../models/PizzaPedido";
import {AcompanhamentoPedido} from "../../models/AcompanhamentoPedido";
import { Observable } from 'rxjs';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  pedidos$!: Observable<PedidoFinal[]>;
  pedidos: PedidoFinal[] = [];

  constructor(private clienteService: ClienteService,
              private loginService: LoginService) { }

  ngOnInit() {
    const cpf = this.loginService.getClienteLogado().cpf;

    this.pedidos$ = this.clienteService.listarPedidosPorCliente(cpf);
    // FIX: being called twice
    this.pedidos$.subscribe(resposta => {
      this.pedidos = resposta;
      this.pedidos.sort((a, b) => b.id - a.id);
    });
  }

  getDescricaoPizza(pizza: PizzaPedido): string {
    pizza = new PizzaPedido(pizza.sabores, pizza.tamanho, pizza.quantidade);
    return pizza.getDescricao();
  }

  getDescricaoAcompanhamento(acomp : AcompanhamentoPedido): string {
    acomp = new AcompanhamentoPedido(acomp.acompanhamento, acomp.quantidade);
    return acomp.getDescricao();
  }
}
