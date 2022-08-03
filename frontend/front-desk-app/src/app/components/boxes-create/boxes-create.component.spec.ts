import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxesCreateComponent } from './boxes-create.component';

describe('BoxesCreateComponent', () => {
  let component: BoxesCreateComponent;
  let fixture: ComponentFixture<BoxesCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoxesCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BoxesCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
