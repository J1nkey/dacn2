import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../_interfaces/login.model';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
// import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthenticatedResponse } from '../_interfaces/authenticated-response.model';
import { AuthService } from '../services/auth.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  
  public loginForm!: FormGroup;
  type: string = "password";
  isText: boolean  = false;
  eyeIcon: string = 'fa-eye-splash';

  invalidLogin: boolean = true;
  credentials: LoginModel = {username: '', password: '', rememberMe: true};

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private toast: NgToastService,
    private authService: AuthService) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  hidePassword() {
    this.isText = !this.isText;
    this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
    this.isText ? (this.type = 'text') : (this.type = 'password');
  }

  onSubmit() {
    if(this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.authService.login(this.loginForm.value)
      .subscribe({
        next: (response) => {
          console.log(response.message);
          this.loginForm.reset();
          this.toast.success({detail: "SUCCESS", summary: response.message, duration: 5000});
          this.router.navigate(["/"]);
        },
        error:(err) => {
          this.toast.error({detail: "ERROR", summary: "Something when wrong!", duration: 5000});
          console.error(err);
        }
      });
    }
    else {
      // ValidateForm.validateAllFormFields(this.loginForm);
    }
  }

  // login = (form: NgForm) => {
  //   console.log("Login");
  //   if(form.valid) {
  //     this.http.post<AuthenticatedResponse>("https://localhost:7228/login", this.credentials, {
  //       headers: new HttpHeaders({ "Content-Type": "application/json"})
  //     })
  //     .subscribe({
  //       next: (response: AuthenticatedResponse) => {
  //         const token = response.tokenAuth;
  //         localStorage.setItem("jwt", token);
  //         this.invalidLogin = false;
  //         this.router.navigate(["/"]);
  //       },
  //       error: (err: HttpErrorResponse) => this.invalidLogin = true
  //     });
  //   }
  // }
}
