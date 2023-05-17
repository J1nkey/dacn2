import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetSlidesResponse } from '../_interfaces/slide/get-slides.response.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SlideService {
  private baseApiUrl: string = "https://localhost:7228/api/slides";
  constructor(private httpClient: HttpClient) { }

  getSlides(): Observable<GetSlidesResponse> {
    var httpResponse = this.httpClient.get<GetSlidesResponse>(this.baseApiUrl + "/GetSlides");
    return httpResponse;
  }
}
