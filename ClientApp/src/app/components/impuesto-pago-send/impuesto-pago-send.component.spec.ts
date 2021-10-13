import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpuestoPagoSendComponent } from './impuesto-pago-send.component';

describe('ImpuestoPagoSendComponent', () => {
  let component: ImpuestoPagoSendComponent;
  let fixture: ComponentFixture<ImpuestoPagoSendComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpuestoPagoSendComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpuestoPagoSendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
