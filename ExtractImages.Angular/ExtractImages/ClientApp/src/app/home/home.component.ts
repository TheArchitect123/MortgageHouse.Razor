import { Component, OnInit } from '@angular/core';
import { ImageExtractionService } from '../service/image-extraction.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
/** home component*/
export class HomeComponent implements OnInit {

  constructor(private imageService: ImageExtractionService) {

  }

  ngOnInit(): void {
    //initialize the model for this component

  }

  beginImageExtraction() {
    this.imageService.ExtractAllImages().subscribe(e => {
      console.log(e);
    });
  }

  deleteAllData() {
    this.imageService.DeleteAllImages().subscribe(e => {
      console.log(e);
    });
  }
}
