import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { stringify } from '@angular/core/src/render3/util';
import { variable } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class ModalGenerarDenunciaComponent implements OnInit {
  date; //date Variable
  logedInForm; //These are variables
  emailId;
  password;
  display = 'none'; //default Variable

  constructor() { }

  ngOnInit() {
    this.date = new Date(); // Today date and time
    //Login Validation
    this.logedInForm = new FormGroup({
      emailId: new FormControl("youremail@gmail.com",
        Validators.compose([
          Validators.required,
          Validators.pattern("[^ @]*@[^ @]*")
        ])),
      password: new FormControl('YourPassword', [
        Validators.minLength(8),
        Validators.required])
    });
  }

  // Model Driven Form - login
  mdfLogin(data) {
    this.emailId = data.emailId;
    this.password = data.password;
    alert(JSON.stringify(data));
  }

  openModalDialog() {
    this.display = 'block'; //Set block css
  }

  closeModalDialog() {
    this.display = 'none'; //set none css after close dialog
  }
}

//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//import { Component, OnInit } from '@angular/core';

//@NgModule({
  
//  imports: [NgbModule, ...],
//})

//@Component({
//  selector: 'app-modal-generar-denuncia',
//  templateUrl: './modal-generar-denuncia.component.html',
//  styleUrls: ['./modal-generar-denuncia.component.css']
//})
//export class ModalGenerarDenunciaComponent implements OnInit {

//  constructor() { }

//  ngOnInit() {
//  }

//}
