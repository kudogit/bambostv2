import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AboutComponent } from './about.component';
import { DefaultComponent } from '../default.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { EditorModule } from 'primeng/primeng';
import { GrowlModule } from 'primeng/primeng';
import { MessageService } from 'primeng/components/common/messageservice';
import { AccordionModule } from 'primeng/primeng';
const routes: Routes = [
    {
        'path': '',
        'component': DefaultComponent,
        'children': [
            {
                'path': '',
                'component': AboutComponent,
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
        EditorModule,
        GrowlModule,
        AccordionModule
    ],
    declarations: [
        AboutComponent,
    ],
    providers: [
        MessageService
    ]
})

export class AboutModule {

}