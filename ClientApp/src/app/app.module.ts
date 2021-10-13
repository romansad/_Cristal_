import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
// Importar lo siguietne para trabajar con formularios:
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
//Guards
import { SeguridadGuard } from './components/guards/seguridad.guard';
import { SeguridadVecinoGuard } from './components/guards/seguridad-vecino.guard';
//Componentes
import { TablaUsuarioComponent } from './components/tabla-usuario/tabla-usuario.component';
import { UsuarioService } from './services/usuario.service';
import { TablaDenunciaComponent } from './components/tabla-denuncia/tabla-denuncia.component';
import { TablaTipoDenunciaComponent } from './components/tabla-tipo-denuncia/tabla-tipo-denuncia.component';
import { TablaEstadoDenunciaComponent } from './components/tabla-estado-denuncia/tabla-estado-denuncia.component';
import { DenunciaService } from './services/denuncia.service';
import { DenunciaFormGenerarComponent } from './components/denuncia-form-generar/denuncia-form-generar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TablaTrabajoComponent } from './components/tabla-trabajo/tabla-trabajo.component';
import { TrabajoFormGenerarComponent } from './components/trabajo-form-generar/trabajo-form-generar.component';
import { TrabajoService } from './services/trabajo.service';
import { FormUsuarioGenerarComponent } from './components/form-usuario-generar/form-usuario-generar.component';
import { ReclamoTablaComponent } from './components/reclamo-tabla/reclamo-tabla.component';
import { ReclamoFormGenerarComponent } from './components/reclamo-form-generar/reclamo-form-generar.component';
import { ReclamoService } from './services/reclamo.service';
import { ReclamoTrabajoFormComponent } from './components/reclamo-trabajo-form/reclamo-trabajo-form.component';
import { ReclamoTrabajoTablaComponent } from './components/reclamo-trabajo-tabla/reclamo-trabajo-tabla.component';
import { LoginComponent } from './components/login/login.component';
import { ErrorPaginLoginComponent } from './components/error-pagin-login/error-pagin-login.component';
import { PermisoErrorPaginaComponent } from './components/permiso-error-pagina/permiso-error-pagina.component';
import { UsuarioVecinoFormGenerarComponent } from './components/usuario-vecino-form-generar/usuario-vecino-form-generar.component';
import { VecinoService } from './services/vecino.service';
import { LoginVecinoComponent } from './components/login-vecino/login-vecino.component';
import { BienvenidaComponent } from './components/bienvenida/bienvenida.component';
import { SugerenciaFormGenerarComponent } from './components/sugerencia-form-generar/sugerencia-form-generar.component';
import { SolicitudFormGenerarComponent } from './components/solicitud-form-generar/solicitud-form-generar.component';
import { BienvenidaVecinoComponent } from './components/bienvenida-vecino/bienvenida-vecino.component';
import { TipoRolTablaComponent } from './components/tipo-rol-tabla/tipo-rol-tabla.component';
import { TipoRolFormGenerarComponent } from './components/tipo-rol-form-generar/tipo-rol-form-generar.component';
import { PaginaFormGenerarComponent } from './components/pagina-form-generar/pagina-form-generar.component';
import { PaginaTablaComponent } from './components/pagina-tabla/pagina-tabla.component';
import { DenunciaDetalleComponent } from './components/denuncia-detalle/denuncia-detalle.component';
import { PruebaGraficaService } from './services/prueba-grafica.service';
import { TrabajoDetalleDenunciaComponent } from './components/trabajo-detalle-denuncia/trabajo-detalle-denuncia.component';
import { IndicadoresService } from './services/indicadores.service';
import { ImpuestoService } from './services/impuesto.service';

