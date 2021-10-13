import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Cliente } from "../Models/Cliente";

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly baseURL = environment["endPoint"];
    
  cadastrar(cliente: Cliente) {
    debugger
    return this.http.post(`${this.baseURL}Cliente/criar`, cliente);
  }
}
