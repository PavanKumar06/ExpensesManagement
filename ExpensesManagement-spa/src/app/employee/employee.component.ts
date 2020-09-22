import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { TaxService } from '../_services/tax.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  model: any = {};
  response: any;
  toggle = false;
  filesToUpload: File[];

  constructor(private taxService: TaxService, private alertify: AlertifyService, private authService: AuthService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  // tslint:disable-next-line: typedef
  uploadTax() {
    this.taxService.uploadTax(this.model, this.filesToUpload).subscribe(() => {
      this.alertify.success('Uploaded Successfully');
    }, error => {
      this.alertify.warning('Already Uploaded');
    });
  }

  // tslint:disable-next-line: typedef
  getResponse() {
    this.taxService.getResponse(this.authService.decodedToken?.unique_name).subscribe(response => {
      this.toggle = true;
      this.response = response;
    }, error => {
      this.alertify.warning('No Response yet');
    });
  }

    // tslint:disable-next-line: typedef
    handleFileInput(files: any) {
      this.filesToUpload = files;

      if (this.filesToUpload.length !== 4)
      {
        this.filesToUpload = null;
        this.alertify.error('Please Enter 4 files');
      }
    }

  // tslint:disable-next-line: typedef
  back() {
    this.toggle = false;
  }

}
