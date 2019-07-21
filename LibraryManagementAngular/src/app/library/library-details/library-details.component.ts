import { Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AjaxService } from 'src/app/Services/ajax.service';

@Component({
  selector: 'app-library-details',
  templateUrl: './library-details.component.html',
  styleUrls: ['./library-details.component.css']
})
export class LibraryDetailsComponent implements OnInit {

  libraryDetails = [];

  constructor(private route: ActivatedRoute, private ajaxService : AjaxService){

  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
       this.ajaxService.getLibraryById(params.get('id')).subscribe(results =>{
          this.libraryDetails = results;
      })
    });
  }
}
