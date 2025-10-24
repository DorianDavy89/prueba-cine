import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment.development";
import { ActualizarPelicula } from "../../interface/Pelicula/interface.actualizar.pelicula";
import { BuscarPelicula } from "../../interface/Pelicula/interface.buscar.pelicula";
import { ObtenerPeliculas } from "../../interface/Pelicula/interface.obtener.peliculas";
import { RegistrarPelicula } from "../../interface/Pelicula/interface.registrar.pelicula";

@Injectable({
  providedIn: 'root'
})

export class PeliculaService{

  private apiUrlBase: string = environment.endpoint;
  private productoApiUrl: string = 'api/pelicula';

  constructor(private http: HttpClient) { }

  getPeliculas(): Observable<ObtenerPeliculas[]> {
    return this.http.get<any>(`${this.apiUrlBase}${this.productoApiUrl}/listado`).pipe(
      map(response => response.$values || response || [])
    );
  }

  registrarPelicula(data: RegistrarPelicula): Observable<ObtenerPeliculas> {
    const url = `${this.apiUrlBase}${this.productoApiUrl}/registrar`;
    return this.http.post<ObtenerPeliculas>(url, data);
  }

  actualizarPelicula(id: number, data: ActualizarPelicula): Observable<ObtenerPeliculas> {
    const url = `${this.apiUrlBase}${this.productoApiUrl}/actualizar/${id}`;
    return this.http.put<ObtenerPeliculas>(url, data);
  }

  eliminarPelicula(id: number): Observable<boolean> {
    const url = `${this.apiUrlBase}${this.productoApiUrl}/eliminar/${id}`;
    return this.http.delete<boolean>(url);
  }

  buscarPelicula(nombre: string): Observable<BuscarPelicula[]> {
    return this.http.get<any>(`${this.apiUrlBase}${this.productoApiUrl}/buscar/${nombre}`).pipe(
      map(response => response.$values || response || [])
    );
  }

}
