import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Validators } from "@angular/forms";
import { HttpErrorResponse } from "@angular/common/http";

import { ServerResponse } from "../../core/server-response";
import { Event } from "../shared/event";
import { EventError } from "../shared/event-error";
import { EventService } from "../shared/event.service";
import { ToastService } from "../../core/toast.service";

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent implements OnInit {
  eventForm: FormGroup;
  error: ServerResponse<EventError>;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private eventsService: EventService,
    private toaster: ToastService
  ) { }

  ngOnInit() {
    this.eventForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['', Validators.required],
      price: [''],
      question: [''],
      address: ['', Validators.required],
      postcode: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      voteDeadline: [''],
      enrollmentDeadline: [''],
      date: ['']
    });
  }

  private addEvent(event: Event): void {
    this.eventsService.createEvent(event).subscribe(
      (response: ServerResponse<Event>) => {
        this.router.navigate(['/events'])
          .then(() => this.toaster.success(response.message));
      },
      (error: HttpErrorResponse) => {
         this.error = error.error;
      }
    )
  }

  public onSubmit(): void {
    this.addEvent(this.eventForm.value);
  }
}
