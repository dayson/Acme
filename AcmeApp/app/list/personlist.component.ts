import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { IPerson as Person } from "../shared/IPerson";

@Component({
    selector: "person-list",
    templateUrl: "./personlist.component.html",
    styleUrls: []
})

export class PersonList implements OnInit {

    constructor(private data: DataService) {
    }

    persons$: Observable<Person[]>;

    ngOnInit() {
        this.persons$ = this.data.loadPersons();
    }
}