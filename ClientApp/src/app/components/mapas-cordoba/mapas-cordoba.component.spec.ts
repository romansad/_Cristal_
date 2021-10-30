import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapasCordobaComponent } from './mapas-cordoba.component';

describe('MapasCordobaComponent', () => {
  let component: MapasCordobaComponent;
  let fixture: ComponentFixture<MapasCordobaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapasCordobaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapasCordobaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
