import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class ApiBaseService {
    protected BASE_URL = "https://localhost:7228/"
    constructor(protected http: HttpClient) {}
}