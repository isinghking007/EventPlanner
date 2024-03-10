import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../Services/common.service';
import { MatTableModule } from '@angular/material/table';
import { users } from '../../Models/users.model';
import { ifError } from 'assert';

@Component({
  selector: 'app-event',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './event.component.html',
  styleUrl: './event.component.css'
})
export class EventComponent implements OnInit{

  UserDetails!:any;
  dataSource!:any[];
  displayedColumns:string[]=['eventName','eventPeriod','eventStartDate','eventEndDate','eventDescription'];

  constructor(private service:CommonService){

  }
//phle load method se email id lena padega aur phir us email id se userid and es userid ko pass krne padega event
//detail ke liye
  ngOnInit(): void {
   
    this.getUserId();
    
  }

  getUserId():Promise<any>{
    var emailId=this.service.loadCurrentUser()?.Email;
    return new Promise((resolve,reject)=>{
      this.service.getSingleUserDetail(emailId).subscribe((val:any)=>{
        console.log(val);
        this.UserDetails=val.$values[0].userId;
        //console.log(this.UserDetails);
       // this.eventDetails();
      })
    })
   
     
  }

 async eventDetails():Promise<any>
  {
    try{
      //console.log(this.getUserId());
    this.service.getUserCreatedEvent(this.UserDetails).subscribe((val:any)=>{
      
      this.dataSource=val.$values;
      console.log(val);
    })
  }
  catch(error){console.error(error)}
}
}
