import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment.development";
import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { BuscarPelicula } from "../../interface/Pelicula/interface.buscar.pelicula";

@Injectable({
  providedIn: 'root'
})

export class PeliculaSala{

  private apiUrlBase: string = environment.endpoint;
  private productoApiUrl: string = 'api/pelicula-sala';

  constructor(private http: HttpClient) { }

  buscarPeliculasPorFecha(fecha: string): Observable<BuscarPelicula[]> {
    return this.http.get<any>(`${this.apiUrlBase}${this.productoApiUrl}/fecha/${fecha}`).pipe(
      map(response => response.$values || response || [])
    );
  }
}
