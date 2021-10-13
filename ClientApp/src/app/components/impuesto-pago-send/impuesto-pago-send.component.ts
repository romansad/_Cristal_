import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'impuesto-pago-send',
  templateUrl: './impuesto-pago-send.component.html',
  styleUrls: ['./impuesto-pago-send.component.css']
})
export class ImpuestoPagoSendComponent implements OnInit {

  constructor(private taskservice: TaskService) { }

  getAllTasks() {
    this.taskservice.getAllTasks().subscribe(tasks => { console.log(tasks) });
  }
  getTask() {
    this.taskservice.getTask('2').subscribe(task => { console.log(task) });
  }

  createTask() {
    const task = {
      "total": 100.53,
      "description": "Checkout de Prueba",
      "reference": "260520210954",
      "currency": "ARS",
      "test": true,
      "return_url": "https://mobbex.com/return_url",
      "webhook": "https://mobbex.com/webhook",
      "customer": {
        "email": "demo@mobbex.com",
        "name": "Cliente Demo",
        "identification": "12123123"
      }
    };
    this.taskservice.createTask(task).subscribe((newtask) => { console.log(newtask) });
    //Por ahora comento todo esto que sigue que es de mobex pero ya veremos que onda.
    //var xhr = new XMLHttpRequest();
    //xhr.withCredentials = true;

    //xhr.addEventListener("readystatechange", function () {
    //  if (this.readyState === 4) {
    //    console.log(this.responseText);
    //  }
    //});

    //xhr.open("POST", "https://api.mobbex.com/p/checkout");
    //xhr.setRequestHeader("x-api-key", "zJ8LFTBX6Ba8D611e9io13fDZAwj0QmKO1Hn1yIj");
    //xhr.setRequestHeader("x-access-token", "d31f0721-2f85-44e7-bcc6-15e19d1a53cc");
    //xhr.setRequestHeader("Content-Type", "application/json");

    //xhr.send(data);



  } //Fin Metodo create Task post


  ngOnInit() {
  }

}
