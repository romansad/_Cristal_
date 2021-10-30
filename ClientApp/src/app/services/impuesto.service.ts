import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';


@Injectable()
export class ImpuestoService {
  urlBase: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.urlBase = baseUrl;
  }
  public getUltimaFechaInteres() {
    return this.http.get(this.urlBase + 'api/Impuestos/getUltimaFechaInteres').map(res => res.json());
  }

  getUltimaFechaBoleta() {
    return this.http.get(this.urlBase + 'api/Impuestos/getUltimaFechaBoleta').map(res => res.json());
  }

  public ListarImpuestosAdeudados(idLote) {
    return this.http.get(this.urlBase + 'api/Impuesto/ListarImpuestosAdeudados/' + idLote)
      .map(res => res.json());
  }

  public SP_GeneracionImpuestos() {
    return this.http.get(this.urlBase + 'api/Impuestos/SP_GeneracionImpuestos')
  }

  public SP_GeneracionInteresesMensuales() {
    return this.http.get(this.urlBase + 'api/Impuestos/SP_GeneracionInteresesMensuales')

  }
  public SP_LimpiezaBoletas() {
    return this.http.get(this.urlBase + 'api/Impuestos/SP_LimpiezaBoletas')

  }
  public guardarBoleta(FGimpuestos) {
    var url = this.urlBase + 'api/Impuestos/guardarBoleta/';
    return this.http.post(url, FGimpuestos).map(res => res.json());

  }

  public obtenerUrlMobbexx() {
    //return this.http.get(this.urlBase + 'api/Impuesto/obtenerUrlMobbexx').map(res => res.json());
    return this.http.get(this.urlBase + 'api/Impuesto/obtenerUrlMobbexx').map(res => {
      var myJSON = decodeURIComponent(res.json());
      var myObject = JSON.parse(myJSON);
      console.log("Se hace +" + myObject);
      this.router.navigate(myObject);
    });


  }
  public obtenerUrlMobbexx2() {
    return this.http.get(this.urlBase + 'api/Impuesto/obtenerUrlMobbexx2').map(res => res.json());

  }


}



