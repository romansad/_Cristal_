import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashDatosAbiertosComponent } from './dash-datos-abiertos.component';

describe('DashDatosAbiertosComponent', () => {
  let component: DashDatosAbiertosComponent;
  let fixture: ComponentFixture<DashDatosAbiertosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashDatosAbiertosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashDatosAbiertosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
