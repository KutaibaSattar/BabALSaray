import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { DbaccountsListComponent } from './dbaccounts/dbaccounts-list/dbaccounts-list.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ProjectsComponent } from './admin/projects/projects.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, data: { breadcrumb: 'Home'}},
  { path: 'dashboard', component: DashboardComponent, data: { breadcrumb: 'DashBoard'}},
  { path: 'projects', component: ProjectsComponent, data: { breadcrumb: 'Projects'}},
  { path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard],
    children: [
      { path: 'dbaccounts', component: DbaccountsListComponent, canActivate: [AuthGuard], data: { breadcrumb: 'Accounts' } },
      { path: 'dbaccount/:id', component: DbaccountsListComponent },
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
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, {relativeLinkResolution: 'legacy' }),
    CommonModule
  ],
  exports :[ RouterModule]
})
export class AppRoutingModule { }
