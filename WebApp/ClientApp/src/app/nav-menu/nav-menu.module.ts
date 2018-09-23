import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { NgZorroAntdModule, NZ_I18N, fr_FR } from 'ng-zorro-antd';

import { NavMenuComponent } from "./nav-menu.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgZorroAntdModule
  ],
  exports: [NavMenuComponent],
  declarations: [NavMenuComponent],
  providers   : [ { provide: NZ_I18N, useValue: fr_FR } ]
})
export class NavMenuModule { }
