import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpuestosVecinoAdeudaTablaComponent } from './impuestos-vecino-adeuda-tabla.component';

describe('ImpuestosVecinoAdeudaTablaComponent', () => {
  let component: ImpuestosVecinoAdeudaTablaComponent;
  let fixture: ComponentFixture<ImpuestosVecinoAdeudaTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpuestosVecinoAdeudaTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpuestosVecinoAdeudaTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
