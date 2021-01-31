import { DatePipe } from '@angular/common';
import { ViewChild } from '@angular/core';
import { Component, ElementRef, OnInit } from '@angular/core';
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
  editProject: Project = new Project();
  today: string;
  action : string;
  constructor(private projectService: ProjectsService) { }


  @ViewChild('save') public save: ElementRef;
  @ViewChild('model') public model: ElementRef;
  @ViewChild('project') public project: ElementRef;
  @ViewChild('date') public date: ElementRef;
  @ViewChild('team') public team: ElementRef;

  ngOnInit(): void {

   this.projectService.getAllProjects().subscribe(
    (response: Project[] ) => {
      console.log(response);
      this.projects = response;
    }
   );
  }
  onSaveClick() {
   
   switch (this.action) {
     case 'delete':
      this.projectService.DeleteProject(this.newProject.id).subscribe(
        (response) => {
           var index = this.projects.findIndex(p => p.id === this.newProject.id);
            this.projects.splice(index,1);
            this.resetingProject();
        },
        (response) =>{
          console.log(response);

        }


      );

       break;
   
     case 'update':
      if (this.newProject.id > 0) {
        this.projectService.UpdateProject(this.newProject).subscribe(
          (response) => {console.log(response); }
        );
        return;
      }
       break;
      case 'insert':
        this.projectService.InsertProject(this.newProject).subscribe(

          (response) => {this.projects.push(response);
    
          this.resetingProject(); },
          (error) => { console.log(error); }
          );

   }
   
 }

  onEditClick(event, index: number, currentaction : string) {
   
    this.action = currentaction;

    switch (currentaction) {
      case 'insert':
        this.save.nativeElement.innerHTML = 'Save';
        this.model.nativeElement.innerHTML = 'Add a project';
        this.project.nativeElement.disabled = false;
        this.date.nativeElement.disabled = false;
        this.team.nativeElement.disabled = false;
        this.save.nativeElement.className = 'btn btn-info';
        
      break;

      case 'delete':
        this.save.nativeElement.innerHTML = 'Delete';
        this.model.nativeElement.innerHTML = 'Are you sure to delete This project';
        this.project.nativeElement.disabled = true;
        this.date.nativeElement.disabled = true;
        this.team.nativeElement.disabled = true;
        this.save.nativeElement.className = 'btn btn-danger';
        this.newProject = this.projects.find(p => p.id === (index));
      break;
    
      case 'update':
        this.save.nativeElement.innerHTML = 'Update';
        this.model.nativeElement.innerHTML = 'Update the project';
        this.project.nativeElement.disabled = false;
        this.date.nativeElement.disabled = false;
        this.team.nativeElement.disabled = false;
        this.save.nativeElement.className = 'btn btn-info';
        this.newProject = this.projects.find(p => p.id === (index));
      break;
    }
 
  


  }

   resetingProject() {
    this.newProject.id = null;
    this.newProject.name = null;
    this.newProject.startingDate = null;
    this.newProject.teamSize = null;
  }

}