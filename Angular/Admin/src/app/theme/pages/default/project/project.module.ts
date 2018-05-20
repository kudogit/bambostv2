import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProjectComponent } from './project.component';
import { DefaultComponent } from '../default.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { ProjectCreateComponent } from './project-create/project-create.component';
import { FileUploadModule, DropdownModule, EditorModule, ConfirmationService } from 'primeng/primeng';
import { ProjectListComponent } from './project-list/project-list.component';
import { GrowlModule } from 'primeng/primeng';
import { ConfirmDialogModule } from 'primeng/primeng';
import { DataTableModule } from 'primeng/primeng';
import { ProjectEditComponent } from './project-edit/project-edit.component';
import { ProjectService } from '../../../../_services/project.service';
import { MessageService } from 'primeng/components/common/messageservice';
import { FileService } from '../../../../_services/file.service';
const routes: Routes = [
    {
        path: "",
        component: DefaultComponent,
        children: [
            {
                path: "",
                component: ProjectComponent,
                children: [
                    { path: 'danh-sach/tao-moi', component: ProjectCreateComponent },
                    { path: 'danh-sach/:id', component: ProjectEditComponent },
                    { path: 'danh-sach', component: ProjectListComponent },
                ]
            }
        ]
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        LayoutModule,
        FileUploadModule,
        DropdownModule,
        GrowlModule,
        ConfirmDialogModule,
        DataTableModule,
        EditorModule
    ],
    declarations: [
        ProjectComponent, ProjectListComponent, ProjectCreateComponent, ProjectEditComponent
    ],
    providers: [
        ProjectService, MessageService, ConfirmationService, FileService
    ]
})

export class ProjectModule {

}