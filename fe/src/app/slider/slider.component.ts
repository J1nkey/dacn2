import { Component, OnInit } from '@angular/core';
import { SlideService } from '../services/slide.service';
import { BaseSlideDto } from '../_interfaces/slide/base-slides-dto.model';
import { GetSlidesResponse } from '../_interfaces/slide/get-slides.response.model';


@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})

export class SliderComponent implements OnInit {
  sliders: BaseSlideDto[] = []

  constructor(private slideService: SlideService) {}

  ngOnInit(): void {
    this.slideService.getSlides().
    subscribe(
      (response: GetSlidesResponse) => {
        for(let slide of response.items) {
          slide.imagePath = 'https://localhost:7228' + this.swapToBackSplash(slide.imagePath)
        }
        this.sliders = response.items;
        // this.sliderImg1 = 'https://localhost:7228' + response.items[0].imagePath 
        // this.sliderImg1 = this.sliderImg1.replace(/\\/g, '/')
        console.log(this.sliders);
      },
      (error) => console.log(error)
    );
  }

  swapToBackSplash(source: string) {
    return source.replace(/\\/g, '/');
  }
}
