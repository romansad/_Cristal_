import { Component, OnInit, Input } from '@angular/core';
import { DenunciaService } from '../../services/denuncia.service';

@Component({
  selector: 'tabla-tipo-denuncia',
  templateUrl: './tabla-tipo-denuncia.component.html',
  styleUrls: ['./tabla-tipo-denuncia.component.css']
})
export class TablaTipoDenunciaComponent implements OnInit {

  TiposDenuncia: any;
  cabeceras: string[] = ["Id Tipo", "Nombre Tipo", "Tiempo Maximo Tratamiento en Hs", "Descripción"];
  constructor(private denunciaservice: DenunciaService) {
  }


  ngOnInit() {
   this.denunciaservice.getTipoDenuncia().subscribe(data => this.TiposDenuncia = data);
    
  }
}
