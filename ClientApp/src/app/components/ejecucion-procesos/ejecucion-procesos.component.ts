import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ImpuestoService } from '../../services/impuesto.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'ejecucion-procesos',
  templateUrl: './ejecucion-procesos.component.html',
  styleUrls: ['./ejecucion-procesos.component.css']
})
export class EjecucionProcesosComponent implements OnInit {
  interesMensual: any;
  fechaHoy: Date = new Date();
  fechaEjecucion: Date;
  MesfechaEjeTemp: any;
  MesActualTemp: any;
  constructor(private impuestoService: ImpuestoService ,private router: Router, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
  }
  getinteresMensual() {

    //this.impuestoService.getUltimaFechaInteres().subscribe(param => {
    //  if(param.fechaEjecucion )
    //}
    this.impuestoService.getUltimaFechaInteres().subscribe(param => this.interesMensual = param);
    this.fechaEjecucion = new Date(this.interesMensual.fechaEjecucion);
    //console.log('Solo mes+'+this.fechaEjecucion.getMonth());
    console.log('Mes ultima ejecucion:' + this.fechaEjecucion.toLocaleString('en-us', { month: 'long' }));
     this.MesfechaEjeTemp =this.fechaEjecucion.toLocaleString('en-us', { month: 'long' });
    console.log('Mes Actual' + this.fechaHoy.toLocaleString('en-us', { month: 'long' }));
    this.MesActualTemp = this.fechaHoy.toLocaleString('en-us', { month: 'long' });
    if (this.MesActualTemp == this.MesfechaEjeTemp) {
      alert("El proceso de generacion de Impuestos ha sido ejecutado exitosamente.");
      console.log('ejecutar sp');
    }
    else { console.log('ejecutar sp');}
      //      this.error = true;v
    //      this.router.navigate(["/login"]);
    //    }
    
    //this.im.login(this.usuario.value).subscribe(res => {
    //  //  SI la fecha del ultimo proceso es del mismo mes enviar alert que ya se se ejecuto sino ejecutarlo.
    //          if (res.idUsuario == 0 || res.idUsuario == "") {   
    //      this.error = true;
    //      this.router.navigate(["/login"]);
    //    }
    //    else {
    //      //Esta Ok
    //      this.error = false;
    //      //this.router.navigate(["/bienvenida"]);login
    //      window.location.href = this.urlBase + "bienvenida";
    //    }
    //    console.log(res);

     // });
    
  }




}
