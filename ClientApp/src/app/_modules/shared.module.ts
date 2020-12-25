import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './_shared/paging-header/paging-header.component';
import { PagerComponent } from './_shared/pager/pager.component';


@NgModule({
  declarations: [ PagingHeaderComponent, PagerComponent, ],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass : 'toast-bottom-right'
     }),
     TabsModule.forRoot(),
     PaginationModule.forRoot(),

   ],
 exports: [
    ToastrModule,
    TabsModule,
    PaginationModule,
    PagingHeaderComponent, // any module using share module can use this component
    PagerComponent,
 ]
})
export class SharedModule { }
