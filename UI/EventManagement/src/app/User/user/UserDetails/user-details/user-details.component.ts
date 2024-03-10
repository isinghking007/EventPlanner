import { Component, OnInit } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { CommonService } from '../../../../Services/common.service';
import { users } from '../../../../Models/users.model';
@Component({
  selector: 'app-user-details',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.css'
})
export class UserDetailsComponent implements OnInit {

  dataSource!:any[];
  displayedColumns:string[]=["userId","First Name","Last Name","Email","Phone"];
  workingArray!:any[];
  emailID:string="";
  userDetails:any//MatTableDataSource<users>;
  constructor(private services : CommonService){}

  ngOnInit(): void {
   this.allUserDetails();
  }
  
  allUserDetails(){
    this.emailID=this.services.loadCurrentUser()?.Email;
    this.services.getSingleUserDetail(this.emailID).subscribe((val:any)=>{
      
      this.userDetails=val;

     this.workingArray=val.$values;
     this.dataSource=this.workingArray;
      console.log('before',val);
      console.log('working',this.workingArray);
      console.log('after',this.userDetails)
      console.log(typeof(this.userDetails))
   
  });
    }
  
}
