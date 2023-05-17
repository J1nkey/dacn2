import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetMotorcycleTypesResponse } from '../_interfaces/motorcycle-types/get-motorcycle-types/get-motorcycle-types.response.model';
import { Observable } from 'rxjs';
import { ApiBaseService } from './api-base.service';

@Injectable({
  providedIn: 'root'
})
export class MotorcycleTypesService extends ApiBaseService {
  private API_SECTION: string = "api/MotorcycleTypes/";
  private fullPath: string = '';
  constructor(http: HttpClient) {
    super(http);
    this.fullPath = this.BASE_URL + this.API_SECTION;
  }

  getMotorcycleTypes(): Observable<GetMotorcycleTypesResponse> {
    let response = this.http.get<GetMotorcycleTypesResponse>(this.fullPath + "GetMotorcycleTypes");
    return response;
  }
}
