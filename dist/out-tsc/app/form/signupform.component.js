import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
let SignupForm = class SignupForm {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.activities = ['Movie', 'Board Games', 'Video Games', 'Brew Beer', 'Escape Room'];
        this.errorMessage = "";
    }
    ngOnInit() {
        this.supForm = new FormGroup({
            firstName: new FormControl(),
            lastName: new FormControl(),
            email: new FormControl(),
            activity: new FormControl(),
            comment: new FormControl()
        });
    }
    save() {
        console.log(this.supForm);
        console.log("Saved: " + JSON.stringify(this.supForm.value));
        const p = Object.assign(Object.assign({}, this.person), this.supForm.value);
        this.data.signup(p)
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