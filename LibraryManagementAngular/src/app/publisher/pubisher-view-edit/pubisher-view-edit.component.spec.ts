import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PubisherViewEditComponent } from './pubisher-view-edit.component';

describe('PubisherViewEditComponent', () => {
  let component: PubisherViewEditComponent;
  let fixture: ComponentFixture<PubisherViewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PubisherViewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PubisherViewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
