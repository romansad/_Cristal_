import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReclamoTrabajoFormComponent } from './reclamo-trabajo-form.component';

describe('ReclamoTrabajoFormComponent', () => {
  let component: ReclamoTrabajoFormComponent;
  let fixture: ComponentFixture<ReclamoTrabajoFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReclamoTrabajoFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReclamoTrabajoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
