import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

import { switchMap } from "rxjs/operators";

import { ServerResponse } from "../../core/server-response";
import { Event } from "../shared/event";
import { EventError } from "../shared/event-error";
import { ToastService } from "../../core/toast.service";
import { EventService } from "../shared/event.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent implements OnInit {
  eventForm: FormGroup;
  error: ServerResponse<EventError>;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private toaster: ToastService,
    private eventService: EventService
  ) { }

  ngOnInit() {
    this.eventForm = this.fb.group({
      title: [''],
      description: [''],
      price: [''],
      question: [''],
      address: [''],
      postcode: [''],
      city: [''],
      country: [''],
      voteDeadline: [''],
      enrollmentDeadline: [''],
      date: ['']
    });

    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        return this.eventService.getEvent(Number(params.get('id')))
      })
    ).subscribe(response => this.eventForm.setValue(response.data));
  }

  private editEvent(event: Event): void {
    this.eventService.updateEvent(event)
      .subscribe(
        response => {
          this.router.navigate(['/event', event.id])
            .then(() => this.toaster.success(response.message));
        },
        (error: HttpErrorResponse) => {
          this.error = error.error;
        }
      )
  }

  public onSubmit() {
    this.editEvent(this.eventForm.value);
  }
}
