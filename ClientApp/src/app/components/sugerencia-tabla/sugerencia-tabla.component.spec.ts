import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SugerenciaTablaComponent } from './sugerencia-tabla.component';

describe('SugerenciaTablaComponent', () => {
  let component: SugerenciaTablaComponent;
  let fixture: ComponentFixture<SugerenciaTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SugerenciaTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SugerenciaTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
