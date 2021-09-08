import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class PruebaGraficaService {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;

  }
  
  public ListarPruebasIniciales(idDenuncia) {
    return this.http.get(this.urlBase + 'api/PruebaGrafica/ListarPruebasIniciales/' + idDenuncia).map(res => res.json());
  }

  //public agregarDenuncia(Denuncia) {
  //  var url = this.urlBase + 'api/Denuncia/guardarDenuncia';
  //  return this.http.post(url, Denuncia).map(res => res.json());
  //}
}

