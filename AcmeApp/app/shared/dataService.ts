import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Person } from "./person";

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    public persons: Person[] = [];
    public person: Person;

    loadPersons(): Observable<boolean> {
        return this.http.get("api/persons")
            .pipe(map((data: any[]) => {
                this.persons = data;
                return true;
            }));
    }

    public signup(person: Person) {
        return this.http.post("api/persons", person)
            .pipe(
            map((response: any) => {
                return true;
            }));
    }

}