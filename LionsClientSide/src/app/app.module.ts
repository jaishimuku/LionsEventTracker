import { NavbarComponent } from './home/navbar/navbar.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';




import { AppComponent } from './app.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import {HttpClientModule} from '@angular/common/http';
import { EventcreateComponent } from './eventcreate/eventcreate.component';
import { LandingpageComponent } from './landingpage/landingpage.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MyFilterPipe } from './my-filter.pipe';
import { ProfileComponent } from './profile/profile.component';
import { CompareValidatorDirective } from './sharedd/compare-validator.directive';
import { UpdateeventComponent } from './updateevent/updateevent.component';

const appRoutes: Routes = [
  {path: '', component: LoginComponent},
  { path: 'signup', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'landingpage', component: LandingpageComponent },
  { path: 'eventcreate', component: EventcreateComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'navbar', component: NavbarComponent },
  { path: 'profile', component: ProfileComponent},
  { path: 'updateevent', component: UpdateeventComponent}
  ];

@NgModule({
   declarations: [
      AppComponent,
      SignUpComponent,
      LoginComponent,
      HomeComponent,
      EventcreateComponent,
      LandingpageComponent,
      HeaderComponent,
      FooterComponent,
            NavbarComponent,
      MyFilterPipe,
      ProfileComponent,
      CompareValidatorDirective,
      UpdateeventComponent,
   ],
   imports: [
      BrowserModule,
      RouterModule.forRoot(appRoutes, { 
         onSameUrlNavigation: 'reload'
      }),
      FormsModule,
      HttpClientModule,

   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
