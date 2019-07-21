import { Component, OnInit } from '@angular/core';
import { AjaxService } from '../Services/ajax.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BookViewEditComponent } from './book-view-edit/book-view-edit.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  books: any;
  book: any;

  constructor(private ajaxService: AjaxService,
    private modalService: NgbModal, private toastr: ToastrService) { }

  ngOnInit() {
    this.ajaxService.getBooks().subscribe(books =>{
      this.books = books;
      console.log(this.books);
    });
  }

  editBook(book) {
    console.log(book)
    const modalRef = this.modalService.open(BookViewEditComponent, { windowClass: 'modal-holder', backdrop:'static', size:'lg'});
    modalRef.componentInstance.book = book;
  }

  deleteBook(){
    this.toastr.error("Hello, I'm the toastr message.")
    console.log("delete clicked");
  }

}
