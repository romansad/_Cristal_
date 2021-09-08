import { Component, OnInit, Input } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'tabla-usuario',
  templateUrl: './tabla-usuario.component.html',
  styleUrls: ['./tabla-usuario.component.css']
})
export class TablaUsuarioComponent implements OnInit {
  //@Input() usuarios: any;
  @Input() isMantenimiento = true; //A ESTO DEBO DARLE EVENTO DE CLICK PARA GESTION
  usuarios: any;
  cabeceras: string[] = ["Id Usuario", "Nombre User", "Fecha Alta", "Rol"];
  constructor(private usuarioservice: UsuarioService) {
  }


  ngOnInit() {
    this.usuarioservice.getUsuario().subscribe(data => this.usuarios = data);
    //console.log(this.usuarios);
  }

}


