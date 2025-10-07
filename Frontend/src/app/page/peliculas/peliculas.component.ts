import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialog } from "@angular/material/dialog";
import { MatDividerModule } from "@angular/material/divider";
import { MatLabel, MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInput } from "@angular/material/input";
import { MatTableModule } from "@angular/material/table";
import { MatTooltipModule } from "@angular/material/tooltip";
import { Router, RouterModule } from "@angular/router";
import { RegistrarPeliculasComponent } from "./registrar/registrarpeliculas.component";

@Component({
  selector: 'btnnuevo',
  templateUrl: './peliculas.component.html',
  styleUrls: ['./peliculas.component.css'],
  standalone: true,
  imports: [MatButtonModule,
    MatDividerModule, MatIconModule, MatTableModule, RouterModule,
    MatInput, MatLabel, MatFormFieldModule, FormsModule, MatTooltipModule],
})

export class PeliculasComponent {
  columnas: string[] = ['nombre', 'duracion','ACCIONES'];

  peliculas = [
    { nombre: 'Inception', duracion: '148' },
    { nombre: 'Interstellar', duracion: '169' },
    { nombre: 'El Origen', duracion: '120' },
    { nombre: 'Matrix', duracion: '136' },
  ];

  constructor(private router: Router, private dialog: MatDialog) { }

  regresar(): void {
      this.router.navigate(['/dashboard']);

  }

  abrirFormularioRegistro(): void {
    const dialogRef = this.dialog.open(RegistrarPeliculasComponent, {
      disableClose: false,
    });
  }
}
