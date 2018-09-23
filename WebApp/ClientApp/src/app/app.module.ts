import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import fr from '@angular/common/locales/fr';
import { NgZorroAntdModule, NZ_I18N, fr_FR } from 'ng-zorro-antd';

import { AppRoutingModule } from "./app-routing.module";
import { CoreModule } from "./core/core.module";
import { SharedModule } from "./shared/shared.module";
import { NavMenuModule } from "./nav-menu/nav-menu.module";
import { AppComponent } from './app.component';

registerLocaleData(fr);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    NgZorroAntdModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    NavMenuModule
  ],
  bootstrap: [AppComponent],
  providers   : [ { provide: NZ_I18N, useValue: fr_FR } ]
})
export class AppModule { }
