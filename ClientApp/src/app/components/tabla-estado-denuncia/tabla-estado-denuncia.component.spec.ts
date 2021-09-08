import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaEstadoDenunciaComponent } from './tabla-estado-denuncia.component';

describe('TablaEstadoDenunciaComponent', () => {
  let component: TablaEstadoDenunciaComponent;
  let fixture: ComponentFixture<TablaEstadoDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaEstadoDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaEstadoDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
