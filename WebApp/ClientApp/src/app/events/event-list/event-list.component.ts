import { Component, OnInit } from '@angular/core';

import { ToastService } from "../../core/toast.service";
import { EventService } from '../shared/event.service';
import { ServerResponse } from "../../core/server-response";
import { Event } from '../shared/event';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: Event[];

  constructor(private eventsService: EventService, private toaster: ToastService) { }

  ngOnInit() {
    this.getEvents();
  }

  private getEvents(): void {
    this.eventsService.getEvents().subscribe(
      (response: ServerResponse<Event[]>) => this.events = response.data
    );
  }

  public deleteEvent(event: Event): void {
    this.eventsService.deleteEvent(event.id).subscribe(
      (response: ServerResponse<Event>) =>  {
          this.events = this.events.filter(e => e != event);
          this.toaster.success(response.message)
       }
    )
  }
}
