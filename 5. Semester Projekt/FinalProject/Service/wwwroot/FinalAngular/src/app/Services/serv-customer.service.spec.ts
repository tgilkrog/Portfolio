import { TestBed, inject } from '@angular/core/testing';

import { ServCustomerService } from './serv-customer.service';

describe('ServCustomerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServCustomerService]
    });
  });

  it('should be created', inject([ServCustomerService], (service: ServCustomerService) => {
    expect(service).toBeTruthy();
  }));
});
