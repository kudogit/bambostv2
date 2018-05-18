import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SettingsService } from './setting.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class AboutService {
    constructor(
        private http: HttpClient,
        private setting: SettingsService) {

    }
    createAbout(about): Observable<CreateAbout> {
        return this.http.post(this.setting.admin + 'api/about/create', about)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    getAbouts(): Observable<any[]> {
        return this.http.get(this.setting.admin + 'api/about/abouts')
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }

    updateAbout(about): Observable<any> {
        return this.http.put(this.setting.admin + 'api/about/update', about)
            .map(res => { return res })
            .catch(err => Observable.throw(err.json()));
    }
}