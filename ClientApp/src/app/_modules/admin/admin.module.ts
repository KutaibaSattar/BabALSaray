import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from 'src/app/_modules/admin/dashboard/dashboard.component';
import { MyProfileComponent } from 'src/app/_modules/admin/my-profile/my-profile.component';
import { DashboardService } from 'src/app/_services/dashboard.service';



@NgModule({
  declarations: [
    DashboardComponent,
    MyProfileComponent,
  ],
  imports: [ CommonModule ],
  exports: [DashboardComponent, ],
  providers: [DashboardService],
})
export class AdminModule { }
