import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BienvenidaVecinoComponent } from './bienvenida-vecino.component';

describe('BienvenidaVecinoComponent', () => {
  let component: BienvenidaVecinoComponent;
  let fixture: ComponentFixture<BienvenidaVecinoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BienvenidaVecinoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BienvenidaVecinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
