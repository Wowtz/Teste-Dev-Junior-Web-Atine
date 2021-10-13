import { Email } from './Email'
import { Telefone } from './Telefone'

export interface Cliente  {
  RazaoSocial: string;
  CNPJ: string;
  Telefones: Telefone[];
  Emails: Email[];
  Endereco: string;
}