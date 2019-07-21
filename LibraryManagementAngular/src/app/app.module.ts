import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { GridModule } from '@progress/kendo-angular-grid';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AjaxService } from './Services/ajax.service';
import { LibraryComponent } from './library/library.component';
import { LibraryViewEditComponent } from './library/library-view-edit/library-view-edit.component';
import { BookComponent } from './book/book.component';
import { BookViewEditComponent } from './book/book-view-edit/book-view-edit.component';
import { PublisherComponent } from './publisher/publisher.component';
import { PubisherViewEditComponent } from './publisher/pubisher-view-edit/pubisher-view-edit.component';
import { ClientComponent } from './client/client.component';
import { ClientViewEditComponent } from './client/client-view-edit/client-view-edit.component';
import { LibraryViewAddComponent } from './library/library-view-add/library-view-add.component';
import { LibraryDetailsComponent } from './library/library-details/library-details.component';
import { FieldErrorDisplayComponent } from './field-error-display';

@NgModule({
  declarations: [
    AppComponent,
    LibraryComponent,
    LibraryViewEditComponent,
    BookComponent,
    BookViewEditComponent,
    PublisherComponent,
    PubisherViewEditComponent,
    ClientComponent,
    ClientViewEditComponent,
    LibraryViewAddComponent,
    LibraryDetailsComponent,
    FieldErrorDisplayComponent
  ],
  entryComponents: [
    LibraryViewEditComponent,
    BookViewEditComponent,
    PubisherViewEditComponent,
    ClientViewEditComponent,
    LibraryViewAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    GridModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AjaxService,
    ToastrService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
