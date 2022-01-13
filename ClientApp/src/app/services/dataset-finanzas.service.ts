import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';

@Injectable()
export class DatasetFinanzasService {
  urlBase: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.urlBase = baseUrl;
  }

  public generarDatasetImpuestos() {
    return this.http.get(this.urlBase + 'api/DatosAbiertos/generaImpuestoInmobiliarioMensual').map(res => res.json());

  }

  public ListarFinancieros() {
    return this.http.get(this.urlBase + 'api/DatosAbiertos/ListarFinancieros').map(res => res.json());
  }



}



