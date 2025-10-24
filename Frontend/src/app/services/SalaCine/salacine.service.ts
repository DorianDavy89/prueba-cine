import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment.development";
import { Observable, map } from "rxjs";
import { Disponibilidad } from "../../interface/SalaCine/interface.salacine";

@Injectable({
  providedIn: 'root'
})

export class SalaCine {

  private apiUrlBase: string = environment.endpoint;
  private productoApiUrl: string = 'api/sala-cine';

  constructor(private http: HttpClient) { }

  verificarDisponibilidad(nombreSala: string): Observable<Disponibilidad> {
    return this.http.get<any>(`${this.apiUrlBase}${this.productoApiUrl}/disponibilidad/${nombreSala}`).pipe(
      map(response => response.$values || response)
    );
  }


}
