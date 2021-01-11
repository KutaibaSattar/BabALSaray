import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from '../_shared/paging-header/paging-header.component';
import { PagerComponent } from '../_shared/pager/pager.component';
import { CarouselModule} from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from '../_shared/order-totals/order-totals.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ PagingHeaderComponent, PagerComponent, OrderTotalsComponent ],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass : 'toast-bottom-right'
     }),
     TabsModule.forRoot(),
     PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    ReactiveFormsModule,
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
 ]
})
export class SharedModule { }
