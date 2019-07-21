import { Component, OnInit } from '@angular/core';
import { AjaxService } from '../Services/ajax.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ClientViewEditComponent } from './client-view-edit/client-view-edit.component';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  clients: any;
  client: any;

  constructor(private ajaxService: AjaxService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.ajaxService.getClients().subscribe(clients =>{
      this.clients = clients;
      console.log(this.clients);
    });
  }

  editClient(client) {
    const modalRef = this.modalService.open(ClientViewEditComponent, { windowClass: 'modal-holder', backdrop:'static', size:'lg'});
    modalRef.componentInstance.client = client;
  }
}
