import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { users } from '../Models/users.model';
import { login } from '../Models/login.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { eventDetails } from '../Models/eventDetails.model';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  url="http://localhost:5222/api/"

  currentUser:BehaviorSubject<any>=new BehaviorSubject(null);
  jwtHelperService=new JwtHelperService();

  constructor(private http:HttpClient) {
    
   }

   
   //#region Get Methods

   getSingleUserDetail(email:string):Observable<users>
   {
    return this.http.get<users>(this.url+"home/userDetail/"+email);
   }
   getUserDetails():Observable<users>{
    return this.http.get<users>(this.url+"home/userDetails");
   }

   getUserCreatedEvent(userId:number):Observable<eventDetails>
   {
    return this.http.get<eventDetails>(this.url+"Event/eventDetails/"+userId)
   }
   //#endregion Get Methods
   //#region Post Methods
   registerUser(user:users):Observable<users>{
    return this.http.post<users>(this.url+"home/AddUsers",user);
   }

   loginUser(login:login):Observable<login>{
    return this.http.post<login>(this.url+"home/login",login,{responseType:'text' as 'json'});
   }
   //#endregion Post Methods
//#region Local Storage Related Methods
   setToken(token:string)
   {
    localStorage.setItem("access_item",token);
   }
   loadCurrentUser()
   {
    const token=localStorage.getItem("access_item");
    const userInfo=token!=null?this.jwtHelperService.decodeToken(token):null;
    const data=userInfo?{
      loginId:userInfo.LoginId,
      Email:userInfo.email
    }:null;
    this.currentUser.next(data);
    return data;
   }

   isLoggedIn():boolean{
    return localStorage.getItem("access_item")?true:false;
  }
  removeToken(){
    localStorage.removeItem("access_item");
    location.reload();
  }
  //#endregion Local Storage Related Methods
}
