import { ServerConnectionDialog } from "./server-connection-dialog";
import { ApplicantService } from "./applicant-service";
import { inject } from "aurelia-framework";
import { ApplicantUpdated, ApplicantViewed, ApplicantDeleted } from "./events";
import { EventAggregator } from "aurelia-event-aggregator";
import { DialogService } from "aurelia-dialog";
import { Router } from 'aurelia-router';
import { time } from "console";
@inject(ApplicantService, EventAggregator, DialogService, Router)
export class ApplicantList {
  applicants;
  selectedId = 0;
  constructor(
    private applicantService: ApplicantService,
    private eventAggregator: EventAggregator,
    private dialogService: DialogService
  ) {
    eventAggregator.subscribe(ApplicantViewed, (msg) =>
      this.select(msg.applicant.id)
    );
    eventAggregator.subscribe(ApplicantUpdated, (msg) => {
      this.created();
      this.select(msg.applicant.id)
    });
    eventAggregator.subscribe(ApplicantDeleted, (msg) => {
      this.created();
      this.select(0)
    });
  }

  created() {

    this.applicantService
      .getApplicants()
      .then(response => {
        if (response.status == 200) this.applicants = response.data;
      })
      .catch((error) => {
        this.dialogService
          .open({ viewModel: ServerConnectionDialog })
          .whenClosed((response) => {
            if (!response.wasCancelled) {
              this.created();
            } else {
            }
          });
      });
  }

  select(id) {
    this.selectedId = id;
    return true;
  }
}
