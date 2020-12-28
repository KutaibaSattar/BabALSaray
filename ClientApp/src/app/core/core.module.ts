import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbsModule } from '@exalif/ngx-breadcrumbs';




@NgModule({
  declarations: [SectionHeaderComponent],
  imports: [
    CommonModule,
    BreadcrumbsModule.forRoot(),
  ],
 
  exports: [
    SectionHeaderComponent,

  ]
})
export class CoreModule { }
