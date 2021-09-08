import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaTrabajoComponent } from './tabla-trabajo.component';

describe('TablaTrabajoComponent', () => {
  let component: TablaTrabajoComponent;
  let fixture: ComponentFixture<TablaTrabajoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaTrabajoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaTrabajoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
