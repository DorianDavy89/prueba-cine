import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogRef } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";

@Component({
  selector: 'app-registrar-peliculas',
  templateUrl: './registrarpeliculas.component.html',
  styleUrls: ['./registrarpeliculas.component.css'],
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatSelectModule, MatIconModule, MatButtonModule]
})

export class RegistrarPeliculasComponent {

  constructor(private dialogRef: MatDialogRef<RegistrarPeliculasComponent>
  ) { }
}
