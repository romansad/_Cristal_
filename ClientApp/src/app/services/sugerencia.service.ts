import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { r } from '@angular/core/src/render3';

@Injectable()

export class SugerenciaService  {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;

  }

  public agregarSugerencia(Sugerencia) {
   
    var url = this.urlBase + 'api/Sugerencia/guardarSugerencia';
    return this.http.post(url,Sugerencia).map(res => res.json());
  }
  public getSugerencia() {
    return this.http.get(this.urlBase + 'api/Sugerencia/listarSugerencias').map(res => res.json());
  }



}






//  public getEstadoDenuncia() {
//    return this.http.get(this.urlBase + 'api/Denuncia/listarEstadosDenuncia').map(res => res.json());
//  }




//}

