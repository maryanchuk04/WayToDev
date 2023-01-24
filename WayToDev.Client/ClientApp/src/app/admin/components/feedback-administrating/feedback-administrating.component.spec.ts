import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackAdministratingComponent } from './feedback-administrating.component';

describe('FeedbackAdministratingComponent', () => {
  let component: FeedbackAdministratingComponent;
  let fixture: ComponentFixture<FeedbackAdministratingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeedbackAdministratingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeedbackAdministratingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
