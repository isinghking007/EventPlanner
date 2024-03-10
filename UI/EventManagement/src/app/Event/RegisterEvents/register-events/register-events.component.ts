import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-register-events',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  providers:[DatePipe],
  templateUrl: './register-events.component.html',
  styleUrl: './register-events.component.css'
})
export class RegisterEventsComponent implements OnInit {
  currentDate: Date = new Date();
  RegisterEvent: FormGroup;
  IsEndDateEditiable:boolean=true;

  constructor(private fb: FormBuilder, private datePipe: DatePipe) {
    this.RegisterEvent = this.fb.group({
      EventName: new FormControl('', [Validators.required]),
      EventPeriod: new FormControl('', [Validators.required]),
      StartDate: new FormControl('', [Validators.required]),
      Enddate: new FormControl('',[Validators.required]),
      Description: new FormControl('', [Validators.required])
    });
  }

  ngOnInit(): void {
    console.log(this.currentDate.getDate() + 5);
    this.RegisterEvent.get('EventPeriod')?.valueChanges.subscribe(() => this.calculateSecondDate());
    this.RegisterEvent.get('StartDate')?.valueChanges.subscribe(() => this.calculateSecondDate());
  }

  calculateSecondDate() {
    const eventPeriod = this.RegisterEvent.get('EventPeriod')?.value;
    const startDate = this.RegisterEvent.get('StartDate')?.value;
    if (eventPeriod && startDate) {
      const firstDate = new Date(startDate);
      const secondDate = new Date(firstDate.getTime() + (eventPeriod * 24 * 60 * 60 * 1000));
      const formattedSecondDate = this.datePipe.transform(secondDate, 'yyyy-MM-dd');
      this.RegisterEvent.get('Enddate')?.setValue(formattedSecondDate);
      this.IsEndDateEditiable=false;
    }
  }

  submitEvent() {
  //  this.calculateSecondDate(); // Ensure Enddate is calculated before submitting
  console.log('Enddate:', this.RegisterEvent.get('Enddate')?.value);
  this.RegisterEvent.get('Enddate')?.setValue(this.RegisterEvent.get('Enddate')?.value);
  console.log('Enddate:', this.RegisterEvent.get('Enddate')?.value);
    console.log(this.RegisterEvent.value);
    this.RegisterEvent.reset();
  }
}
