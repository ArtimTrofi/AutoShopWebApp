import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCarComponent } from './show-car.component';

describe('ShowCarComponent', () => {
  let component: ShowCarComponent;
  let fixture: ComponentFixture<ShowCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowCarComponent]
    });
    fixture = TestBed.createComponent(ShowCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
