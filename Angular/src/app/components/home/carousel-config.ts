import { Component } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-carousel-config',
  templateUrl: './carousel-config.html',
  providers: [NgbCarouselConfig]  // add NgbCarouselConfig to the component providers
})
export class CarouselConfigComponent {
  images = [
    '../../../assets/images/slide1-4.jpg',
    '../../../assets/images/slide1-2.jpg',
    '../../../assets/images/slide1-3.jpg'
  ];

  constructor(config: NgbCarouselConfig) {
    // customize default values of carousels used by this component tree
    config.interval = 10000;
    config.wrap = true;
    config.keyboard = false;
    config.pauseOnHover = false;
  }
}
