import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { Signup } from "./signup/signup.component";
import { PersonList } from "./list/personlist.component";
import { SignupForm } from "./form/signupform.component";
import { DataService } from "./shared/dataService";

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";

let routes = [
    { path: "", component: Signup },
    { path: "listing", component: PersonList}
];

@NgModule({
  declarations: [
        AppComponent,
        Signup,
        SignupForm,
        PersonList
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(routes,
          {
              useHash: true,
              enableTracing: false // for debugging of the routes
          })
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
