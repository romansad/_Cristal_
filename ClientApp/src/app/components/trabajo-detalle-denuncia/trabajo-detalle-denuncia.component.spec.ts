import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrabajoDetalleDenunciaComponent } from './trabajo-detalle-denuncia.component';

describe('TrabajoDetalleDenunciaComponent', () => {
  let component: TrabajoDetalleDenunciaComponent;
  let fixture: ComponentFixture<TrabajoDetalleDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrabajoDetalleDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrabajoDetalleDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
