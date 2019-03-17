import { TestBed, inject } from '@angular/core/testing';

import { ServSubscriptionService } from './serv-subscription.service';

describe('ServSubscriptionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServSubscriptionService]
    });
  });

  it('should be created', inject([ServSubscriptionService], (service: ServSubscriptionService) => {
    expect(service).toBeTruthy();
  }));
});
