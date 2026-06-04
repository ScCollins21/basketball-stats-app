import { TestBed } from '@angular/core/testing';

import { BasketballApi } from './basketball-api';

describe('BasketballApi', () => {
  let service: BasketballApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BasketballApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
