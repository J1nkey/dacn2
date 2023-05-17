import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})


export class AuthService {
    private baseUrl: string = 'https://localhost:7228/';
    private loginRequestUrl: string = `${this.baseUrl}login`;
    private registerRequestUrl: string = `${this.baseUrl}register`;

    private tokenSectionKey : string = 'token';

    constructor(private httpClient: HttpClient,
        private router: Router,
        private _jwtService: JwtHelperService) { }

    register(registerRequestDto: any) {
        return this.httpClient.post<any>(this.registerRequestUrl, registerRequestDto);
    }

    login(loginRequestDto: any) {
        return this.httpClient.post<any>(this.loginRequestUrl, loginRequestDto);
    }

    signOut() {
        // localStorage.removeItem(this.tokenSectionKey)
        localStorage.clear();

        this.router.navigate(['/login']);
    }

    storeToken(tokenValue: string) {
        // use local storage for storing jwt token information
        localStorage.setItem(this.tokenSectionKey, tokenValue); 
    }

    getToken() {
        return localStorage.getItem(this.tokenSectionKey);
    }

    isAuthenticated(): boolean {
        let token = localStorage.getItem(this.tokenSectionKey)

        if(token != null) {
            let isTokenExpired = this._jwtService.isTokenExpired(token);
            
            if(isTokenExpired) { 
                return false;
            }
            else {
                return true;
            }
        }
        return false;
    }
}