import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SidebarModule } from 'primeng/sidebar';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { CardModule } from 'primeng/card';
import { ToastModule } from 'primeng/toast';

import { DashboardHomeComponent } from './page/dashboard-home/dashboard-home.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { DASHBOARD_ROUTES } from '../dashboard.routing';

@NgModule({
  declarations: [
    DashboardHomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(DASHBOARD_ROUTES),
    //PrimeNg
    ToolbarModule,
    SidebarModule,
    ButtonModule,
    ToolbarModule,
    CardModule,
    ToastModule,
    //Shared
    SharedModule
  ]
})
export class DashboardModule { }
