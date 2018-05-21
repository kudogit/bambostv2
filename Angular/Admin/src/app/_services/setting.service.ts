import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SettingsService {

    public _admin = 'http://localhost:56310/';

    private _FORMATDATETIME = "dd/MM/yyyy";
    public get FORMATDATETIME() { return this._FORMATDATETIME; }

    private _FORMATDATEMOMENT = "DD/MM/YYYY HH:mm:ss";
    public get FORMATDATE_MOMENT() { return this._FORMATDATEMOMENT; }

    public get admin() { return this._admin; }
}


