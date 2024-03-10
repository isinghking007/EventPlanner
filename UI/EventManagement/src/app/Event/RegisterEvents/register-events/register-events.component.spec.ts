import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterEventsComponent } from './register-events.component';

describe('RegisterEventsComponent', () => {
  let component: RegisterEventsComponent;
  let fixture: ComponentFixture<RegisterEventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterEventsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegisterEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
