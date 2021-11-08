import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { DenunciaService } from '../../services/denuncia.service';
import { SugerenciaService } from '../../services/sugerencia.service';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'sugerencia-tabla',
  templateUrl: './sugerencia-tabla.component.html',
  styleUrls: ['./sugerencia-tabla.component.css']
})
export class SugerenciaTablaComponent implements OnInit {

  @Input() isMantenimiento = true; //A ESTO DEBO DARLE EVENTO DE CLICK PARA GESTION
  Sugerencias: any;
  Usuarios: any;
  TiposDenuncia: any;
  DenunciasFiltradas: any;
  p: number = 1;
  cabeceras: string[] = ["Id Sugerencia", "Fecha Generada", "Descripción"];
  constructor(private sugerenciaservice: SugerenciaService,  private formBuilder: FormBuilder) {
  }

  Sugerencia: FormGroup;

  ngOnInit() {

    this.sugerenciaservice.getSugerencia().subscribe(data => this.Sugerencias = data);
    this.Sugerencia = this.formBuilder.group({
      descripcion: '',
      tipoDenuncia: 0
    });

  }

  MarcarIrrelevante()
  {

  }


}


