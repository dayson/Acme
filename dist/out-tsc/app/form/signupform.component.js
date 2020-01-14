import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { Person } from "../shared/person";
let SignupForm = class SignupForm {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.activities = ['Movie', 'Board Games', 'Video Games', 'Brew Beer', 'Escape Room'];
        this.person = new Person("00000000-0000-0000-0000-000000000000", "", "", "", "", "");
        this.errorMessage = "";
    }
    onSubmit() {
        this.data.signup(this.person)
            .subscribe(success => {
            if (success) {
                this.router.navigate(["listing"]);
            }
            else {
                this.router.navigate([""]);
            }
        }, err => this.errorMessage = "Failed to sign up");
    }
};
SignupForm = __decorate([
    Component({
        selector: "signup-form",
        templateUrl: "./signupform.component.html",
        styleUrls: []
    })
], SignupForm);
export { SignupForm };
//# sourceMappingURL=signupform.component.js.map