import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, MinLengthValidator, Validators } from '@angular/forms';
import { Cliente } from '../Models/Cliente';
import { Email } from '../Models/Email';
import { Telefone } from '../Models/Telefone';
import { ClienteService } from '../Services/cliente.service';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html',
  styleUrls: ['./cadastrar-cliente.component.scss']
})
export class CadastrarClienteComponent implements OnInit {

  clienteForm: FormGroup;

  podeCadastrar: boolean = false;

  mostrarErros: boolean = false;

  MensagemErro: string = '';

  constructor(
    private fb: FormBuilder,
    private clienteService: ClienteService
    ) {
      this.clienteForm = new FormGroup({
        'razaoSocial': new FormControl(null, [Validators.required, Validators.minLength(6)]),
        'cnpj': new FormControl(null, [Validators.required, Validators.minLength(14)]),
        'telefones': new FormArray([]),
        'emails': new FormArray([]),
        'endereco': new FormControl(null, [Validators.required, Validators.minLength(5)]),
      })
  }

  ngOnInit(): void {
    
  }

  telefoneControl() {
    return <FormArray>this.clienteForm.get('telefones');
  }

  emailControl() {
    return <FormArray>this.clienteForm.get('emails');
  }

  cadastrarCliente() {
    this.validadorCadastro();
    console.log(this.podeCadastrar)

    if(!this.podeCadastrar){
      return true;
    }

    var cadastro = this.clienteForm.getRawValue();

    //adaptação do objeto
    let cliente: Cliente = {
      CNPJ: cadastro.cnpj,
      Endereco: cadastro.endereco,
      RazaoSocial: cadastro.razaoSocial,
      Emails: [] ,
      Telefones: [] ,
    };

    for(let email of cadastro.emails){
      let cadastroEmail: Email = {
        EmailCliente: email
      }
      cliente.Emails.push(cadastroEmail)
    }

    for(let telefone of cadastro.telefones){
      let cadastroTelefone: Telefone = {
        TelefoneCliente: telefone
      }
      cliente.Telefones.push(cadastroTelefone)
    }

    console.log(cliente)


    this.clienteService.cadastrar(cliente)
      .subscribe(
        data => {
          console.log(data, "retorno")
        })
    return alert("Cadastro criado com sucesso")
  }
  
  adicionarTelefone() {
    const control = new FormControl(null, [Validators.required, Validators.min(1000000000), Validators.max(999999999999)]);
    (<FormArray>this.clienteForm.get('telefones')).push(control);
  }

  adicionarEmail() {
    const control = new FormControl(null, [Validators.required, Validators.email]);
    (<FormArray>this.clienteForm.get('emails')).push(control);
  }

  deletar(index: number) {
   
  }

  validadorCadastro() {
    this.MensagemErro = '';
    this.mostrarErros = true;


    if((<FormArray>this.clienteForm.get('telefones')).length > 0 &&
    (<FormArray>this.clienteForm.get('telefones')).valid &&
    (<FormArray>this.clienteForm.get('emails')).length > 0 &&
    (<FormArray>this.clienteForm.get('emails')).valid &&
    this.clienteForm.valid){
      this.podeCadastrar = true;
      this.mostrarErros = false;
    }

    if(!((<FormArray>this.clienteForm.get('telefones')).length > 0 &&
    (<FormArray>this.clienteForm.get('telefones')).valid)){
      this.MensagemErro += "*Insira pelo menos um telefone válido. "
    }

    if(!((<FormArray>this.clienteForm.get('emails')).length > 0 &&
    (<FormArray>this.clienteForm.get('emails')).valid)){
      this.MensagemErro += "*Insira pelo menos um email válido. "
    }
  }

}
