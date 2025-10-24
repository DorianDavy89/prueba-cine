import { Routes } from '@angular/router';
import { LoginComponent } from './page/login/login.component';
import { DashboardComponent } from './page/dashboard/dashboard.component';
import { PeliculasComponent } from './page/peliculas/peliculas.component';
import { SalasComponent } from './page/salas/salas.component';

export const routes: Routes = [

  {
    path: '',
    component: LoginComponent,
  },

  {
    path: 'dashboard',
    component: DashboardComponent,
  },

  {
    path: 'pelicula',
    component: PeliculasComponent,
  },

  {
    path: 'salas',
    component: SalasComponent,
  }


];
