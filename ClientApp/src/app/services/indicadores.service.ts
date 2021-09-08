
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class IndicadoresService {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;

}

  public getDenunciasxEmpleado() {
    return this.http.get(this.urlBase + 'api/Denuncia/DenunciasxEmpleado').map(res => res.json());
  }


}
