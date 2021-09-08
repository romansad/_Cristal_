import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { r } from '@angular/core/src/render3';

@Injectable()

export class ReclamoService {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;

  }

  public getTipoReclamo() {
    return this.http.get(this.urlBase + 'api/Reclamo/ListarTiposReclamo').map(res => res.json());
  }
  public agregarReclamo(Reclamo) {
    var url = this.urlBase + 'api/Reclamo/guardarReclamo';
    return this.http.post(url, Reclamo).map(res => res.json());
  }
  public getReclamo() {
    return this.http.get(this.urlBase + 'api/Reclamo/ListarReclamos').map(res => res.json());
  }



}






//  public getEstadoDenuncia() {
//    return this.http.get(this.urlBase + 'api/Denuncia/listarEstadosDenuncia').map(res => res.json());
//  }



 
//}

