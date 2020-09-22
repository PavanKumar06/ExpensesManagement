import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { EmployeeComponent } from './employee/employee.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { ManagerComponent } from './manager/manager.component';
import { JwtModule } from '@auth0/angular-jwt';

// tslint:disable-next-line: typedef
export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    EmployeeComponent,
    ManagerComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
      // tslint:disable-next-line: object-literal-shorthand
      tokenGetter: tokenGetter,
      allowedDomains: ['localhost:5000'],
      disallowedRoutes: ['localhost:5000/api/auth']
      }
   })
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    NavComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
