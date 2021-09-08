import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Injectable()

export class UsuarioService {
  urlBase: string = "";
  //,private router: Router
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.urlBase = baseUrl;

  }

  public getRol() {
    return this.http.get(this.urlBase + 'api/Usuario/listarRol').map(res => res.json());
  }
  //Modificacion de Roles
  public listarRoles() {
    return this.http.get(this.urlBase + 'api/Rol/listarRoles').map(res => res.json());
  }

  //Listado de paginasTipo Rol
  public listarPaginasTipoRol() {
    return this.http.get(this.urlBase + 'api/Rol/listarPaginasTipoRol').map(res => res.json());
  }  
  public listarPaginasRecuperar(idRol) {
    return this.http.get(this.urlBase + 'api/Rol/listarPaginasRecuperar/' + idRol).map(res => res.json());
  }

  public listarTodasPaginas() { 
    return this.http.get(this.urlBase + 'api/Pagina/listarTodasPaginas').map(res => res.json());
  }

  public guardarPagina(oPaginaCLS) {

    var url = this.urlBase + 'api/Pagina/guardarPagina';
    return this.http.post(url, oPaginaCLS).map(res => res.json());

  }
  public recuperarPagina(idPagina) {
      return this.http.get(this.urlBase + 'api/Pagina/recuperarPagina/ ' + idPagina).map(res => res.json());
  }
  public eliminarPagina(idPagina) {
    return this.http.get(this.urlBase + 'api/Pagina/eliminarPagina/ ' + idPagina).map(res => res.json());
  }





  public guardarROL(oRolCLS) {

    var url = this.urlBase + 'api/Rol/guardarROL/';
    return this.http.post(url, oRolCLS).map(res => res.json());

  }

  public eliminarRol(idRol) 
  {
    return this.http.get(this.urlBase + 'api/Rol/eliminarRol/' + idRol).map(res => res.json());
  }
  public getUsuario() {
    return this.http.get(this.urlBase + 'api/Usuario/listarUsuarios')
     .map(res => res.json());
  }
  public getFiltrarUsuarioPorTipo(idTipo) {
    return this.http.get(this.urlBase + 'api/Usuario/filtrarUsuarioPorTipo/' + idTipo);
  }

  public RecuperarUsuario(idUsuario) {
    return this.http.get(this.urlBase + 'api/Usuario/recuperarUsuario/' + idUsuario).map(res => res.json());//.catch(this.errorHandler);
  }

  public GuardarUsuario(Usuario) {
    var url = this.urlBase + 'api/Usuario/guardarUsuario/';
    return this.http.post(url, Usuario).map(res => res.json());
  }

  public validarCorreo(id, correo) {
    return this.http.get(this.urlBase + "api/Vecino/validarCorreo/" + id +"/" + correo).map(res => res.json());
  }

  public GuardarVecino(Usuario) {
    var url = this.urlBase + 'api/Vecino/guardarVecino/';
    return this.http.post(url, Usuario).map(res => res.json());
  }

  public listarPaginas() {
    return this.http.get(this.urlBase + 'api/Usuario/listarPaginas')
      .map(res => res.json());
  }



  public ObtenerVariableSession(next) {
    return this.http.get(this.urlBase + 'api/Usuario/obtenerVariableSession').map(res => {
      var data = res.json();
      var inf = data.valor;
      if (inf == "") {
        this.router.navigate(["/error-pagina-login"]);
        return false;
      }
      else
      {
        //Aca trajimos el parametro next para que tomemos la ruta de la base continuar mañana.
        var pagina = next["url"][0].path;
        if (data.lista != null) {
        var paginas = data.lista.map(pagina => pagina.accion);
        if (paginas.indexOf(pagina)> -1 && pagina != "Login") {
          return true;
        }
        else {
          this.router.navigate(["/error-pagina-login"]);
          return false;
          }
        }
        //return true;        // si algo falla aca falta un return true
      }

    });
  }
  public obtenerSessionidEmpleado() {
    return this.http.get(this.urlBase + 'api/Usuario/obtenerVariableSessionID').map(res => res.json());
  }
  public ObtenerSession() {
    return this.http.get(this.urlBase + 'api/Usuario/obtenerVariableSession').map(res => {
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


  //   ************** LOGIN *****************
  public login(usuario) {
    return this.http.post(this.urlBase + "api/Usuario/login/", usuario).map(res => res.json());
  }


  public cerrarSession() {
    return this.http.get(this.urlBase + "api/Usuario/cerrarSession").map(res => res.json());
  }

  //   *************** FIN LOGIN ***************

}
