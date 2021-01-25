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
import { AuthGuard } from './_guards/auth.guard';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { SharedModule } from './_shared/shared.module';
import {registerLocaleData} from '@angular/common'
import localeAr from '@angular/common/locales/en-AE';registerLocaleData(localeAr);
import { AdminModule } from './_modules/admin/admin.module';
import { dashboardComponent } from './_modules/admin/dashboard/dashboard.component';



const routes: Routes = [
  { path: 'home', component: HomeComponent, data: { breadcrumb: 'Home'}},
  { path: 'orders', component: dashboardComponent, data: { breadcrumb: 'MyHome'}},
  { path: '',runGuardsAndResolvers: 'always', canActivate: [AuthGuard],
    children: [
      { path: 'dbaccounts', component: DbaccountsListComponent, canActivate: [AuthGuard], data: { breadcrumb: 'Accounts' } },
      { path: 'dbaccount/:id', component: DbaccountDetailComponent },
      { path: 'checkout', loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule),
        data: { breadcrumb: 'Checkout'}},
        ]},
    {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule),
      data: { breadcrumb: 'Shop' }},
    {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule),
      data: { breadcrumb: 'Basket' }},
    {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
      data: { breadcrumb: { skip: true } }},
    { path: 'errors', component: TestErrorsComponent, data: { breadcrumb: 'Test Errors' } },
    { path: 'not-found', component: NotFoundComponent, data: { breadcrumb: 'Not Found' } },
    { path: 'server-error', component: ServerErrorComponent, },
    { path: '**', component: NotFoundComponent, pathMatch: 'full' },

    ];


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
    RouterModule.forRoot(routes,{relativeLinkResolution: 'legacy' }),
    AdminModule,
    
    ],

   providers: [
    {provide : HTTP_INTERCEPTORS , useClass : ErrorInterceptor , multi: true} ,
    {provide : HTTP_INTERCEPTORS , useClass : JwtInterceptor , multi: true},
    {provide : HTTP_INTERCEPTORS , useClass : LoadingInterceptor , multi: true},

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
