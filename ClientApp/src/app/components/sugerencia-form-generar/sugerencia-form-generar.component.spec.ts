import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SugerenciaFormGenerarComponent } from './sugerencia-form-generar.component';

describe('SugerenciaFormGenerarComponent', () => {
  let component: SugerenciaFormGenerarComponent;
  let fixture: ComponentFixture<SugerenciaFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SugerenciaFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SugerenciaFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
