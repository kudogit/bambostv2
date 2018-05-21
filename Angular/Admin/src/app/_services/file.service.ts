import { Injectable } from "@angular/core";

@Injectable()
export class FileService {

  constructor() { }

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

}
