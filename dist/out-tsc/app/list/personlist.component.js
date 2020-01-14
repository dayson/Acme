import { __decorate } from "tslib";
import { Component } from "@angular/core";
let PersonList = class PersonList {
    constructor(data) {
        this.data = data;
        this.persons = [];
    }
    ngOnInit() {
        this.data.loadPersons()
            .subscribe(success => {
            if (success) {
                this.persons = this.data.persons;
            }
        });
    }
};
PersonList = __decorate([
    Component({
        selector: "person-list",
        templateUrl: "./personlist.component.html",
        styleUrls: []
    })
], PersonList);
export { PersonList };
//# sourceMappingURL=personlist.component.js.map