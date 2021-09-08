import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsuarioGenerarComponent } from './form-usuario-generar.component';

describe('FormUsuarioGenerarComponent', () => {
  let component: FormUsuarioGenerarComponent;
  let fixture: ComponentFixture<FormUsuarioGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormUsuarioGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsuarioGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
