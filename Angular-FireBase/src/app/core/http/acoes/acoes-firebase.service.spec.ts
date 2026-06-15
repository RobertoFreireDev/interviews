import { TestBed } from '@angular/core/testing';

import { AcoesFirebaseService } from './acoes-firebase.service';

describe('AcoesFirebaseService', () => {
  let service: AcoesFirebaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AcoesFirebaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
