import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { UnAuthenticatedComponent } from './core/un-authenticated/un-authenticated.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';

export const routes: Routes = [
  {path: '',  component:HomeComponent, data:{breadcrumb:'Home'}},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'un-authenticated', component: UnAuthenticatedComponent},
  {path:'server-error', component: ServerErrorComponent},
  {path: 'store', loadChildren:()=>import('./store/store.module').then(mod=>mod.StoreModule), data:{breadcrumb:'Store'}},
  {path: '**', redirectTo: '', pathMatch: 'full'},];
