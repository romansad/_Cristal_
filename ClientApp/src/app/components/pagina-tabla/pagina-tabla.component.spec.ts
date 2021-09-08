import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginaTablaComponent } from './pagina-tabla.component';

describe('PaginaTablaComponent', () => {
  let component: PaginaTablaComponent;
  let fixture: ComponentFixture<PaginaTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaginaTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginaTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
