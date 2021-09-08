import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginVecinoComponent } from './login-vecino.component';

describe('LoginVecinoComponent', () => {
  let component: LoginVecinoComponent;
  let fixture: ComponentFixture<LoginVecinoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginVecinoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginVecinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
