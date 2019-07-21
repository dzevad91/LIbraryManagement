import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AjaxService } from 'src/app/Services/ajax.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-library-view-edit',
  templateUrl: './library-view-edit.component.html',
  styleUrls: ['./library-view-edit.component.css']
})
export class LibraryViewEditComponent implements OnInit {
  
  public editLibraryForm : FormGroup;
  
  @Input() library: any;
  
  constructor(public activeModal: NgbActiveModal , 
    private ajaxService : AjaxService, private toastr : ToastrService) { 
    
  }

  closeModal(){
    this.activeModal.close();
  }

  ngOnInit() {
    this.editLibraryForm = new FormGroup({
      name: new FormControl('',[Validators.required] ),
      city: new FormControl('',[Validators.required] ),
      address: new FormControl('',[Validators.required] ),
    });

    this.setValuesInForm();

  }

isFieldValid(field: string) {
    return (!this.editLibraryForm.get(field).valid && this.editLibraryForm.get(field).touched);
}

displayFieldCss(field: string) {
    return {
        'has-error': this.isFieldValid(field)
    };
}

  setValuesInForm(){
      this.editLibraryForm.controls.name.setValue(this.library.Name);
      this.editLibraryForm.controls.city.setValue(this.library.City);
      this.editLibraryForm.controls.address.setValue(this.library.Address);
  }

  updateLibrary(){

    if (!this.editLibraryForm.valid) {
      Object.keys(this.editLibraryForm.controls).forEach(field => {
          const control = this.editLibraryForm.get(field);
          control.markAsTouched();
      });
      return false;
  }

    this.library.Name = this.editLibraryForm.value.name;
    this.library.City = this.editLibraryForm.value.city;
    this.library.Address = this.editLibraryForm.value.address;


    this.ajaxService.updateLibrary(this.library).subscribe((response) => {
      //do something with the response
      this.toastr.success("Library successfully updated");
   },
   (error) => {
      //catch the error
      this.toastr.error("Library editing failed");
   });

    this.closeModal();
  }

}
