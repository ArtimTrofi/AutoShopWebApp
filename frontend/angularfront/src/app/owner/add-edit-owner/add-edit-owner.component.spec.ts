import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditOwnerComponent } from './add-edit-owner.component';

describe('AddEditOwnerComponent', () => {
  let component: AddEditOwnerComponent;
  let fixture: ComponentFixture<AddEditOwnerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditOwnerComponent]
    });
    fixture = TestBed.createComponent(AddEditOwnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
