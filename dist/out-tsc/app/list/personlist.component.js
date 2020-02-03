import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { Observable } from "rxjs";
let PersonList = class PersonList {
    constructor(data) {
        this.data = data;
    }
    ngOnInit() {
        this.persons$ = new Observable(() => {
            this.data.loadPersons();
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