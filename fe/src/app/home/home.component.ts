import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { MotorcycleTypes } from '../_interfaces/motorcycle-types/get-motorcycle-types/motorcycle-types.model';
import { MotorcycleTypesService } from '../services/motorcycle-types.service';
import { GetMotorcycleTypesResponse } from '../_interfaces/motorcycle-types/get-motorcycle-types/get-motorcycle-types.response.model';
import { BriefPostDto } from '../_interfaces/posts/get-brief-post/brief-post-dto.model';
import { PostsService } from '../services/posts.service';
import { PaginatedList } from '../_interfaces/paginated-list.model';
import { GetBriefPostResponse } from '../_interfaces/posts/get-brief-post/get-brief-post.response.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  public users: any = []
  motorcycleTypes: MotorcycleTypes[]
  lstPost: BriefPostDto[]
  

  constructor(
    private motorcycleTypesService: MotorcycleTypesService,
    private postsService: PostsService,
    private authService: AuthService) {}


  ngOnInit(): void {
    this.motorcycleTypesService.getMotorcycleTypes()
    .subscribe(
      (response: GetMotorcycleTypesResponse) => {
        this.motorcycleTypes = response.items;
        console.log(response.items);
      }
      ,
      (error) => console.log(error)
    );

    this.loadProductPostsData();
  }

  private loadProductPostsData() {
    this.postsService.getBriefPosts()
    .subscribe(
      (data: PaginatedList<BriefPostDto>) => {
        let response = data;
        if(response.items.length == 0 || response.items == null) {
          return;
        }
        console.log(response.items)
        this.lstPost = response.items
      },
      error => console.log(error)
    );
  }
}
