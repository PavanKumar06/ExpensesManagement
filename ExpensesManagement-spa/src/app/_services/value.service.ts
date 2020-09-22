import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValueService {
  baseUrl = 'http://localhost:5000/api/';

constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  getValues() {
    return this.http.get(this.baseUrl + 'values');
  }

  // tslint:disable-next-line: typedef
  getValue(username: string) {
    return this.http.get(this.baseUrl + 'values/' + username);
  }

  // tslint:disable-next-line: typedef
  postResponse(response: any) {
    return this.http.post(this.baseUrl + 'response', response);
  }

  // tslint:disable-next-line: typedef
  downloadFile(path: string): any {
    return this.http.get(this.baseUrl + 'values/register/' + path, {responseType: 'blob'});
}

}
