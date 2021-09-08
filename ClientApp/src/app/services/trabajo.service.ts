import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class TrabajoService {
  urlBase: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
      }
  public getUsuario() {
    return this.http.get(this.urlBase + 'api/Trabajo/listarUsuarios')
      .map(res => res.json());
  }
  public getPrioridad() {
    return this.http.get(this.urlBase + 'api/Trabajo/listarPrioridades')
      .map(res => res.json());
  }
   public GuardarTrabajo(Trabajo) {
    var url = this.urlBase + 'api/Trabajo/guardarTrabajo/';
    return this.http.post(url, Trabajo).map(res => res.json());
   }

  public GuardarTrabajoReclamo(Trabajo) {
    var url = this.urlBase + 'api/Trabajo/GuardarTrabajoReclamo/';
    return this.http.post(url, Trabajo).map(res => res.json());
  }


  
  public detalleDenuncia(idDenuncia) {
    return this.http.get(this.urlBase + 'api/Trabajo/detalleDenuncia/' + idDenuncia)
      .map(res => res.json());
  }
  public detalleTrabajoDenuncia(nro_Trabajo) {
    return this.http.get(this.urlBase + 'api/Trabajo/detalleTrabajoDenuncia/' + nro_Trabajo)
      .map(res => res.json());
  }
  public ImagenTrabajoDenuncia(nro_Trabajo) {
    return this.http.get(this.urlBase + 'api/Trabajo/ImagenTrabajoDenuncia/' + nro_Trabajo)
      .map(res => res.json());
  }

  public RecuperarDenuncia(idDenuncia) {
    return this.http.get(this.urlBase + 'api/Trabajo/RecuperarDenuncia/'+ idDenuncia)
      .map(res => res.json());
  }
  public RecuperarReclamo(idReclamo) {
    return this.http.get(this.urlBase + 'api/Trabajo/RecuperarReclamo/' + idReclamo)
      .map(res => res.json());
  }


  public ListarTrabajos(idDenuncia) {
    return this.http.get(this.urlBase + 'api/Trabajo/ListarTrabajos/' + idDenuncia)
      .map(res => res.json());
  }
  public ListarTrabajosReclamo(idReclamo) {
    return this.http.get(this.urlBase + 'api/Trabajo/ListarTrabajosReclamo/' + idReclamo)
      .map(res => res.json());
  }




  


}

 
