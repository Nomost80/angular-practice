import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterModule } from "@angular/router";
import { HttpClient, HttpHandler } from "@angular/common/http";
import { NgZorroAntdModule} from "ng-zorro-antd";

import { EventService } from "../shared/event.service";
import { EventListComponent } from "./event-list.component";

describe('EventListComponent', () => {
  let component: EventListComponent;
  let fixture: ComponentFixture<EventListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ RouterModule, NgZorroAntdModule ],
      declarations: [ EventListComponent ],
      providers: [ HttpHandler, HttpClient, EventService ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


});
