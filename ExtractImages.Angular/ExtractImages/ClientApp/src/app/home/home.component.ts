import { Component, OnInit } from '@angular/core';
import { ImageExtractionService } from '../service/image-extraction.service';
import { HomeModel } from '../models/HomeModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(private imageService: ImageExtractionService) {

  }

  ngOnInit(): void {
    //initialize the model for this component
    if (this.model == null)
      this.model = new HomeModel();

    this.index = 0;
  }

  //Model
  model: HomeModel;
  index: Number;

  //Extraction & Deletion of images Api
  beginImageExtraction() {
    alert('Extracting results');
    this.imageService.ExtractAllImages().subscribe(e => {
      JSON.parse(e);
    });
  }

  deleteAllData() {
    this.imageService.DeleteAllImages().subscribe(e => {
      console.log(e);
    });
  }

  //Open the selected image
  openSelectedImage() {
   // window.open(this.model.images[this.index].imagePath, "_blank");
  }
}
