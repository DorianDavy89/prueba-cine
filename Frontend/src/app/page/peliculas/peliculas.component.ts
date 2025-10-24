import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialog } from "@angular/material/dialog";
import { MatDividerModule } from "@angular/material/divider";
import { MatLabel, MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInput } from "@angular/material/input";
import { MatTableDataSource, MatTableModule } from "@angular/material/table";
import { MatTooltipModule } from "@angular/material/tooltip";
import { Router, RouterModule } from "@angular/router";
import { RegistrarPeliculasComponent } from "./registrar/registrarpeliculas.component";
import Swal from "sweetalert2";
import { PeliculaService } from "../../services/Pelicula/peliculas.service";
import { ObtenerPeliculas } from "../../interface/Pelicula/interface.obtener.peliculas";
import { ActualizarPeliculasComponent } from "./actualizar/actualizarpeliculas.component";

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
  columnas: string[] = ['nombre', 'duracion', 'ACCIONES'];
  datos = new MatTableDataSource<ObtenerPeliculas>([]);
  terminoBusqueda: string = '';

  constructor(private router: Router, private dialog: MatDialog,
    private peliculaservices: PeliculaService
  ) { }

  ngOnInit(): void {
    this.obtenerPeliculas();
  }

  obtenerPeliculas(): void {
    this.peliculaservices.getPeliculas().subscribe({
      next: (peliculas) => {
        this.datos.data = peliculas;
        console.log('Peliculas cargadas:', peliculas);
      },
      error: (error) => {
        alert('Error al obtener datos');
        console.error(error);
      },
      complete: () => {
        console.info('Carga completa');
      }
    });
  }

  buscarPorNombre(): void {
    if (this.terminoBusqueda.trim() === '') {
      this.obtenerPeliculas();
      return;
    }

    this.peliculaservices.buscarPelicula(this.terminoBusqueda).subscribe({
      next: (peliculas) => {
        this.datos.data = peliculas;
        console.log('Películas encontradas:', peliculas);

        if (peliculas.length === 0) {
          this.mensajeError('Sin resultados', 'No se encontraron películas con ese nombre');
        }
      },
      error: (error) => {
        this.mensajeError('Error', 'Error al buscar películas');
        console.error(error);
      }
    });
  }

  regresar(): void {
    this.router.navigate(['/dashboard']);

  }

  eliminarPelicula(id: number): void {
    this.mensajeConfirmacion('¿Estás seguro?', 'Esta acción eliminará pelicula permanentemente.')
      .then((result) => {
        if (result.isConfirmed) {
          this.peliculaservices.eliminarPelicula(id).subscribe({
            next: (respuesta) => {
              if (respuesta) {
                this.mensajeExito('Pelicula eliminada', 'Eliminacion correcta.');
                this.obtenerPeliculas();
              } else { this.mensajeError('Error', 'No se pudo eliminar pelicula.'); }
            },
            error: (error) => {
              this.mensajeError('Error de servidor', 'Ocurrió un problema al intentar eliminar.');
              console.error(error);
            }
          });
        }
      });
  }

  abrirFormularioRegistro(): void {
    const dialogRef = this.dialog.open(RegistrarPeliculasComponent, {
      disableClose: false,
    });
    dialogRef.afterClosed().subscribe((registroExitoso) => {
      if (registroExitoso) {
        this.obtenerPeliculas();
      }
    });
  }

  abrirFormularioActualizar(pelicula: ObtenerPeliculas): void {
    const dialogRef = this.dialog.open(ActualizarPeliculasComponent, {
      disableClose: false,
      data: pelicula
    });
    dialogRef.afterClosed().subscribe((registroExitoso) => {
      if (registroExitoso) {
        this.obtenerPeliculas();
      }
    });
  }

  private mensajeConfirmacion(titulo: string, mensaje: string): Promise<any> {
    return Swal.fire({
      title: titulo,
      text: mensaje,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6'
    });
  }


  private mensajeExito(titulo: string, mensaje: string, autoClose = false): void {
    Swal.fire({
      icon: 'success',
      title: titulo,
      text: mensaje,
      confirmButtonColor: '#3085d6',
      timer: autoClose ? 1500 : undefined,
      showConfirmButton: !autoClose
    });
  }


  private mensajeError(titulo: string, mensaje: string): void {
    Swal.fire({
      icon: 'error',
      title: titulo,
      text: mensaje,
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Aceptar'
    });
  }
}
