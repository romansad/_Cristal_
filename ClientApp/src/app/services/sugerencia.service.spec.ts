import { TestBed, inject } from '@angular/core/testing';

import { SugerenciaService } from './sugerencia.service';

describe('SugerenciaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SugerenciaService]
    });
  });

  it('should be created', inject([SugerenciaService], (service: SugerenciaService) => {
    expect(service).toBeTruthy();
  }));
});
