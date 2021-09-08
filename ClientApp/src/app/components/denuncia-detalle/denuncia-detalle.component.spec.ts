import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DenunciaDetalleComponent } from './denuncia-detalle.component';

describe('DenunciaDetalleComponent', () => {
  let component: DenunciaDetalleComponent;
  let fixture: ComponentFixture<DenunciaDetalleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DenunciaDetalleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DenunciaDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
