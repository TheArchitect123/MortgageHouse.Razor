import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http'; //Will be used for sending the data off to the
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlResources } from '../Constants/UrlResources';
import { SecurityConstants } from '../constants/securityConstants';
import { Routes } from '../routes/routes';

@Injectable()
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

  public ExtractAllImages(): Observable<string> {
    //invoke the http client api, to send the details off
    return this.httpClient.get<string>(UrlResources.TestCommonPostEndpoint.concat(Routes._ExtractImages), {
      headers: this.headers
    });
  }

  public DeleteAllImages(): Observable<string> {
    return this.httpClient.get<string>(UrlResources.TestCommonPostEndpoint.concat(Routes._DeleteAllImages), {
      headers: this.headers
    });
  }
}
