import { NgModule } from '@angular/core';
import { ThemeComponent } from './theme.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from "../auth/_guards/auth.guard";

const routes: Routes = [
    {
        "path": "",
        "component": ThemeComponent,
        "canActivate": [AuthGuard],
        "children": [

            {
                "path": "index",
                "loadChildren": ".\/pages\/default\/index\/index.module#IndexModule"
            },
            {
                "path": "product",
                "loadChildren": ".\/pages\/default\/product\/product.module#ProductModule"
            },
            {
                "path": "header\/actions",
                "loadChildren": ".\/pages\/default\/header\/header-actions\/header-actions.module#HeaderActionsModule"
            },
            {
                "path": "header\/profile",
                "loadChildren": ".\/pages\/default\/header\/header-profile\/header-profile.module#HeaderProfileModule"
            },
            {
                "path": "404",
                "loadChildren": ".\/pages\/default\/not-found\/not-found.module#NotFoundModule"
            },
            {
                "path": "about",
                "loadChildren": ".\/pages\/default\/about\/about.module#AboutModule"
            },
            {
                "path": "about/create",
                "loadChildren": ".\/pages\/default\/about\/about-create\/about-create.module#AboutCreateModule"
            },
            {
                "path": "configuration",
                "loadChildren": ".\/pages\/default\/configuration\/configuration.module#ConfigurationModule"
            },
            {
                "path": "project/:id",
                "loadChildren": ".\/pages\/default\/project\/project.module#ProjectModule"
            },
            {
                "path": "quan-ly-san-pham",
                "loadChildren": ".\/pages\/default\/product-management\/product-management.module#ProductManagementModule"
            },
            {
                "path": "",
                "redirectTo": "index",
                "pathMatch": "full"
            }
        ]
    },
    {
        "path": "**",
        "redirectTo": "404",
        "pathMatch": "full"
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ThemeRoutingModule { }