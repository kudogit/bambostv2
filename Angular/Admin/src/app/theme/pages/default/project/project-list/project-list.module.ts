import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProjectListComponent } from './project-list.component';
import { DefaultComponent } from '../../default.component';
import { LayoutModule } from '../../../../layouts/layout.module';
import { ProjectService } from '../../../../../_services/project.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { DropdownModule, FileUploadModule, EditorModule } from 'primeng/primeng';
import { ProjectCreateComponent } from '../project-create/project-create.component';
import { ProjectEditComponent } from '../project-edit/project-edit.component';
import { GrowlModule } from 'primeng/primeng';
import { MessageService } from 'primeng/components/common/messageservice';
import { ConfirmDialogModule } from 'primeng/primeng';
import { ConfirmationService } from 'primeng/primeng';
const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': ProjectListComponent,
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
        EditorModule,
        GrowlModule,
        ConfirmDialogModule
    ],
    declarations: [
        ProjectListComponent,
        ProjectCreateComponent,
        ProjectEditComponent
    ],
    providers: [
        HttpClient,
        ProjectService,
        MessageService,
        ConfirmationService
    ]
})

export class ProjectListModule {

}