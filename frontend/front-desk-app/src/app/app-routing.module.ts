import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoxesCreateComponent } from './components/boxes-create/boxes-create.component';
import { BoxesViewComponent } from './components/boxes-view/boxes-view.component';
import { CustomerEditPageComponent } from './components/customer-edit-page/customer-edit-page.component';
import { CustomerListPageComponent } from './components/customer-list-page/customer-list-page.component';
import { StorageListPageComponent } from './components/storage-list-page/storage-list-page.component';

const routes: Routes = [
  { path: 'customers', component: CustomerListPageComponent },
  { path: 'customers/create', component: CustomerEditPageComponent },
  { path: 'customers/:id/boxes', component: BoxesViewComponent },  
  { path: 'customers/:id/boxes/create', component: BoxesCreateComponent },
  { path: 'storages', component: StorageListPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
