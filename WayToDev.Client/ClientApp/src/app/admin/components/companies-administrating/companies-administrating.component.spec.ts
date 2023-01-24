import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompaniesAdministratingComponent } from './companies-administrating.component';

describe('CompaniesAdministratingComponent', () => {
  let component: CompaniesAdministratingComponent;
  let fixture: ComponentFixture<CompaniesAdministratingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompaniesAdministratingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompaniesAdministratingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
