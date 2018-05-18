import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfigurationDisplayComponent } from './configuration-display.component';
import { CKEditorModule } from 'ngx-ckeditor';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DefaultComponent } from '../../default.component';
import { LayoutModule } from '../../../../layouts/layout.module';
import { ConfigurationService } from '../../../../../_services/configuration.service';

const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': ConfigurationDisplayComponent,
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
        HttpClientModule
    ],
    declarations: [
        ConfigurationDisplayComponent,
    ],
    providers: [
        HttpClient,
        ConfigurationService
    ]
})

export class ConfigurationModule {

}