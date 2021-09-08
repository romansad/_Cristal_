import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaTipoDenunciaComponent } from './tabla-tipo-denuncia.component';

describe('TablaTipoDenunciaComponent', () => {
  let component: TablaTipoDenunciaComponent;
  let fixture: ComponentFixture<TablaTipoDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaTipoDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaTipoDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
