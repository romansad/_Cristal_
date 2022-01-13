import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosTerritorioUrbanismoComponent } from './datos-territorio-urbanismo.component';

describe('DatosTerritorioUrbanismoComponent', () => {
  let component: DatosTerritorioUrbanismoComponent;
  let fixture: ComponentFixture<DatosTerritorioUrbanismoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosTerritorioUrbanismoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosTerritorioUrbanismoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
