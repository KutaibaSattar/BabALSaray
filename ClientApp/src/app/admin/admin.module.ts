import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from 'src/app/admin/dashboard/dashboard.component';
import { MyProfileComponent } from 'src/app/admin/my-profile/my-profile.component';
import { DashboardService } from 'src/app/_services/dashboard.service';
import { ProjectsComponent } from './projects/projects.component';



@NgModule({
  declarations: [
    DashboardComponent,
    MyProfileComponent,
    ProjectsComponent,
  ],
  imports: [ CommonModule ],
  exports: [DashboardComponent,MyProfileComponent,ProjectsComponent ],
  providers: [DashboardService],
})
export class AdminModule { }
