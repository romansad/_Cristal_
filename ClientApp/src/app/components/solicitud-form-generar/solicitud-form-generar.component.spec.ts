import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitudFormGenerarComponent } from './solicitud-form-generar.component';

describe('SolicitudFormGenerarComponent', () => {
  let component: SolicitudFormGenerarComponent;
  let fixture: ComponentFixture<SolicitudFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SolicitudFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SolicitudFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
