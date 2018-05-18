import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProjectEditComponent } from './project-edit.component';
import { DefaultComponent } from '../../default.component';
import { LayoutModule } from '../../../../layouts/layout.module';
import { ProjectService } from '../../../../../_services/project.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { DropdownModule, FileUploadModule, EditorModule } from 'primeng/primeng';

const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': ProjectEditComponent,
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
        HttpClientModule,
        Ng2SearchPipeModule,
        DropdownModule,
        FileUploadModule,
    ],
    declarations: [
        ProjectEditComponent,
    ],
    providers: [
        HttpClient,
        ProjectService
    ]
})

export class ProjectEditModule {

}