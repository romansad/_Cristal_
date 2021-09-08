import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReclamoFormGenerarComponent } from './reclamo-form-generar.component';

describe('ReclamoFormGenerarComponent', () => {
  let component: ReclamoFormGenerarComponent;
  let fixture: ComponentFixture<ReclamoFormGenerarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReclamoFormGenerarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReclamoFormGenerarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
