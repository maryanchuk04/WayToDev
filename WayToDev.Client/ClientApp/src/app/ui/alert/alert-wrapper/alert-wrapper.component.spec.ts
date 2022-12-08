import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertWrapperComponent } from './alert-wrapper.component';

describe('AlertWrapperComponent', () => {
  let component: AlertWrapperComponent;
  let fixture: ComponentFixture<AlertWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlertWrapperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
