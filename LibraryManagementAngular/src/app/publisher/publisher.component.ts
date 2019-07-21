import { Component, OnInit } from '@angular/core';
import { AjaxService } from '../Services/ajax.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PubisherViewEditComponent } from './pubisher-view-edit/pubisher-view-edit.component';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {
  publishers: any;
  publisher: any;

  constructor(private ajaxService: AjaxService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.ajaxService.getPublishers().subscribe(publishers =>{
      this.publishers = publishers;
      console.log(this.publishers);
    });
  }

  editBook(publisher) {
    const modalRef = this.modalService.open(PubisherViewEditComponent, { windowClass: 'modal-holder', backdrop:'static', size:'lg'});
    modalRef.componentInstance.publisher = publisher;
  }

}
