import { Component } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Router } from "@angular/router";
import { Person } from "../shared/person";

@Component({
    selector: "signup-form",
    templateUrl: "./signupform.component.html",
    styleUrls: []
})
export class SignupForm {

    constructor(public data: DataService, private router: Router) { }

    activities = ['Movie', 'Board Games', 'Video Games', 'Brew Beer', 'Escape Room'];

    public person = new Person("00000000-0000-0000-0000-000000000000", "", "", "", "", "");

    errorMessage: string = "";
    onSubmit() {
        this.data.signup(this.person)
            .subscribe(success => {
                    if (success) {
                        this.router.navigate(["listing"]);
                    } else {
                        this.router.navigate([""]);
                    }
                },
                err => this.errorMessage = "Failed to sign up");
    }
}
