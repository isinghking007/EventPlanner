import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from './User/user/user.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,UserComponent,MatSidenavModule,ReactiveFormsModule,FormsModule,CommonModule,MatTableModule],
  providers:[DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'EventManagement';
}
