import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryViewEditComponent } from './library-view-edit.component';

describe('LibraryViewComponent', () => {
  let component: LibraryViewEditComponent;
  let fixture: ComponentFixture<LibraryViewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LibraryViewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LibraryViewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
