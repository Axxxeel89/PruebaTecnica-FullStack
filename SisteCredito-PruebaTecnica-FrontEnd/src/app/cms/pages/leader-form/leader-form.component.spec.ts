import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderFormComponent } from './leader-form.component';

describe('LeaderFormComponent', () => {
  let component: LeaderFormComponent;
  let fixture: ComponentFixture<LeaderFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
