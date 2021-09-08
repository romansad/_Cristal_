import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReclamoTrabajoTablaComponent } from './reclamo-trabajo-tabla.component';

describe('ReclamoTrabajoTablaComponent', () => {
  let component: ReclamoTrabajoTablaComponent;
  let fixture: ComponentFixture<ReclamoTrabajoTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReclamoTrabajoTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReclamoTrabajoTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
