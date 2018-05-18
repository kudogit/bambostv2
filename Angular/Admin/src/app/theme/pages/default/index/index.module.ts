import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { DefaultComponent } from '../default.component';
import { ConfigurationDisplayComponent } from '../configuration/configuration-display/configuration-display.component';
import { ConfigurationService } from '../../../../_services/configuration.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
        HttpClientModule
    ], declarations: [
        IndexComponent,
        ConfigurationDisplayComponent
    ],
    providers: [
        HttpClient,
        ConfigurationService
    ]
})
export class IndexModule {



}