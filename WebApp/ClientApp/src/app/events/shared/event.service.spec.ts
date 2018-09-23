import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";

import { environment } from "../../../environments/environment";
import { EventService } from './event.service';
import { ServerResponse } from "../../core/server-response";
import { Event } from "./event";

const API_URL = environment.apiUrl;
const fakeEvents = [
  {
    id: 1,
    createdAt: "2018-09-07T15:23:22.0782934+02:00",
    updatedAt: null,
    title: "foot en salle",
    description: "wesh un foot en salle",
    price: 5,
    question: "Peux tu conduire des gens ?",
    address: "7 rue diderot",
    city: "Arras",
    postcode: "62000",
    country: "France",
    voteDeadline: "2018-09-10T12:00:00",
    enrollmentDeadline: "2018-09-18T10:00:00",
    date: "2018-09-22T14:00:00",
    validatedAt: null
  },
  {
    id: 2,
    createdAt: "2018-09-07T15:23:22.0782934+02:00",
    updatedAt: null,
    title: "barbecue",
    description: "wesh un foot en salle",
    price: 5,
    question: "Peux tu conduire des gens ?",
    address: "7 rue diderot",
    city: "Arras",
    postcode: "62000",
    country: "France",
    voteDeadline: "2018-09-10T12:00:00",
    enrollmentDeadline: "2018-09-18T10:00:00",
    date: "2018-09-22T14:00:00",
    validatedAt: null
  }
];

describe('EventService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EventService]
    });
  });

  afterEach(inject([HttpTestingController], (httpMock: HttpTestingController) => {
    httpMock.verify();
  }));

  it('should return the expected events', inject([EventService, HttpTestingController],
    (service: EventService, httpMock: HttpTestingController) => {
      service.getEvents().subscribe((response: ServerResponse<Event[]>) => {
         expect(response.data.length).toBe(2);
         expect(response.data[0].id).toBe(1);
         expect(response.data[0].title).toBe("foot en salle");
         expect(response.data[1].id).toBe(2);
         expect(response.data[1].title).toBe("barbecue");
      });

      const req = httpMock.expectOne(API_URL + service.eventsUrl, 'get events');

      expect(req.request.method).toBe('GET');
      expect(req.request.responseType).toBe('json');

      req.flush({
        message: null,
        data: fakeEvents
      });
   }));
});
