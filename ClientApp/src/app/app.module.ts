import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { CounterComponent } from './counter/counter.component';
import { DbaccountCardComponent } from './dbaccounts/dbaccount-card/dbaccount-card.component';
import { DbaccountDetailComponent } from './dbaccounts/dbaccount-detail/dbaccount-detail.component';
import { DbaccountsListComponent } from './dbaccounts/dbaccounts-list/dbaccounts-list.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { SharedModule } from './_shared/shared.module';
import {registerLocaleData} from '@angular/common';
import localeAr from '@angular/common/locales/en-AE'; registerLocaleData(localeAr);
import { AdminModule } from './admin/admin.module';
import { AppRoutingModule } from './app-routing.module';






@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavComponent,
    DbaccountsListComponent,
    DbaccountDetailComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    DbaccountCardComponent,
    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    SharedModule,
    CoreModule,
    NgxSpinnerModule,
    AdminModule,
    AppRoutingModule,
    ],

   providers: [
    {provide : HTTP_INTERCEPTORS , useClass : ErrorInterceptor , multi: true} ,
    {provide : HTTP_INTERCEPTORS , useClass : JwtInterceptor , multi: true},
    {provide : HTTP_INTERCEPTORS , useClass : LoadingInterceptor , multi: true},

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
