import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProjectService } from '../../../../../_services/project.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Message } from 'primeng/primeng';
import { MessageService } from 'primeng/components/common/messageservice';
import { SettingsService } from '../../../../../_services/setting.service';
import { FileService } from '../../../../../_services/file.service';

@Component({
    selector: 'app-project-edit',
    templateUrl: './project-edit.component.html',
    styleUrls: [
        './project-edit.css'
    ]
})
export class ProjectEditComponent implements OnInit {

    public baseUrl = this.settingService._admin;
    public success = { severity: 'success', summary: 'Thêm Dự Án Thành Công', detail: 'Thành Công' };
    public fail = { severity: 'error', summary: 'Xóa Dự Án Thất Bại', detail: 'Thất Bại' };
    public msgs: Message[];

    public projectCategories: any[];

    public editProject: EditProject = {
        id: 0,
        title: '',
        investor: '',
        efficiency: '',
        standard: '',
        progress: '',
        description: '',
        projectCategoryId: 0,
        projectCategoryName: '',
        files: [],
        fileModels: []
    };

    public projectForm = new FormGroup({
        title: new FormControl(this.editProject.title, [Validators.required]),
        investor: new FormControl(this.editProject.investor, [Validators.required]),
        efficiency: new FormControl(this.editProject.efficiency, [Validators.required]),
        standard: new FormControl(this.editProject.standard, [Validators.required]),
        progress: new FormControl(this.editProject.progress, [Validators.required]),
        description: new FormControl(this.editProject.description, [])
    });

    constructor(public projectService: ProjectService,
        public router: Router,
        public route: ActivatedRoute,
        private messageService: MessageService,
        public settingService: SettingsService,
        public fileService: FileService) {
        this.route.params.subscribe(params => this.getProject(params["id"]));
    }

    ngOnInit() {
        this.getProjectCategories();
    }

    onUploadFile(files : FileList) {
        for(var i = 0; i< files.length; i++){
           this.editProject.files.push(this.fileService.convertToFileModel(files[i]));
        }
    }

    getProjectCategories(){
        this.projectService.getProjectCategories().subscribe(data => {
            this.projectCategories = data;
        });
    }

    getProject(id) {
        this.projectService.getProjectById(id).subscribe(data => {
            this.editProject = data;
            console.log(this.editProject);
        });
    }

    save() {
        if (!this.projectForm.valid)
            return;
        this.projectService.editProject(this.editProject).subscribe(data => {
            this.messageService.add(this.success);
            setTimeout(() => {
                this.router.navigateByUrl("/du-an/danh-sach");
            }, 500);
        });
    }

    selectProjectCategory(projectCategory) {
        this.editProject.projectCategoryId = projectCategory.id;
        this.editProject.projectCategoryName = projectCategory.name;
    }

}
