import { Component, OnInit } from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import { RouterModule,Router } from '@angular/router';
import { CommonService } from '../../Services/common.service';


@Component({
  selector: 'app-user',
  standalone: true,
  imports: [MatSidenavModule,RouterModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit{

  leftPanelItems:string[]=['Register','Login','User Details','Add Events','All Events'];
  constructor(private router:Router,private services:CommonService){}

  ngOnInit(): void {
   // this.services.getUserDetails().subscribe(data=>{console.log(data)})
    console.log(this.route);
  }

  route:string="";
  onClick(pageURL:string)
  {
    
    switch(pageURL)
    {
      case 'Register':
        this.navigateTo("/user/register");break;
      case 'Login':
        this.navigateTo("/user/login");break;
      case 'User Details':
        this.navigateTo("/user/userDetails");break;
      case 'Add Events':
        this.navigateTo("/event/registerevent");break;
      case 'All Events':
        this.navigateTo("/event");break;
    }
      
  }
  navigateTo(route:string)
  {
    this.router.navigateByUrl(route);
  }
}
