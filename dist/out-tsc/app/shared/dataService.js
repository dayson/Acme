import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.persons = [];
    }
    loadPersons() {
        return this.http.get("api/persons")
            .pipe(map((data) => {
            this.persons = data;
            return this.persons;
        }));
    }
    signup(person) {
        return this.http.post("api/persons", person)
            .pipe(map(() => {
            return person;
        }));
    }
};
DataService = __decorate([
    Injectable({
        providedIn: 'root' // declare that this service should be created by root application injector
    })
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map