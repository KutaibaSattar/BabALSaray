import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RegisterComponent } from './register/register.component';
import { DbaccountsListComponent } from './dbaccounts/dbaccounts-list/dbaccounts-list.component';
import { DbaccountDetailComponent } from './dbaccounts/dbaccount-detail/dbaccount-detail.component';
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from './_guards/auth.guard';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { CommentsComponent } from './comments/comments.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavComponent,
    RegisterComponent,
    DbaccountsListComponent,
    DbaccountDetailComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    CommentsComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    SharedModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
          { path: 'dbaccounts-list', component: DbaccountsListComponent, canActivate: [AuthGuard] },
          { path: 'dbaccount-detail', component: DbaccountDetailComponent },
        ]
      },

      { path: 'errors', component: CommentsComponent},
      { path: 'not-found', component: NotFoundComponent},
      { path: 'server-error', component: ServerErrorComponent},

      { path: '**', component: NotFoundComponent, pathMatch: 'full' },


    ]),
   
  ],
  providers: [
   {provide : HTTP_INTERCEPTORS , useClass : ErrorInterceptor , multi: true} 

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
