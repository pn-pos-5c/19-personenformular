import {Component, OnInit} from '@angular/core';
import Person from "../../../../models/Person";
import {DataProviderService} from "../../../core/services/data-provider.service";
import {NotifierService} from "../../../core/services/notifier.service";

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {
  persons: Person[] = [];

  constructor(private dataProvider: DataProviderService, notifier: NotifierService) {
    notifier.listen().subscribe(res => dataProvider.getPersons().subscribe(resolve => this.persons = resolve));
  }

  ngOnInit(): void {
    this.dataProvider.getPersons().subscribe(res => {
      console.log(this.persons);
      this.persons = res
    });
  }

}
