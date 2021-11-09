import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationComponent } from './authentication/authentication.component';
import { RegisterComponentComponent } from './authentication/register-component/register-component.component';
import { ResultComponent } from './hr-dashboard/result/result.component';
import { AddCandidateComponent } from './hr-dashboard/add-candidate/add-candidate.component';
import { HrDashboardComponent } from './hr-dashboard/hr-dashboard.component';
import { ScheduleComponent } from './hr-dashboard/schedule/schedule.component';
import { InterviewerDashboardComponent } from './interviewer-dashboard/interviewer-dashboard.component';
import { RatingComponent } from './interviewer-dashboard/rating/rating.component';

const routes: Routes = [
  {
    path:'', component : AuthenticationComponent
  },
  {
    path : 'hrdashboard',component : HrDashboardComponent
  },
  { 
    path:'addCandidate',component:AddCandidateComponent
  },
  {
    path:'register',component:RegisterComponentComponent
  },
  {
    path:'schedule',component:ScheduleComponent
  },
  {
    path:'result',component:ResultComponent
  },
  {
    path:'interviewer',component:InterviewerDashboardComponent
  },
  {
    path:'rating',component:RatingComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
