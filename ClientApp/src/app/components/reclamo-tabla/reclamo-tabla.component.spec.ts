import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReclamoTablaComponent } from './reclamo-tabla.component';

describe('ReclamoTablaComponent', () => {
  let component: ReclamoTablaComponent;
  let fixture: ComponentFixture<ReclamoTablaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReclamoTablaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReclamoTablaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
