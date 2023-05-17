import { Injectable } from '@angular/core';
import { ApiBaseService } from './api-base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BriefPostDto } from '../_interfaces/posts/get-brief-post/brief-post-dto.model';
import { PaginatedList } from '../_interfaces/paginated-list.model';
import { GetPostByIdResponse } from '../_interfaces/posts/get-post-by-id/get-post-by-id.response.model';

@Injectable({
  providedIn: 'root'
})
export class PostsService extends ApiBaseService {

  private API_SECTION = 'api/posts/'; 
  private FULL_PATH = '';
  constructor(http: HttpClient) {
    super(http);
    this.FULL_PATH = this.BASE_URL + this.API_SECTION;
  }

  getBriefPosts = (): Observable<PaginatedList<BriefPostDto>> => {
    let response = this.http.get<PaginatedList<BriefPostDto>>(this.FULL_PATH);
    return response;
  }

  getPosts() {
    return this.http.get(this.FULL_PATH);
  }

  getPostById(id: number): Observable<GetPostByIdResponse> {
    let response = this.http.get<GetPostByIdResponse>(this.FULL_PATH + `GetPostById?id=${id}`);
    return response;
  }
}
