import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaDenunciaComponent } from './tabla-denuncia.component';

describe('TablaDenunciaComponent', () => {
  let component: TablaDenunciaComponent;
  let fixture: ComponentFixture<TablaDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
