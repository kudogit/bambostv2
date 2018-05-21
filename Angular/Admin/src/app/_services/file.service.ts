import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { SettingsService } from "./setting.service";

@Injectable()
export class FileService {

  constructor(private http: HttpClient,
              private settings: SettingsService) { }

  convertToFileModel(file: File){
    var result = {
        name: file.name,
        value: ''
    };
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        result.value = reader.result
    };

    return result;
  }

  removeFile(id: number): any{
    return this.http.delete(this.settings.admin + 'api/files/remove/' + id)
    .map(res => { return res })
    .catch(err => Observable.throw(err.json()));
  }

}
