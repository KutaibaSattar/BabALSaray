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
    if (this.save.nativeElement.innerHTML = 'Delete') {

      this.projectService.DeleteProject(this.newProject.id);

      return;

    }

    if (this.newProject.id > 0) {
      this.projectService.UpdateProject(this.newProject).subscribe(
        (response) => {console.log(response); }
      );
      return;
    }



    this.projectService.InsertProject(this.newProject).subscribe(

      (response) => {this.projects.push(response);

      this.resetingProject(); },
      (error) => { console.log(error); }
      );

  }

  onEditClick(event, index: number) {
    const target = event.target.id;
   this.save.nativeElement.innerHTML = 'Delete';
   this.model.nativeElement.innerHTML = 'Delete';
   this.project.nativeElement.disabled = true;

   this.save.nativeElement.className = 'btn btn-danger';
   console.log(this.model , this.date );



   /*  modal.find('.modal-title').text('New message to ' + recipient)
    modal.find('.modal-body input').val(recipient) */
   this.newProject = this.projects.find(p => p.id === (index));


  }

   resetingProject() {
    this.newProject.name = null;
    this.newProject.startingDate = null;
    this.newProject.teamSize = null;
  }

}
