import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookViewEditComponent } from './book-view-edit.component';

describe('BookViewEditComponent', () => {
  let component: BookViewEditComponent;
  let fixture: ComponentFixture<BookViewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookViewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookViewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
