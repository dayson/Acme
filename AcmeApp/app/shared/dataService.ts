import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { IPerson as Person } from "./IPerson";

@Injectable({
     providedIn : 'root' // declare that this service should be created by root application injector
})
export class DataService {

    constructor(private http: HttpClient) { }

    persons: Person[] = [];

    loadPersons(): Observable<Person[]> {
        return this.http.get("api/persons")
            .pipe(map((data: any[]) => {
                this.persons = data;
                return this.persons;
            }));
    }

    signup(person: Partial<Person>): Observable<Partial<Person>> {
        return this.http.post("api/persons", person)
            .pipe(map(() =>
            {
                return person;
            }));
    }

}