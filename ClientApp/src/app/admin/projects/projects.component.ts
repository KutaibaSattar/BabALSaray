import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/_models/Project';
import { ProjectsService } from 'src/app/_services/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  projects : Project[]
  constructor(private projectService : ProjectsService) { }


  ngOnInit(): void {
    
   this.projectService.getAllProjects().subscribe(
    (response : Project[] ) => {
      this.projects = response;
    } 
   );
  }



}
