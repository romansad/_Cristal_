import { Component, OnInit} from '@angular/core';
import { DenunciaService } from '../../services/denuncia.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'denuncia-form-generar',
  templateUrl: './denuncia-form-generar.component.html',
  styleUrls: ['./denuncia-form-generar.component.css']
})
export class DenunciaFormGenerarComponent implements OnInit {
  TiposDenuncia: any;
  Denuncia: FormGroup;
  foto: any;
  foto2: any;
  foto3: any;
  constructor(private denunciaservice: DenunciaService, private router: Router) {
    this.Denuncia = new FormGroup(
      {
        "Nro_Denuncia": new FormControl("0"),
        "Tipo_Denuncia": new FormControl("",[Validators.required]),
        'Descripcion': new FormControl("", [Validators.required, Validators.maxLength(2500)]),
        'Calle': new FormControl("", [Validators.required, Validators.maxLength(100)]),
         "Nombre_Infractor": new FormControl(""),
         "Apellido_Infractor": new FormControl(""),
        "Bhabilitado": new FormControl("1"),
        "Mail_Notificacion": new FormControl(""),  //, [Validators.required,Validators.maxLength(100),Validators.pattern("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
       "Movil_Notificacion": new FormControl(""),
        "Entre_Calles": new FormControl("", [Validators.required, Validators.maxLength(100)]),
        "Altura": new FormControl("", [Validators.required, Validators.maxLength(6)]),
        "foto": new FormControl(""),
        "foto2": new FormControl(""),
        "foto3": new FormControl("")
        }
    );
  }

  //Aqui vamos a leer el archivo
  changeFoto() {
    var file = (<HTMLInputElement>document.getElementById("fupFoto")).files[0];
    var fileReader = new FileReader();

    fileReader.onloadend = () => {   //Uso el Arrowfunction sino me marca error con foto.

      this.foto = fileReader.result;
    }    
    fileReader.readAsDataURL(file);
    // Foto 2
    var file2 = (<HTMLInputElement>document.getElementById("fupFoto2")).files[0];
    var fileReader2 = new FileReader();

    fileReader2.onloadend = () => {   //Uso el Arrowfunction sino me marca error con foto.

      this.foto2 = fileReader2.result;
    }
    fileReader2.readAsDataURL(file2);
    //Foto3
    var file3 = (<HTMLInputElement>document.getElementById("fupFoto3")).files[0];
    var fileReader3 = new FileReader();

    fileReader3.onloadend = () => {   //Uso el Arrowfunction sino me marca error con foto.

      this.foto3 = fileReader3.result;
    }
    fileReader3.readAsDataURL(file3);
  }

  ngOnInit() {
    this.denunciaservice.getTipoDenuncia().subscribe(data => this.TiposDenuncia = data);
    this.foto = "";
    this.foto2 = "";
    this.foto3 = "";
  }

  guardarDatos() {
    if (this.Denuncia.valid == true)
    {
      this.Denuncia.controls["foto"].setValue(this.foto); //Seteo la foto antes de guardarla
      this.Denuncia.controls["foto2"].setValue(this.foto2); //Seteo la foto antes de guardarla
      this.Denuncia.controls["foto3"].setValue(this.foto3); //Seteo la foto antes de guardarla
      this.denunciaservice.agregarDenuncia(this.Denuncia.value).subscribe(data => { });
      this.router.navigate(["/"]);
    }
  }
  clickMethod() {
    alert("La denuncia ha sido generada correctamente");
    //Luego de presionar click debe redireccionar al home
  }


}
