import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarClienteComponent } from './cadastrar-cliente/cadastrar-cliente.component';
import { HomeComponent } from './home/home.component';
import { ListarClienteComponent } from './listar-cliente/listar-cliente.component';

const routes: Routes = [
  { path: 'cadastrar', component: CadastrarClienteComponent },
  { path: 'listar', component: ListarClienteComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
