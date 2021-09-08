import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltroDenunciaComponent } from './filtro-denuncia.component';

describe('FiltroDenunciaComponent', () => {
  let component: FiltroDenunciaComponent;
  let fixture: ComponentFixture<FiltroDenunciaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltroDenunciaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltroDenunciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
