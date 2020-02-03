import { __decorate } from "tslib";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppComponent } from "./app.component";
import { Signup } from "./signup/signup.component";
import { PersonList } from "./list/personlist.component";
import { SignupForm } from "./form/signupform.component";
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule } from "@angular/forms";
let routes = [
    { path: "", component: Signup },
    { path: "listing", component: PersonList }
];
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            Signup,
            SignupForm,
            PersonList
        ],
        imports: [
            BrowserModule,
            HttpClientModule,
            ReactiveFormsModule,
            RouterModule.forRoot(routes, {
                useHash: true,
                enableTracing: false // for debugging of the routes
            })
        ],
        providers: [],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map