import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientViewEditComponent } from './client-view-edit.component';

describe('ClientViewEditComponent', () => {
  let component: ClientViewEditComponent;
  let fixture: ComponentFixture<ClientViewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientViewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientViewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
