import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonService } from '../../../../Services/common.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  Login:FormGroup
  loggedIn:boolean=true;
  constructor(private fb:FormBuilder,private service:CommonService){
    this.Login=this.fb.group({
      Email:new FormControl('',[Validators.required]),
      Password:new FormControl('',[Validators.required])
    })
  }
  ngOnInit(): void {
    console.log("jwt token",this.service.loadCurrentUser())
    console.log(this.service.isLoggedIn());
    this.loggedIn=this.service.isLoggedIn();
  }
  loginForm()
  {
    console.log("login value",this.Login.value);
    this.service.loginUser(this.Login.value).subscribe(val=>{
      console.log("Login user",val);
      this.service.setToken(val.toString());
    })
    this.Login.reset();
    console.log("login value after reset",this.Login.value);
  }

  logOut()
  {
    this.service.removeToken();
    console.log('logout');
  }

}
