import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/_models/Project';
import { ProjectsService } from 'src/app/_services/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  projects: Project[];
  newProject: Project = new Project();
  editProject : Project = new Project();
  constructor(private projectService: ProjectsService) { }


  ngOnInit(): void {

    
   this.projectService.getAllProjects().subscribe(
    (response: Project[] ) => {
      this.projects = response;
    }
   );
  }
  onSaveClick() {

    this.projectService.InsertProject(this.newProject).subscribe(
      (response) => {this.projects.push(response);
      this.newProject.name = null;
      this.newProject.startingDate = null
      this.newProject.teamSize = null },
      (error) => { console.log(error); }
      );

  }

  onEditClick(event, index:number)
  {
    this.editProject = this.projects.find(p => p.id = index)
    
  }

  onUpdateClick(){


  }

}
