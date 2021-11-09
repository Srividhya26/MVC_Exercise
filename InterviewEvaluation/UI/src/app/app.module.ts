import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HrDashboardComponent } from './hr-dashboard/hr-dashboard.component';
import { AddCandidateComponent } from './hr-dashboard/add-candidate/add-candidate.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { RegisterComponentComponent } from './authentication/register-component/register-component.component';
import { ScheduleComponent } from './hr-dashboard/schedule/schedule.component';
import { ResultComponent } from './hr-dashboard/result/result.component';
import { InterviewerDashboardComponent } from './interviewer-dashboard/interviewer-dashboard.component';
import { RatingComponent } from './interviewer-dashboard/rating/rating.component';


@NgModule({
  declarations: [
    AppComponent,
    HrDashboardComponent,
    AddCandidateComponent,
    AuthenticationComponent,
    RegisterComponentComponent,
    ScheduleComponent,
    ResultComponent,
    InterviewerDashboardComponent,
    RatingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
