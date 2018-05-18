import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProjectComponent } from './project.component';
import { DefaultComponent } from '../default.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { ProjectCreateComponent } from './project-create/project-create.component';
import { FileUploadModule, DropdownModule } from 'primeng/primeng';

const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': ProjectComponent,
            },
        ],
    },
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        LayoutModule,
        FileUploadModule,
        DropdownModule
    ],
    declarations: [
        ProjectComponent,
    ]
})

export class ProjectModule {

}