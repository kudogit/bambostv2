import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SettingsService } from './setting.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { HttpInterceptor } from './handle.service';
@Injectable()
export class ConfigurationService {
    constructor(
        public http: HttpInterceptor,
        private setting: SettingsService) {

    }

    configGeneralInfo(model: Configuration): Observable<any> {
        return this.http.post(this.setting.admin + 'api/configuration/general-info', model)
            .map(res => { return res.json() })
    }

    getGeneralInfo(): Observable<Configuration> {
        return this.http.get(this.setting.admin + 'api/configuration/get-general-info')
            .map(res => { return res.json() })
    }

}