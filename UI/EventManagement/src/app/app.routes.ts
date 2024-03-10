import { Routes } from '@angular/router';
import { UserComponent } from './User/user/user.component';
import { RegisterComponent } from './User/user/Register/register/register.component';
import { LoginComponent } from './User/user/Login/login/login.component';
import { EventComponent } from './Event/event/event.component';
import { RegisterEventsComponent } from './Event/RegisterEvents/register-events/register-events.component';
import { UserDetailsComponent } from './User/user/UserDetails/user-details/user-details.component';

export const routes: Routes = [
    
    {
        'path':'user',component:UserComponent
    },
    {
        'path':'user',children:[
            {
                'path':'register',component:RegisterComponent
            },
            {
                'path':'login',component:LoginComponent
            },
            {
                'path':'userDetails',component:UserDetailsComponent
            }
        ]
    },
    {
        'path':'event',component:EventComponent
    },
    {
        'path':'event',children:[
            {
                'path':'registerevent',component:RegisterEventsComponent
            }
        ]
    }
];
