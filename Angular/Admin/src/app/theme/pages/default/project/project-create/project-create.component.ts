import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { ProjectService } from '../../../../../_services/project.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/primeng';
import { FileService } from '../../../../../_services/file.service';

@Component({
    selector: 'app-project-create',
    templateUrl: './project-create.component.html',
    styleUrls: [
        'project-create.css'
    ]
})
export class ProjectCreateComponent implements OnInit {

    public success = { severity: 'success', summary: 'Thêm Dự Án Thành Công', detail: 'Thành Công' };
    public fail = { severity: 'error', summary: 'Thêm Dự Án Thất Bại', detail: 'Thất Bại' };
    public msgs: Message[];
    public projectCategories: ProjectCategory[];

    public selectedProjectCategory: ProjectCategory = {
        id: 0,
        name: '',
        isEdit: false
    };

    public newProject: CreateProject = {
        id: 0,
        title: '',
        investor: '',
        efficiency: '',
        standard: '',
        progress: '',
        description: '',
        projectCategoryId: 0,
        projectCategoryName: '',
        files: []
    };

    public projectForm = new FormGroup({
        title: new FormControl(this.newProject.title, [Validators.required]),
        investor: new FormControl(this.newProject.investor, [Validators.required]),
        efficiency: new FormControl(this.newProject.efficiency, [Validators.required]),
        standard: new FormControl(this.newProject.standard, [Validators.required]),
        progress: new FormControl(this.newProject.progress, [Validators.required]),
        description: new FormControl(this.newProject.description, [])
    });

    constructor(public projectService: ProjectService,
    public router: Router,
    private messageService: MessageService,
    public fileService: FileService) { }

    ngOnInit() {
        this.getProjectCategories();
    }


    onUploadFile(files : FileList) {
        for(var i = 0; i< files.length; i++){
           this.newProject.files.push(this.fileService.convertToFileModel(files[i]));
        }
    }

    getProjectCategories() {
        this.projectService.getProjectCategories().subscribe(data => {
            this.projectCategories = data;
            this.projectCategories.forEach(element => {
                element.isEdit = false
            });
            this.selectedProjectCategory = this.projectCategories[0];
            this.newProject.projectCategoryId = this.selectedProjectCategory.id;
        });
    }

    selectProjectCategory(projectCategory) {
        this.selectedProjectCategory = projectCategory;
        this.newProject.projectCategoryId = this.selectedProjectCategory.id;
    }

    addNewProject(event) {
        debugger;
        this.projectService.createProject(this.newProject).subscribe(data => {
            this.messageService.add(this.success);
            setTimeout(() => {
            this.router.navigateByUrl("/du-an/danh-sach");
            }, 1000);
        },
        error => {
            this.messageService.add(this.fail);
        });
    }
}
