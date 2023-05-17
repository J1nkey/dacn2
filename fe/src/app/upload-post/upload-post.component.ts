import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-upload-post',
  templateUrl: './upload-post.component.html',
  styleUrls: ['./upload-post.component.css']
})
export class UploadPostComponent implements OnInit {
  
  progress: number;
  message: string;
  @Output() public onUploadFinished = new EventEmitter();
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
  
  uploadFile = (files: any) => {
    if(files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('imageFile', fileToUpload, fileToUpload.name);

    this.http
    .post('https://localhost:7228/api/Slides/CreateSlide', formData)
    .subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
}
