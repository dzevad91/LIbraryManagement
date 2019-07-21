import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LibraryComponent } from './library/library.component';
import { BookComponent } from './book/book.component';
import { PublisherComponent } from './publisher/publisher.component';
import { ClientComponent } from './client/client.component';
import { LibraryDetailsComponent } from './library/library-details/library-details.component';


const routes: Routes = [
  { path: '', redirectTo: '/libraries', pathMatch: 'full'},
  { path: 'libraries', component: LibraryComponent},
  { path: 'books', component: BookComponent},
  { path: 'publishers', component : PublisherComponent},
  { path: 'clients', component : ClientComponent},
  { path: 'library-details/:id', component: LibraryDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
