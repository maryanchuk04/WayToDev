import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersAdministratingComponent } from './users-administrating.component';

describe('UsersAdministratingComponent', () => {
  let component: UsersAdministratingComponent;
  let fixture: ComponentFixture<UsersAdministratingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersAdministratingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersAdministratingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
