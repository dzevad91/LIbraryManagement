import { Component, OnInit, Input } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-field-error-display',
  templateUrl: './field-error-display.html',
  styleUrls: ['./field-error-display.css']
})
export class FieldErrorDisplayComponent implements OnInit {
    
  @Input() errorMsg: string;
  @Input() displayError: boolean;

  ngOnInit(){
    
    }
}
