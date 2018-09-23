import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from 'environments/environment';

import { ServerResponse } from '../../core/server-response';
import { Event } from './event';

const API_URL = environment.apiUrl;

@Injectable()
export class EventService {
  eventsUrl = '/events/';

  constructor(private http: HttpClient) {}

  public getEvents(): Observable<ServerResponse<Event[]>> {
    return this.http.get<ServerResponse<Event[]>>(API_URL + this.eventsUrl)
  }

  public getEvent(id: number): Observable<ServerResponse<Event>> {
     return this.http.get<ServerResponse<Event>>(API_URL + this.eventsUrl + id);
  }

  public createEvent(event: Event): Observable<ServerResponse<Event>> {
     return this.http.post<ServerResponse<Event>>(API_URL + this.eventsUrl, event)
  }

  public updateEvent(event: Event): Observable<ServerResponse<Event>> {
     return this.http.put<ServerResponse<Event>>(API_URL + this.eventsUrl + event.id, event);
  }

  public deleteEvent(id: number): Observable<ServerResponse<Event>> {
     return this.http.delete<ServerResponse<Event>>(API_URL + this.eventsUrl + id);
  }
}
