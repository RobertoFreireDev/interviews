import { TestBed } from '@angular/core/testing';

import { ResultadostrimestraisService } from './resultadostrimestrais-firebase.service';

describe('ResultadostrimestraisService', () => {
  let service: ResultadostrimestraisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResultadostrimestraisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
