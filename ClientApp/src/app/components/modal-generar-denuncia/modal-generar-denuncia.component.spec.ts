import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ModalGenerarDenunciaComponent } from './modal-generar-denuncia.component';

describe('ModalGenerarDenunciaComponent', () => {
  let component: ModalGenerarDenunciaComponent;
  let fixture: ComponentFixture<ModalGenerarDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalGenerarDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalGenerarDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
