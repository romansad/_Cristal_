////import { HttpClientModule, HttpClient } from '@angular/common/http'
////import { Injectable, Inject } from '@angular/core';
////import { Http } from '@angular/http';
////import 'rxjs/add/operator/map';
////import { r } from '@angular/core/src/render3';

////@Injectable()

////export class LoginService {
////  urlBase: string = "";
////  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
////    this.urlBase = baseUrl;

////  }


////  public login(usuario) {
////    return this.http.post(this.urlBase + "api/Usuario/login",usuario).map(res => res.json());
////  }

////  (data => {
////  var inf = data.valor;
////  if (inf == "")

////  public obtenerVariableSesion() {
////    return false
////  }

////  Este login service me parece que no se usa. 

////   return this.http.get(this.urlBase + 'api/Login/obtenerVariableSesion').map(data);
////  {
////    var inf = data.valor;
////    if (inf == "")
////    {
////      return false;
////      this.router.navigate(["/pagina-error"]);
////    }
////    else
////    {
////      return true;
////    }
////  })


////}
