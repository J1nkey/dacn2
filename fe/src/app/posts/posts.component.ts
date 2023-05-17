import { Component, OnInit } from '@angular/core';
import { PostsService } from '../services/posts.service';
import { BriefPostDto } from '../_interfaces/posts/get-brief-post/brief-post-dto.model';
import { PaginatedList } from '../_interfaces/paginated-list.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})

export class PostsComponent implements OnInit {
  lstBriefPost: PaginatedList<BriefPostDto>;
  fromPrice: number;
  toPrice: number;
  
  FilterData: any = [];
  PostList: any = [];

  constructor(private postsService: PostsService) {}

  ngOnInit(): void {
    this.postsService.getBriefPosts()
    .subscribe(
      (data) => {
        this.lstBriefPost = data;
      },
      (error) => console.log(error)
    );

    this.postsService.getPosts()
    .subscribe(
      (data: any) => {
        this.FilterData = data.FilterData;
        this.PostList = data.PostList;
      },
      (error) => console.log(error)
    );
  }

}
