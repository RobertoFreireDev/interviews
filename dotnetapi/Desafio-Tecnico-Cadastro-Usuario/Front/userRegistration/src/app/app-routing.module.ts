import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserReportComponent } from './pages/user-report/user-report.component';
import { UserComponent } from './pages/user/user.component';

const routes: Routes = [
  { path : 'user', component: UserComponent  },
  { path : 'report', component: UserReportComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
