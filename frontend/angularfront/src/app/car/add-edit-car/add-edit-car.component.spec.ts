import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCarComponent } from './add-edit-car.component';

describe('AddEditCarComponent', () => {
  let component: AddEditCarComponent;
  let fixture: ComponentFixture<AddEditCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditCarComponent]
    });
    fixture = TestBed.createComponent(AddEditCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
