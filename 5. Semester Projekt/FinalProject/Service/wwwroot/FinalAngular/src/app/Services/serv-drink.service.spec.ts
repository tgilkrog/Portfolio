import { TestBed, inject } from '@angular/core/testing';

import { ServDrinkService } from './serv-drink.service';

describe('ServDrinkService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServDrinkService]
    });
  });

  it('should be created', inject([ServDrinkService], (service: ServDrinkService) => {
    expect(service).toBeTruthy();
  }));
});
