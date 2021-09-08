import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoRolTablaComponent } from './tipo-rol-tabla.component';

describe('TipoRolTablaComponent', () => {
  let component: TipoRolTablaComponent;
  let fixture: ComponentFixture<TipoRolTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoRolTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoRolTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
