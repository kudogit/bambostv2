import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ThemeComponent } from './theme/theme.component';
import { LayoutModule } from './theme/layouts/layout.module';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ScriptLoaderService } from "./_services/script-loader.service";
import { ThemeRoutingModule } from "./theme/theme-routing.module";
import { AuthModule } from "./auth/auth.module";
import { SettingsService } from './_services/setting.service';
import { AboutService } from './_services/about.service';
import { HttpClient, HttpHandler, HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { HttpInterceptor } from './_services/handle.service';

@NgModule({
    declarations: [
        ThemeComponent,
        AppComponent,
    ],
    imports: [
        LayoutModule,
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        ThemeRoutingModule,
        AuthModule,
        HttpClientModule
    ],
    providers: [
        ScriptLoaderService,
        SettingsService,
        AboutService,
        HttpClient,
        HttpInterceptor
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }