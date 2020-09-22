import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TaxService {
  baseUrl = 'http://localhost:5000/api/';

constructor(private http: HttpClient) { }

    // tslint:disable-next-line: typedef
    uploadTax(model: any, filesToUpload: File[]) {
      const formData: FormData = new FormData();

      Array.from(filesToUpload).map((file, index) => {
        return formData.append('File ' + index, file, file.name);
      });

      formData.append('FoodAmount', model.foodamount);
      formData.append('FuelAmount', model.fuelamount);
      formData.append('HraAmount', model.hraamount);
      formData.append('TravelAmount', model.travelamount);
      return this.http.post(this.baseUrl + 'tax', formData);
    }

    // tslint:disable-next-line: typedef
    getResponse(username: string) {
      return this.http.get(this.baseUrl + 'response/' + username);
    }
}
