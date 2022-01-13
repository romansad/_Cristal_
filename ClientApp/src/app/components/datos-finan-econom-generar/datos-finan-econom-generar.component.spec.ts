import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosFinanEconomGenerarComponent } from './datos-finan-econom-generar.component';

describe('DatosFinanEconomGenerarComponent', () => {
  let component: DatosFinanEconomGenerarComponent;
  let fixture: ComponentFixture<DatosFinanEconomGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosFinanEconomGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosFinanEconomGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
