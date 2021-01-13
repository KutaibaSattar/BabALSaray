import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { SharedModule } from '../_modules/shared.module';





@NgModule({
  declarations: [SectionHeaderComponent],
  imports: [
    CommonModule,
    BreadcrumbModule,
    SharedModule,
  ],

  exports: [
    SectionHeaderComponent,

  ]
})
export class CoreModule { }
