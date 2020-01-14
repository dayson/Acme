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
            return true;
        }));
    }
    signup(person) {
        return this.http.post("api/persons", person)
            .pipe(map((response) => {
            return true;
        }));
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map