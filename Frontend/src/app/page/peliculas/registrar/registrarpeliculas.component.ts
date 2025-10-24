import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogRef } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import Swal from "sweetalert2";
import { RegistrarPelicula } from "../../../interface/Pelicula/interface.registrar.pelicula";
import { PeliculaService } from "../../../services/Pelicula/peliculas.service";

@Component({
  selector: 'app-registrar-peliculas',
  templateUrl: './registrarpeliculas.component.html',
  styleUrls: ['./registrarpeliculas.component.css'],
  standalone: true,
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatSelectModule, MatIconModule, MatButtonModule]
})

export class RegistrarPeliculasComponent {

  nombre: string = '';
  duracion: number = 0;

  constructor(private dialogRef: MatDialogRef<RegistrarPeliculasComponent>,
    private peliculaservices: PeliculaService
  ) { }

  registrarPelicula(): void {

    if (!this.camposValidos()) {
      this.mensajeAdvertencia('Campos incompletos', 'Por favor llena todos los campos');
      return;
    }

    const nuevaPelicula: RegistrarPelicula = {
      nombre: this.nombre.trim(),
      duracion: this.duracion,
    };


    this.peliculaservices.registrarPelicula(nuevaPelicula).subscribe({
      next: () => {
        this.mensajeExito('Pelicula registrada', `Pelicula ${nuevaPelicula.nombre} fue creado correctamente`, true);
      },
      error: (err) => {
        const mensaje = this.extraerMensajeError(err) || 'Intenta nuevamente';
        this.mensajeError('Error al registrar', mensaje);
      }
    });
  }

  private camposValidos(): boolean {
    return !!this.nombre.trim() && this.duracion > 0;
  }

  private mensajeAdvertencia(titulo: string, mensaje: string): void {
    Swal.fire({
      icon: 'warning',
      title: titulo,
      text: mensaje,
      confirmButtonText: 'Aceptar'
    });
  }

  private mensajeError(titulo: string, mensaje: string): void {
    Swal.fire({
      icon: 'error',
      title: titulo,
      text: mensaje,
      confirmButtonText: 'Aceptar'
    });
  }

  private mensajeExito(titulo: string, mensaje: string, cerrarDialogo = false): void {
    Swal.fire({
      icon: 'success',
      title: titulo,
      text: mensaje,
      timer: 1500,
      showConfirmButton: false
    }).then(() => {
      if (cerrarDialogo) {
        this.cerrarDialog(true);
      }
    });
  }

  private cerrarDialog(resultado: boolean): void {
    this.dialogRef.close(resultado);
  }

  private extraerMensajeError(err: any): string | null {

    if (!err) return null;
    if (err.error?.message) return err.error.message;
    if (Array.isArray(err.error?.errors)) return err.error.errors.join(', ');
    return err.message || null;
  }
}
