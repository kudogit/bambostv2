import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SettingsService } from './setting.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class ProjectService {
    
    constructor(
        private http: HttpClient,
        private setting: SettingsService) {

    }

    createProjectCategory(model: CreateProjectCategory): Observable<any> {
        return this.http.post(this.setting.admin + 'api/project/category/create', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getProjectCategories(): Observable<ProjectCategory[]> {
        return this.http.get(this.setting.admin + 'api/project/category/gets')
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    deleteProjectCategory(id: number): Observable<any> {
        return this.http.delete(this.setting.admin + 'api/project/category/delete/' + id)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    editProjectCategory(model: ProjectCategory): Observable<any> {
        return this.http.put(this.setting.admin + 'api/project/category/update', model)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }


    createProject(model: Project): Observable<number> {
        var header = new HttpHeaders();
        header.append('Content-Type', 'multipart/form-data');
        return this.http.post(this.setting.admin + 'api/project/create', model, { headers : header })
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getProjects(): Observable<Project[]> {
        return this.http.get(this.setting.admin + 'api/project/getall')
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    deleteProject(id: number): any {
        return this.http.delete(this.setting.admin + 'api/project/delete/' + id)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    editProject(model: Project): any {
        var header = new HttpHeaders();
        header.append('Content-Type', 'multipart/form-data');
        return this.http.put(this.setting.admin + 'api/project/edit/', model, { headers: header })
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getProjectById(id: any): any {
        return this.http.get(this.setting.admin + 'api/project/' + id)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

}