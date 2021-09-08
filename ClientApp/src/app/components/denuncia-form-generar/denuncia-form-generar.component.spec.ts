import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DenunciaFormGenerarComponent } from './denuncia-form-generar.component';

describe('DenunciaFormGenerarComponent', () => {
  let component: DenunciaFormGenerarComponent;
  let fixture: ComponentFixture<DenunciaFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DenunciaFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DenunciaFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
