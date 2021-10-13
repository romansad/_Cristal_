import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Task } from '../interfaces/task.app';

@Injectable(
  //{
  ///*  providedIn: 'root'*/
  //}
)
export class TaskService {
  private api = 'https://jsonplaceholder.typicode.com';
  constructor(private http: HttpClient) { }
  getAllTasks() {
    const path = '${this.api}/todos';
    return this.http.get<Task[]>(path);
    // return this.http.post<Task[]>(path); ver el resto como debe implementarse

  }
  getTask(id: string) {
    const path = '${this.api}/${id}';
    return this.http.get<Task>(path);
    // return this.http.post<Task[]>(path); ver el resto como debe implementarse

  }
  createTask(task: Task) {
    const path = 'https://api.mobbex.com/p/checkout';
    return this.http.post<Task>(path, task);
    // return this.http.post<Task[]>(path); ver el resto como debe implementarse

}

}
