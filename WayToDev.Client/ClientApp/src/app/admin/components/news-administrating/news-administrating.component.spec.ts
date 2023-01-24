import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsAdministratingComponent } from './news-administrating.component';

describe('NewsAdministratingComponent', () => {
  let component: NewsAdministratingComponent;
  let fixture: ComponentFixture<NewsAdministratingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsAdministratingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewsAdministratingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
