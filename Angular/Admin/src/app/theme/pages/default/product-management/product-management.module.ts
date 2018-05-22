import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductManagementComponent } from './product-management.component';
import { DefaultComponent } from '../default.component';
import { LayoutModule } from '../../../layouts/layout.module';
import {
    AccordionModule,
    ButtonModule,
    CheckboxModule,
    ChipsModule,
    CodeHighlighterModule,
    ColorPickerModule,
    InputMaskModule,
    FieldsetModule,
    GrowlModule,
    InputTextModule,
    MultiSelectModule,
    PanelModule,
    RadioButtonModule,
    SelectButtonModule,
    SplitButtonModule,
    TabViewModule,
    DialogModule,
    DropdownModule,
    FileUploadModule
} from 'primeng/primeng';
import { ProjectCreateComponent } from '../project-management/project-create/project-create.component';
import { ProjectEditComponent } from '../project-management/project-edit/project-edit.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { EditorModule } from 'primeng/components/editor/editor';
import { ProductService } from '../../../../_services/product.service';
import { ProductCreateComponent } from './product-create/product-create.component';
import { MessageService } from 'primeng/components/common/messageservice';

const routes: Routes = [
    {
        path: '',
        component: DefaultComponent,
        children: [
            {
                path: '',
                component: ProductManagementComponent,
            },
            {
                path: 'tao-san-pham',
                component: ProductCreateComponent,
            },
            {
                path: 'chinh-sua-san-pham/:id',
                component: ProductCreateComponent,
            }
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
        GrowlModule
    ],
    declarations: [
        ProductManagementComponent,
        ProductCreateComponent
    ],
    providers: [
        HttpClient,
        ProductService,
        MessageService
    ]
})

export class ProductManagementModule {

}