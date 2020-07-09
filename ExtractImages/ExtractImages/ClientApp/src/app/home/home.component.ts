import { Component } from '@angular/core';
import { Image_extractionService } from '../service/image_extraction.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  constructor(private imageService: Image_extractionService) {

  }

  imagePaths: string[] = ["http://235253", "ftp://3254"];

  private showError(message: string) {
    alert(message);
  }

  //Functions
  OnBeginExtraction() {

    this.imageService.ExtractAllData().subscribe((e) => {
      if (e) {
      }
      else {
        //Something broke, show an alert&

        this.showError("mmm...Something went wrong");
      }
    });
  }

  OnBeginReset() {
    //Invoke the rest api to delete all the items
    this.imageService.DeleteAllData().subscribe((e) => {
      if (e) {
      }
      else {
        //Something broke, show an alert

        this.showError("mmm...Something went wrong");
      }
    });
  }
}
