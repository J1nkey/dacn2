import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { SliderComponent } from './slider/slider.component';

import { CarouselModule } from 'ngx-owl-carousel-o';
import { ChatComponent } from './chat/chat.component';
import { HomeComponent } from './home/home.component';
import { NgToastModule } from 'ng-angular-popup';
import { UploadPostComponent } from './upload-post/upload-post.component';
import { DetailPostComponent } from './detail-post/detail-post.component';
import { PostsComponent } from './posts/posts.component';
import { PageNotFoundComponent } from './pagenotfound/pagenotfound.component';

import { JwtModule } from "@auth0/angular-jwt";
import { RegisterComponent } from './register/register.component';

export function tokenGetter()
{
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    HeaderComponent,
    SliderComponent,
    ChatComponent,
    UploadPostComponent,
    DetailPostComponent,
    PostsComponent,
    PageNotFoundComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CarouselModule,
    NgToastModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['*'],
        disallowedRoutes: ['http://example.com/examplebadroute/']
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