import { SugerenciasComponent } from './sugerencias/sugerencias.component';
import { FiltroDenunciaComponent } from './components/filtro-denuncia/filtro-denuncia.component';
import { EjecucionProcesosComponent } from './components/ejecucion-procesos/ejecucion-procesos.component';
import { ImpuestosVecinoIdentificadorComponent } from './components/impuestos-vecino-identificador/impuestos-vecino-identificador.component';
import { ImpuestosVecinoAdeudaTablaComponent } from './components/impuestos-vecino-adeuda-tabla/impuestos-vecino-adeuda-tabla.component';
import { MapasCordobaComponent } from './components/mapas-cordoba/mapas-cordoba.component';
import { TaskService } from './services/task.service';
import { ImpuestoPagoSendComponent } from './components/impuesto-pago-send/impuesto-pago-send.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TablaUsuarioComponent,
    TablaDenunciaComponent,
    TablaTipoDenunciaComponent,
    TablaEstadoDenunciaComponent,
    DenunciaFormGenerarComponent,
    TablaTrabajoComponent,
    TrabajoFormGenerarComponent,
    FormUsuarioGenerarComponent,
    ReclamoTablaComponent,
    ReclamoFormGenerarComponent,
    ReclamoTrabajoFormComponent,
    ReclamoTrabajoTablaComponent,
    LoginComponent,
    ErrorPaginLoginComponent,
    PermisoErrorPaginaComponent,
    BienvenidaComponent,
    UsuarioVecinoFormGenerarComponent,
    LoginVecinoComponent,
    SugerenciaFormGenerarComponent,
    SolicitudFormGenerarComponent,
    BienvenidaVecinoComponent,
    TipoRolTablaComponent,
    TipoRolFormGenerarComponent,
    PaginaFormGenerarComponent,
    PaginaTablaComponent,
    DenunciaDetalleComponent,
    TrabajoDetalleDenunciaComponent,
    SugerenciasComponent,
    FiltroDenunciaComponent,
    EjecucionProcesosComponent,
    ImpuestosVecinoIdentificadorComponent,
    ImpuestosVecinoAdeudaTablaComponent,
    MapasCordobaComponent,
    ImpuestoPagoSendComponent,

     ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  //   FontAwesomeModule,
    HttpModule,
    NgxPaginationModule,
    NgbModule.forRoot(),
      RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tabla-usuario', component: TablaUsuarioComponent,canActivate: [SeguridadGuard]},
      { path: 'tabla-tipo-denuncia', component: TablaTipoDenunciaComponent },
      { path: 'tabla-estado-denuncia', component: TablaEstadoDenunciaComponent, canActivate: [SeguridadGuard]},
      { path: 'denuncia-form-generar', component: DenunciaFormGenerarComponent },
      { path: 'tabla-denuncia', component: TablaDenunciaComponent, canActivate: [SeguridadGuard] },
      { path: 'tabla-trabajo', component: TablaTrabajoComponent, canActivate: [SeguridadGuard] },
      { path: 'tabla-trabajo/:id', component: TablaTrabajoComponent, canActivate: [SeguridadGuard] },
      { path: 'trabajo-form-generar', component: TrabajoFormGenerarComponent, canActivate: [SeguridadGuard]   },
      { path: 'trabajo-form-generar/:id', component: TrabajoFormGenerarComponent, canActivate: [SeguridadGuard]  },
      { path: 'denuncia-detalle', component: DenunciaDetalleComponent, canActivate: [SeguridadGuard] },  
      { path: 'denuncia-detalle/:id', component: DenunciaDetalleComponent, canActivate: [SeguridadGuard] },  
      { path: 'form-usuario-generar', component: FormUsuarioGenerarComponent, canActivate: [SeguridadGuard] },    
      { path: 'form-usuario-generar/:id', component: FormUsuarioGenerarComponent },
      { path: 'reclamo-form-generar', component: ReclamoFormGenerarComponent, canActivate: [SeguridadVecinoGuard]},
      { path: 'reclamo-tabla', component: ReclamoTablaComponent, canActivate: [SeguridadGuard]},
      { path: 'reclamo-trabajo-form/:id', component: ReclamoTrabajoFormComponent, canActivate: [SeguridadGuard] },
      { path: 'reclamo-trabajo-tabla/:id', component: ReclamoTrabajoTablaComponent, canActivate: [SeguridadGuard]},
      { path: 'login', component: LoginComponent },
      { path: 'login-vecino', component: LoginVecinoComponent },
      { path: 'error-pagina-login', component: ErrorPaginLoginComponent},
      { path: 'permiso-error-pagina', component: PermisoErrorPaginaComponent }, 
      { path: 'bienvenida', component: BienvenidaComponent, canActivate: [SeguridadGuard] },
      { path: 'bienvenida-vecino', component: BienvenidaVecinoComponent, canActivate: [SeguridadVecinoGuard] },
      { path: 'usuario-vecino-form-generar', component: UsuarioVecinoFormGenerarComponent }, 
      { path: 'sugerencia-form-generar', component: SugerenciaFormGenerarComponent }, 
      { path: 'solicitud-form-generar', component: SolicitudFormGenerarComponent, canActivate: [SeguridadVecinoGuard] }, 
      { path: 'tipo-rol-tabla', component: TipoRolTablaComponent, canActivate: [SeguridadGuard] },  //, canActivate: [SeguridadVecinoGuard] 
      { path: 'tipo-rol-form-generar', component: TipoRolFormGenerarComponent, canActivate: [SeguridadGuard] },  //Una vez que agregue las paginas a la base se asigna guard canActivate: [SeguridadVecinoGuard]
      { path: 'tipo-rol-form-generar/:id', component: TipoRolFormGenerarComponent, canActivate: [SeguridadGuard] }, 
        { path: 'pagina-tabla', component: PaginaTablaComponent, canActivate: [SeguridadGuard] }, //
        { path: 'pagina-form-generar', component: PaginaFormGenerarComponent, canActivate: [SeguridadGuard] },  // 
        { path: 'trabajo-detalle-denuncia/:id', component: TrabajoDetalleDenunciaComponent, canActivate: [SeguridadGuard] },
        { path: 'trabajo-detalle-denuncia', component: TrabajoDetalleDenunciaComponent, canActivate: [SeguridadGuard] },
        { path: 'filtro-denuncia', component: FiltroDenunciaComponent, canActivate: [SeguridadGuard] }, //
        { path: 'ejecucion-procesos', component: EjecucionProcesosComponent, canActivate: [SeguridadGuard] }, //
        { path: 'impuestos-vecino-identificador', component: ImpuestosVecinoIdentificadorComponent },
        { path: 'impuestos-vecino-identificador/:id', component: ImpuestosVecinoIdentificadorComponent },
        { path: 'impuestos-vecino-adeuda-tabla', component: ImpuestosVecinoAdeudaTablaComponent },
        { path: 'impuestos-vecino-adeuda-tabla/:id', component: ImpuestosVecinoAdeudaTablaComponent },
        { path: 'mapas-cordoba', component: MapasCordobaComponent },
        { path: 'impuesto-pago-send', component: ImpuestoPagoSendComponent },

        

    
        { path: '**', redirectTo: '' } //regña de derivacion a ruteo especifico


      ])
  ],
  providers: [UsuarioService, DenunciaService, TrabajoService, ReclamoService, SeguridadGuard, VecinoService, SeguridadVecinoGuard, PruebaGraficaService, IndicadoresService, ImpuestoService, TaskService],
  bootstrap: [AppComponent]
})
export class AppModule { }
