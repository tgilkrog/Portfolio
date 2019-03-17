import { TestBed, inject } from '@angular/core/testing';

import { ServUserService } from './serv-user.service';

describe('ServUserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServUserService]
    });
  });

  it('should be created', inject([ServUserService], (service: ServUserService) => {
    expect(service).toBeTruthy();
  }));
});
