import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { DefaultComponent } from '../default.component';
import { ConfigurationService } from '../../../../_services/configuration.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConfigurationComponent } from '../configuration/configuration.component';

const routes: Routes = [
    {
        "path": "",
        "component": DefaultComponent,
        "children": [
            {
                "path": "",
                "component": IndexComponent
            }
        ]
    }
];
@NgModule({
    imports: [
        CommonModule, RouterModule.forChild(routes), LayoutModule
    ], exports: [
        RouterModule,
        HttpClientModule,
    ], declarations: [
        IndexComponent,
    ],
    providers: [
        HttpClient,
        ConfigurationService
    ]
})
export class IndexModule {



}