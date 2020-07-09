//Http Client Handlers
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SecurityConstants } from '../Constants/SecurityConstants';
import { Injectable } from '@angular/core';
import { common_routes } from '../routes/common-routes'

//Local resources
import { UrlResources } from '../Constants/UrlResources';

@Injectable()
export class Image_extractionService {
  constructor(private http: HttpClient) { }

  private readonly headers: HttpHeaders = this.generateHeaders();
  private generateHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      xUsername: SecurityConstants.xUsername,
      xPassword: SecurityConstants.xPassword,
    });
  }

  ExtractAllData(): Observable<boolean> {
    return this.http.get<boolean>(UrlResources.CommonPostEndpoint.concat(common_routes._extractAllData), {
      headers: this.headers
    });
  }

  DeleteAllData() {
    return this.http.get<boolean>(UrlResources.CommonPostEndpoint.concat(common_routes._removeAllData), {
      headers: this.headers
    });
  }
}
