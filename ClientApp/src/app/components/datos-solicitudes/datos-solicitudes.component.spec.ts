import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosSolicitudesComponent } from './datos-solicitudes.component';

describe('DatosSolicitudesComponent', () => {
  let component: DatosSolicitudesComponent;
  let fixture: ComponentFixture<DatosSolicitudesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosSolicitudesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosSolicitudesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
