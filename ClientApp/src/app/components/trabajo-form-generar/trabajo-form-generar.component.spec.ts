import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrabajoFormGenerarComponent } from './trabajo-form-generar.component';

describe('TrabajoFormGenerarComponent', () => {
  let component: TrabajoFormGenerarComponent;
  let fixture: ComponentFixture<TrabajoFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrabajoFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrabajoFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
