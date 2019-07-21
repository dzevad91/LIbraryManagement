import { Component, OnInit, Output } from '@angular/core';
import { AjaxService } from '../Services/ajax.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LibraryViewEditComponent } from './library-view-edit/library-view-edit.component';
import { ToastrService } from 'ngx-toastr';
import { LibraryViewAddComponent } from './library-view-add/library-view-add.component';


@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {
  libraries: any;
  library: any;

  @Output() LibraryComponent;
  
  constructor(private ajaxService: AjaxService,
    private modalService: NgbModal, private toastr: ToastrService) { }

  ngOnInit() {
    this.ajaxService.getLibraries().subscribe(libraries =>{
      this.libraries = libraries;
      console.log(libraries);
    });
  }

  editLibrary(library) {
    const modalRef = this.modalService.open(LibraryViewEditComponent, { windowClass: 'modal-holder', backdrop:'static', size:'sm'});
    modalRef.componentInstance.library = library;
  }

  addNewLibrary(library) {
    const modalRef = this.modalService.open(LibraryViewAddComponent, { windowClass: 'modal-holder', backdrop:'static', size:'sm'});
    modalRef.componentInstance.library = library;

    modalRef.componentInstance.passAddedLibrary.subscribe((receivedEntry) => {
      console.log(receivedEntry);
      this.ajaxService.getLibraries().subscribe(libraries =>{
        this.libraries = libraries;
      });
    });
  }

  deleteLibrary(libraryId){

    this.ajaxService.deleteLibrary(libraryId).subscribe((response) => {
      //do something with the response
      this.toastr.info("Library successfully deleted");
      
      this.ajaxService.getLibraries().subscribe(libraries =>{
        this.libraries = libraries;
      });
   },
   (error) => {
      //catch the error
      this.toastr.error("Library deleting failed");
   });
  }

}
