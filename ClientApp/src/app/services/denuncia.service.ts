import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class DenunciaService {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;

  }

  public getTipoDenuncia() {
    return this.http.get(this.urlBase + 'api/Denuncia/listarTiposDenuncia').map(res => res.json());
  }

  public getEstadoDenuncia() {
    return this.http.get(this.urlBase + 'api/Denuncia/listarEstadosDenuncia').map(res => res.json());
  }

  public devolverAMesa(Trabajo) {
    var url = this.urlBase + 'api/Denuncia/devolverAMEsa';
    return this.http.post(url, Trabajo).map(res => res.json());
  }

  public solucionarDenuncia(Trabajo) {
    var url = this.urlBase + 'api/Denuncia/solucionarDenuncia';
    return this.http.post(url, Trabajo).map(res => res.json());
  }

  

  public getDenuncia() {
    return this.http.get(this.urlBase + 'api/Denuncia/listarDenuncias').map(res => res.json());
  }
  public agregarDenuncia(Denuncia) {
    var url = this.urlBase + 'api/Denuncia/guardarDenuncia';
    return this.http.post(url, Denuncia).map(res => res.json());
  }

  public DerivaPriorizaDenuncia(Denuncia) {
    var url = this.urlBase + 'api/Denuncia/DerivaPriorizaDenuncia';
    return this.http.post(url, Denuncia).map(res => res.json());

  }
}




