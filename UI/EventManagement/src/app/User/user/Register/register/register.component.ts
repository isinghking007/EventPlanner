import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonService } from '../../../../Services/common.service';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{

  RegisterUser:FormGroup;

  constructor(private fb:FormBuilder,private service:CommonService){
    this.RegisterUser=fb.group({
      FirstName:new FormControl('',Validators.required),
      LastName:new FormControl('',Validators.required),
      Email:new FormControl('',Validators.required),
      Phone:new FormControl('',[Validators.required,Validators.minLength(10),Validators.maxLength(10)]),
      Password:new FormControl('',Validators.required)
    })
  }
  ngOnInit(): void {
    console.log("jwt token", this.service.loadCurrentUser());
  }

  formSubmit()
  {
    this.service.registerUser(this.RegisterUser.value).subscribe(val=>{
      console.log(val);
    })
    this.RegisterUser.reset();
    //console.log(this.RegisterUser.value);
  }
  loginDetails(){
    return false;
  }
}
