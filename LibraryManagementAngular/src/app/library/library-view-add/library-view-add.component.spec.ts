import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryViewAddComponent } from './library-view-add.component';

describe('LibraryViewAddComponent', () => {
  let component: LibraryViewAddComponent;
  let fixture: ComponentFixture<LibraryViewAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LibraryViewAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LibraryViewAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
