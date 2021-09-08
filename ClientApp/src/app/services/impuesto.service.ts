import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class ImpuestoService {
  urlBase: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }
  public getUltimaFechaInteres() {
    return this.http.get(this.urlBase + 'api/Impuestos/getUltimaFechaInteres').map(res => res.json());
  }

  public ListarImpuestosAdeudados(idLote) {
    return this.http.get(this.urlBase + 'api/Impuesto/ListarImpuestosAdeudados/' + idLote)
      .map(res => res.json());
  }


}