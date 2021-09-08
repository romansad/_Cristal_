import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { VecinoService } from '../../services/vecino.service';

@Injectable()
export class SeguridadVecinoGuard implements CanActivate {
  constructor(private router: Router, private vecinoService: VecinoService) {

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.vecinoService.ObtenerVariableSession();
 }
}
