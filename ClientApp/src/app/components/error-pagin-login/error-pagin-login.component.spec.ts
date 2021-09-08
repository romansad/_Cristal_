import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrorPaginLoginComponent } from './error-pagin-login.component';

describe('ErrorPaginLoginComponent', () => {
  let component: ErrorPaginLoginComponent;
  let fixture: ComponentFixture<ErrorPaginLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ErrorPaginLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ErrorPaginLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
