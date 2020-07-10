import { Component } from '@angular/core';
import { ImageExtractionService } from '../service/image-extraction.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  constructor(private imageService: ImageExtractionService) {

  }

  //Extraction & Deletion of images Api
  beginImageExtraction() {
    this.imageService.ExtractAllImages();
  }

  deleteAllData() {
    this.imageService.DeleteAllImages();
  }
}
