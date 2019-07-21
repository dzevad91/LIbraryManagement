import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-book-view-edit',
  templateUrl: './book-view-edit.component.html',
  styleUrls: ['./book-view-edit.component.css']
})
export class BookViewEditComponent implements OnInit {
  @Input() book: any;

  constructor(public activeModal: NgbActiveModal) { }

  closeModal(){
    this.activeModal.close();
  }

  ngOnInit() {
    console.log(this.book);
  }
}
