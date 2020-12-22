import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass : 'toast-bottom-right'
     }),
     TabsModule.forRoot(),
  ],
 exports: [
    ToastrModule,
    TabsModule

 ]
})
export class SharedModule { }
