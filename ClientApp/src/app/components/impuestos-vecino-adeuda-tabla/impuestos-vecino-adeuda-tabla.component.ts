import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ImpuestoService } from '../../services/impuesto.service';

@Component({
  selector: 'impuestos-vecino-adeuda-tabla',
  templateUrl: './impuestos-vecino-adeuda-tabla.component.html',
  styleUrls: ['./impuestos-vecino-adeuda-tabla.component.css']
})
export class ImpuestosVecinoAdeudaTablaComponent implements OnInit {
  parametro: any;
  titulo: any = "";
  impuestos: any;
  p: number = 1;

  cabeceras: string[] = ["Mes", "Año", "Importe Base", "Interés", "Importe Final"];
  constructor(private impuestoService: ImpuestoService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(parametro => {
      this.parametro = parametro["id"]
      if (this.parametro >= 1) {
        this.titulo = "Editar";
        console.log('El id de lote es' + this.parametro);

      } else {
        this.titulo = "Añadir";
      }
    });}

  ngOnInit() {
    if (this.parametro >= 1) {
      this.impuestoService.ListarImpuestosAdeudados(this.parametro).subscribe(data => this.impuestos = data);

    }
  }

  volver() {
    this.router.navigate(["/impuestos-vecino-identificador"]);
  }
}
