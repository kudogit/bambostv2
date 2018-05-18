import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProjectService } from '../../../../_services/project.service';

@Component({
    selector: 'app-product-management',
    templateUrl: './product-management.component.html',
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent implements OnInit {

    constructor(public projectService: ProjectService) { }

    ngOnInit() {
        this.getProjectCategories();
        this.getProjects();
    }

    public projectCategories: ProjectCategory[] = [];
    public projectCategoryModel: CreateProjectCategory = {
        name: ''
    }

    filter: any;
    public isAddNewProjectCategory: boolean = false;
    public editProject: Project;
    public projects: Project[] = [];

    createProjectCategery() {
        this.projectService.createProjectCategory(this.projectCategoryModel).subscribe(data => {
            if (data != undefined) {
                this.projectCategories.push({
                    id: data,
                    name: this.projectCategoryModel.name,
                    isEdit: false
                });
                this.projectCategoryModel.name = '';
            }
        })
    }

    deleteProjectCategory(id) {
        this.projectService.deleteProjectCategory(id).subscribe(data => {
            this.getProjectCategories();
        })
    }

    editProjectCategory(item) {
        this.projectService.editProjectCategory(item).subscribe(data => {
            this.getProjectCategories();
        })
    }

    getProjectCategories() {
        this.projectService.getProjectCategories().subscribe(data => {
            this.projectCategories = data;
            this.projectCategories.forEach(element => {
                element.isEdit = false
            });
        });
    }

    getProjects() {
        this.projectService.getProjects().subscribe(data => {
            this.projects = data;
        })
    }
}
