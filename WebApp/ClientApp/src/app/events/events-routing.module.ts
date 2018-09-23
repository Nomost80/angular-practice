import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";

import { AddEventComponent } from "./add-event/add-event.component";
import { EditEventComponent } from "./edit-event/edit-event.component";
import { EventDetailComponent } from "./event-detail/event-detail.component";
import { EventListComponent } from "./event-list/event-list.component";

const routes: Routes = [
  { path: '', component: EventListComponent },
  { path: 'add', component: AddEventComponent },
  { path: ':id/edit', component: EditEventComponent },
  { path: ':id', component: EventDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EventsRoutingModule { }
