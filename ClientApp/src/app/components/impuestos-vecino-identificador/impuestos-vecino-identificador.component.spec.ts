import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpuestosVecinoIdentificadorComponent } from './impuestos-vecino-identificador.component';

describe('ImpuestosVecinoIdentificadorComponent', () => {
  let component: ImpuestosVecinoIdentificadorComponent;
  let fixture: ComponentFixture<ImpuestosVecinoIdentificadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpuestosVecinoIdentificadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpuestosVecinoIdentificadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
