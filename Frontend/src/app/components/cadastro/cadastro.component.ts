import {Component, OnInit} from '@angular/core';
import {Cliente} from "../../models/Cliente";
import {Regiao} from "../../models/Regiao";
import {ClienteService} from "../../services/cliente.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {LoginService} from "../../services/login.service";
import {CepService} from "../../services/cep.service";
import { Endereco } from 'src/app/models/Endereco';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit{
  form!: FormGroup;

  constructor(private clienteService: ClienteService,
              private loginService: LoginService,
              private router: Router,
              private cep: CepService,
              private formBuilder: FormBuilder) { }

  get debug() {
    return this.form.invalid;
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      cpf: ["", Validators.required],
      nome: ["", Validators.required],
      telefone: ["", Validators.required],
      endereco: this.formBuilder.group({
        rua: ["", Validators.required],
        numero: ["", Validators.required],
        cep: ["", Validators.required],
        complemento: ["", Validators.required],
        regiao: this.formBuilder.group({
          nome: [""]
        })
      })
    });
  }

  buscarCEP() {
    const cep = this.form.get("endereco.cep")?.value;

    this.cep.buscarCep(cep).subscribe({
      next : res => {
        const { logradouro, bairro} = res;

        if (!logradouro) {
          alert("CEP não encontrado");
          return;
        }

        this.form.get("endereco.rua")?.setValue(logradouro);
        this.form.get("endereco.regiao.nome")?.setValue(bairro);
      },
      error: () => {
        alert("CEP inválido");
      }
    });
  }

  cadastrarCliente() {
    const cliente: Cliente = this.form.value;

    if (!this.cadastroEstaValido()) return;

    this.clienteService.cadastrar(cliente).subscribe({
      next: clienteCriado => {
        alert("Cliente cadastrado com sucesso");

        this.loginService.salvarClienteLogado(clienteCriado)
        this.router.navigateByUrl("/home/area-cliente").then();
      },
      error: err => console.log(err)
    });
  }

  cadastroEstaValido(): boolean {
    if (this.form.invalid) {
      alert("Todos os campos devem ser preenchidos");
    }

    return true;
  }
}
