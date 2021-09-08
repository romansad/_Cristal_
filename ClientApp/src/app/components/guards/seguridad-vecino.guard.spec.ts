import { TestBed, async, inject } from '@angular/core/testing';

import { SeguridadVecinoGuard } from './seguridad-vecino.guard';

describe('SeguridadVecinoGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SeguridadVecinoGuard]
    });
  });

  it('should ...', inject([SeguridadVecinoGuard], (guard: SeguridadVecinoGuard) => {
    expect(guard).toBeTruthy();
  }));
});
