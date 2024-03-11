import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ToolbarNavigationComponent } from './components/toolbar-navigation/toolbar-navigation.component';

import { ToolbarModule } from 'primeng/toolbar';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [
    ToolbarNavigationComponent
  ],
  imports: [
    CommonModule,
    //PrimeNg
    ToolbarModule,
    CardModule,
    ButtonModule
  ],
  exports: [
    ToolbarNavigationComponent
  ]
})
export class SharedModule { }
