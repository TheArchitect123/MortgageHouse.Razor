import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http'; //Will be used for sending the data off to the
import { Injectable } from '@angular/core';
import { UrlResources } from '../Constants/UrlResources';
import { SecurityConstants } from '../constants/securityConstants';
import { Routes } from '../routes/routes';
import { StringHelper } from '../helpers/stringHelper';

@Injectable({

  providedIn: 'root',
})
export class ImageExtractionService {

  constructor(private httpClient: HttpClient) { }

  private readonly headers: HttpHeaders = this.generateSecurityHeaders();
  private generateSecurityHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      xUsername: SecurityConstants.xUsername,
      xPassword: SecurityConstants.xPassword,
    });
  }

  public ExtractAllImages() {
    this.httpClient.get(UrlResources.TestCommonPostEndpoint.concat(Routes._ExtractImages))
      .subscribe(e => StringHelper.isEmpty(e) ? "mmm...Something went wrong" : alert('Successfully extracted all images on the database'));
  }

  public DeleteAllImages() {

    this.httpClient.get(UrlResources.TestCommonPostEndpoint.concat(Routes._DeleteAllImages))
      .subscribe(e => StringHelper.isEmpty(e) ? "mmm...Something went wrong" : alert('Successfully deleted all images on the database'));
  }
}
