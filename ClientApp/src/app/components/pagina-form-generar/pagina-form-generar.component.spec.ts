import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginaFormGenerarComponent } from './pagina-form-generar.component';

describe('PaginaFormGenerarComponent', () => {
  let component: PaginaFormGenerarComponent;
  let fixture: ComponentFixture<PaginaFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaginaFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginaFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
