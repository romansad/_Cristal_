import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosSugerenciasComponent } from './datos-sugerencias.component';

describe('DatosSugerenciasComponent', () => {
  let component: DatosSugerenciasComponent;
  let fixture: ComponentFixture<DatosSugerenciasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosSugerenciasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosSugerenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
