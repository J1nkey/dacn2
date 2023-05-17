import { NgModule } from '@angular/core';
import { RouterModule, Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { UploadPostComponent } from './upload-post/upload-post.component';
import { DetailPostComponent } from './detail-post/detail-post.component';
import { PageNotFoundComponent } from './pagenotfound/pagenotfound.component';
import { AuthGuard } from './guards/auth-guard.guard';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'posts/:userId/upload', component: UploadPostComponent, canActivate: [AuthGuard]},
  {path: 'posts/:id', component: DetailPostComponent},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [provideRouter(routes, withComponentInputBinding())]
})
export class AppRoutingModule { }
