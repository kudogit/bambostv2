import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { ProjectService } from '../../../../../_services/project.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'app-project-create',
    templateUrl: './project-create.component.html',
    styleUrls: [
        'project-create.css'
    ]
})
export class ProjectCreateComponent implements OnInit {

    @Output() reloadProjects = new EventEmitter<any>();
    @ViewChild('cancelBtn') cancelBtn: ElementRef;

    public projectCategories: ProjectCategory[];

    public selectedProjectCategory: ProjectCategory = {
        id: 0,
        name: '',
        isEdit: false
    };

    public newProject: Project = {
        id: 0,
        title: '',
        investor: '',
        efficiency: '',
        standard: '',
        progress: '',
        description: '',
        projectCategoryId: 0,
        projectCategoryName: ''
    };

    public projectForm = new FormGroup({
        title: new FormControl(this.newProject.title, [Validators.required]),
        investor: new FormControl(this.newProject.investor, [Validators.required]),
        efficiency: new FormControl(this.newProject.efficiency, [Validators.required]),
        standard: new FormControl(this.newProject.standard, [Validators.required]),
        progress: new FormControl(this.newProject.progress, [Validators.required]),
        description: new FormControl(this.newProject.description, []),
        resetBtn: new FormControl()
    });

    uploadedFiles: any[] = [];

    constructor(public projectService: ProjectService) { }

    ngOnInit() {
        this.getProjectCategories();
    }


    onUploadFile(event) {
        console.log(event.files);
    }

    saveImage() {
        console.log(this.uploadedFiles);
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
        this.projectService.createProject(this.newProject).subscribe(data => {
            this.reloadProjects.emit(null);
            this.cancelBtn.nativeElement.click();
        });
    }

    resetForm() {
        this.projectForm.reset();
    }

}
