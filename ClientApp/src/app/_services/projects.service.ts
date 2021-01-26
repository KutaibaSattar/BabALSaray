import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Project } from '../_models/Project';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  baseUrl = environment.apiUrl;

  constructor(private httpClient : HttpClient ) { }


  getAllProjects() : Observable<Project[]>{

   return this.httpClient.get<Project[]>(this.baseUrl + 'projects')

  }

  AddProject(project: Project) : Observable<Project>{

    return this.httpClient.put<Project>(this.baseUrl + 'projects',project)
 
   }


}
