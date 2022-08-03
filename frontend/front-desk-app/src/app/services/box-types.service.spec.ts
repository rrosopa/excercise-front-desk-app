import { TestBed } from '@angular/core/testing';

import { BoxTypesService } from './box-types.service';

describe('BoxTypesService', () => {
  let service: BoxTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BoxTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
