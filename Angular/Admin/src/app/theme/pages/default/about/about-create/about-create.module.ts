import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AboutCreateComponent } from './about-create.component';
import { DefaultComponent } from '../../default.component';
import { LayoutModule } from '../../../../layouts/layout.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { AboutService } from '../../../../../_services/about.service';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';
import { EditorModule } from 'primeng/primeng';
import { GrowlModule } from 'primeng/primeng';
import { MessageService } from 'primeng/components/common/messageservice';
const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': AboutCreateComponent,
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
        CKEditorModule,
        HttpClientModule,
        EditorModule,
        GrowlModule
    ],
    declarations: [
        AboutCreateComponent
    ],
    providers: [
        HttpClient,
        AboutService,
        MessageService
    ]
})

export class AboutCreateModule {

}