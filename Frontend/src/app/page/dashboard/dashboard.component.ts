import { Component } from "@angular/core";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
import { MatCardModule } from "@angular/material/card";
import { Router } from "@angular/router";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  imports: [
    MatSidenavModule,
    MatListModule,
    MatCardModule
  ],
})
export class DashboardComponent {

  totalSalas = 8;
  salasDisponibles = 3;
  totalPeliculas = 12;
  constructor(
    private router: Router
  ) { }

  navegarpelicula(): void {
      this.router.navigate(['/pelicula']);

  }

  navegarsalas() {
    this.router.navigate(['/salas']);
}

}


