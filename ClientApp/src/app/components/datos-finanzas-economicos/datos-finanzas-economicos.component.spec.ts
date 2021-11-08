import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosFinanzasEconomicosComponent } from './datos-finanzas-economicos.component';

describe('DatosFinanzasEconomicosComponent', () => {
  let component: DatosFinanzasEconomicosComponent;
  let fixture: ComponentFixture<DatosFinanzasEconomicosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosFinanzasEconomicosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosFinanzasEconomicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
