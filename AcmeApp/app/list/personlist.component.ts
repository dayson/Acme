import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Person } from "../shared/person";

@Component({
    selector: "person-list",
    templateUrl: "./personlist.component.html",
    styleUrls: []
})

export class PersonList implements OnInit {

    constructor(private data: DataService) {
    }

    public persons: Person[] = [];

    ngOnInit(): void {
        this.data.loadPersons()
            .subscribe(success => {
                if (success) {
                    this.persons = this.data.persons;
                }
            });
    }
}