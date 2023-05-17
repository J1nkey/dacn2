import { Component, Input, OnInit } from '@angular/core';
import { PostsService } from '../services/posts.service';
import { Router } from '@angular/router';
import { PostViewModel } from '../_interfaces/posts/get-post-by-id/post-viewmodel.model';

@Component({
  selector: 'app-detail-post',
  templateUrl: './detail-post.component.html',
  styleUrls: ['./detail-post.component.css']
})

export class DetailPostComponent implements OnInit {
  @Input() id: string = '';
  currentPost: PostViewModel;

  constructor(private _postsService: PostsService,
    private readonly _router: Router) { }

  ngOnInit(): void {
    this.getDetailPost();
  }

  getDetailPost() {
    let postId = Number(this.id);
    if(isNaN(postId)) {
      console.log(postId);
      this._router.navigate(['**']);

      return;
    }

    console.log(postId);
    this._postsService.getPostById(postId)
    .subscribe(
      (response) => {
        console.log(response);
        this.currentPost = response.data;
        console.log(this.currentPost);
      },
      (error) => console.log(error)
    );
  }
}