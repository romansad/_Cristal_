import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Injectable()

export class VecinoService {
  urlBase: string = "";
  //,private router: Router
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.urlBase = baseUrl;

  }

  public getRol() {
    return this.http.get(this.urlBase + 'api/vecino/listarRol').map(res => res.json());;
  }

  public getvecino() {
    return this.http.get(this.urlBase + 'api/Vecino/listarvecinos')
      .map(res => res.json());
  }
  public getFiltrarvecinoPorTipo(idTipo) {
    return this.http.get(this.urlBase + 'api/Vecino/filtrarvecinoPorTipo/' + idTipo);
  }

  public Recuperarvecino(idvecino) {
    return this.http.get(this.urlBase + 'api/vecino/recuperarvecino/' + idvecino).map(res => res.json());//.catch(this.errorHandler);
  }

  public Guardarvecino(vecino) {
    var url = this.urlBase + 'api/Vecino/guardarvecino/';
    return this.http.post(url, vecino).map(res => res.json());
  }

  public GuardarVecino(vecino) {
    var url = this.urlBase + 'api/Vecino/guardarVecino/';
    return this.http.post(url, vecino).map(res => res.json());
  }



  //SOlo utilizado en el login
  public ObtenerVariableSession() {
    return this.http.get(this.urlBase + 'api/vecino/obtenerVariableSession').map(res => {
      var data = res.json();
      var inf = data.valor;
      if (inf == "") {
        this.router.navigate(["/error-pagina-login"]);
        return false;
      }
      else {
        return true;
      }

    });
  }

  public ObtenerSession() {
    return this.http.get(this.urlBase + 'api/vecino/obtenerVariableSession').map(res => {
      var data = res.json();
      var inf = data.valor;
      if (inf == "") {
        return false;
      }
      else {
        return true;
      }

    });
  }

  
  public obtenerSessionidVecino() {
    return this.http.get(this.urlBase + 'api/vecino/obtenerVariableSession').map(res => res.json());
      }
  public obtenerSessionNombreVecino() {
    return this.http.get(this.urlBase + 'api/vecino/obtenerSessionNombreVecino').map(res => res.json());
      
  }

  //   ************** LOGIN *****************
  public login(vecino) {
    return this.http.post(this.urlBase + "api/Vecino/login/", vecino).map(res => res.json());
  }


  public cerrarSessionVecino() {
    return this.http.get(this.urlBase + "api/Vecino/cerrarSessionVecino").map(res => res.json());
  }

  //   *************** FIN LOGIN ***************
}
