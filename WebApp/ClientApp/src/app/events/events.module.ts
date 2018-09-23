import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from "@angular/forms";
import { NgZorroAntdModule } from 'ng-zorro-antd';

import { EventsRoutingModule } from "./events-routing.module";
import { EventService } from "./shared/event.service";
import { EventListComponent } from "./event-list/event-list.component";
import { EventDetailComponent } from "./event-detail/event-detail.component";
import { AddEventComponent } from "./add-event/add-event.component";
import { EditEventComponent } from "./edit-event/edit-event.component";

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    EventsRoutingModule
  ],
  declarations: [
    EventListComponent,
    EventDetailComponent,
    AddEventComponent,
    EditEventComponent
  ],
  providers: [EventService]
})
export class EventsModule { }
