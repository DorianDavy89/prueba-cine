import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDividerModule } from "@angular/material/divider";
import { MatLabel, MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInput } from "@angular/material/input";
import { MatTableModule } from "@angular/material/table";
import { MatTooltipModule } from "@angular/material/tooltip";
import { Router, RouterModule } from "@angular/router";

@Component({
  selector: 'btnnuevo',
  templateUrl: './salas.component.html',
  styleUrls: ['./salas.component.css'],
  standalone: true,
  imports: [MatButtonModule,
    MatDividerModule, MatIconModule, MatTableModule, RouterModule,
    MatInput, MatLabel, MatFormFieldModule, FormsModule, MatTooltipModule],
})

export class SalasComponent {
  columnas: string[] = ['nombre', 'disponibilidad','ACCIONES'];

  salas = [
    { nombre: 'Sala HD+', disponibilidad: 'Disponible' },
    { nombre: 'Sala 2k', disponibilidad: 'Disponible' },
    { nombre: 'Sala 4k', disponibilidad: 'Ocupado' },
    { nombre: 'Sala VIP', disponibilidad: 'Ocupado' },
  ];

  constructor(private router: Router) { }

  regresar(): void {
      this.router.navigate(['/dashboard']);

  }
}
