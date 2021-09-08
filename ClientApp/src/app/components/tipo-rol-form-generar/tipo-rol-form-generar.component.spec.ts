import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoRolFormGenerarComponent } from './tipo-rol-form-generar.component';

describe('TipoRolFormGenerarComponent', () => {
  let component: TipoRolFormGenerarComponent;
  let fixture: ComponentFixture<TipoRolFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoRolFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoRolFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
