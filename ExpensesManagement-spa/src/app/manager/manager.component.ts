import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { ValueService } from '../_services/value.service';
import * as fileSaver from 'file-saver';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
  values: any;
  value: any;
  response: any = { };
  username: string;
  submit = true;
  pathFood: string;
  pathFuel: string;
  pathHra: string;
  pathTravel: string;

  constructor(private alertify: AlertifyService, private valueService: ValueService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getValues();
  }

  // tslint:disable-next-line: typedef
  getValues() {
    this.valueService.getValues().subscribe(response => {
      this.values = response;
    }, error => {
      this.alertify.warning('Error in retrieving employees');
    });
  }

  // tslint:disable-next-line: typedef
  getValue() {
    this.valueService.getValue(this.username).subscribe(response => {
      this.value = response;
      this.pathFood = this.value.foodPath;
      this.pathFuel = this.value.fuelPath;
      this.pathHra = this.value.hraPath;
      this.pathTravel = this.value.travelPath;

      this.submit = false;

      this.alertify.success('Success');
    }, error => {
      this.alertify.warning('Could not retrieve data');
    });
  }

  // tslint:disable-next-line: typedef
  postResponse() {
    this.response.name = this.value.name;
    this.response.username = this.value.username;
    if (this.response.food == null)
    {
      this.response.food = 'decline';
    }
    if (this.response.fuel == null)
    {
      this.response.fuel = 'decline';
    }
    if (this.response.hra == null)
    {
      this.response.hra = 'decline';
    }
    if (this.response.travel == null)
    {
      this.response.travel = 'decline';
    }
    this.valueService.postResponse(this.response).subscribe(next => {
      this.alertify.success('Response Sent');
    }, error => {
      this.alertify.error(error);
    });
  }

    // tslint:disable-next-line: typedef
    downloadFile(path: string) {
      this.valueService.downloadFile(path).subscribe(response => {
        const blob: any = new Blob([response], { type: 'charset=utf-8' });
        fileSaver.saveAs(blob, path);
      }, error => {
        console.log('Error ' + error);
      }, () => {
        console.log('Successful');
      });
    }

  // tslint:disable-next-line: typedef
  back() {
    this.submit = true;
    return this.submit;
  }

}
