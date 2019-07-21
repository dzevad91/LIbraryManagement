import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AjaxService } from 'src/app/Services/ajax.service';
import { ToastrService } from 'ngx-toastr';

interface Library  {
  Name: string;
  Address: string;
  City: string;
}

@Component({
  selector: 'app-library-view-add',
  templateUrl: './library-view-add.component.html',
  styleUrls: ['./library-view-add.component.css']
})
export class LibraryViewAddComponent implements OnInit {


  @Input() libraries:any;

  @Output() passAddedLibrary: EventEmitter<any> = new EventEmitter();

  public library: Library;

  public addLibraryForm : FormGroup;

  constructor(public activeModal: NgbActiveModal , 
    private ajaxService : AjaxService, private toastr : ToastrService) { 
    
  }

  closeModal(){
    this.activeModal.close();

  }

  ngOnInit() {
    
    this.addLibraryForm = new FormGroup({
      name: new FormControl('',[Validators.required] ),
      city: new FormControl('',[Validators.required] ),
      address: new FormControl('',[Validators.required] ),
    });
  }

isFieldValid(field: string) {
    return (!this.addLibraryForm.get(field).valid && this.addLibraryForm.get(field).touched);
}

displayFieldCss(field: string) {
    return {
        'has-error': this.isFieldValid(field)
    };
}

  addLibrary(){
    if (!this.addLibraryForm.valid) {
      Object.keys(this.addLibraryForm.controls).forEach(field => {
          const control = this.addLibraryForm.get(field);
          control.markAsTouched();
      });
      return false;
  }

    const library: Library = {
      Name: this.addLibraryForm.value.name,
      City: this.addLibraryForm.value.city,
      Address: this.addLibraryForm.value.address
    }


    this.ajaxService.addLibrary(library).subscribe((response) => {
      //do something with the response
      this.toastr.success("Library successfully added");
      
      this.passAddedLibrary.emit(library);

    },
    (error) => {
      //catch the error
      this.toastr.error("Library adding failed");
    });

    this.closeModal();
  }

}
