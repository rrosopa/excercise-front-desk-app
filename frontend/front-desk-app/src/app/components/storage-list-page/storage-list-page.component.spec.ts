import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StorageListPageComponent } from './storage-list-page.component';

describe('StorageListPageComponent', () => {
  let component: StorageListPageComponent;
  let fixture: ComponentFixture<StorageListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StorageListPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StorageListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
