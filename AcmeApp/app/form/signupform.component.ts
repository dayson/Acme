import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";

import { IPerson as Person } from "../shared/IPerson";
import { DataService } from "../shared/dataService";
import { Router } from '@angular/router';

@Component({
    selector: "signup-form",
    templateUrl: "./signupform.component.html",
    styleUrls: []
})
export class SignupForm implements OnInit {
    supForm: FormGroup;
    person: Partial<Person>;

    activities = ['Movie', 'Board Games', 'Video Games', 'Brew Beer', 'Escape Room'];

    constructor(public data: DataService, private router: Router) { }

    ngOnInit() {
        this.supForm = new FormGroup({
            firstName: new FormControl(),
            lastName: new FormControl(),
            email: new FormControl(),
            activity: new FormControl(),
            comment: new FormControl()
        });
    }

    errorMessage: string = "";
    save() {
        console.log(this.supForm);
        console.log("Saved: " + JSON.stringify(this.supForm.value));
        const p = { ...this.person, ...this.supForm.value };
        this.data.signup(p)
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

