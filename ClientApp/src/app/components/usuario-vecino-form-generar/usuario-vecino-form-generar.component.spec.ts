import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioVecinoFormGenerarComponent } from './usuario-vecino-form-generar.component';

describe('UsuarioVecinoFormGenerarComponent', () => {
  let component: UsuarioVecinoFormGenerarComponent;
  let fixture: ComponentFixture<UsuarioVecinoFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioVecinoFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioVecinoFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
