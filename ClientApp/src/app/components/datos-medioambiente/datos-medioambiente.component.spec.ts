import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosMedioambienteComponent } from './datos-medioambiente.component';

describe('DatosMedioambienteComponent', () => {
  let component: DatosMedioambienteComponent;
  let fixture: ComponentFixture<DatosMedioambienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosMedioambienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosMedioambienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
