import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { CarouselModule} from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './text-input/text-input.component';
import {CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './stepper/stepper.component';
import { BasketSummaryComponent } from './basket-summary/basket-summary.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [ PagingHeaderComponent, PagerComponent, OrderTotalsComponent,
     TextInputComponent, StepperComponent, BasketSummaryComponent ],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass : 'toast-bottom-right'
     }),
     TabsModule.forRoot(),
     PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    ReactiveFormsModule,
    CdkStepperModule,
    RouterModule
   ],
 exports: [
    ToastrModule,
    TabsModule,
    PaginationModule,
    PagingHeaderComponent, // any module using share module can use this component
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent,
    ReactiveFormsModule,
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    BasketSummaryComponent
 ]
})
export class SharedModule { }
