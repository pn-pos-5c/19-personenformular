import {Component, OnInit} from '@angular/core';
import {DataProviderService} from "../../../core/services/data-provider.service";
import Person from "../../../../models/Person";
import {NotifierService} from "../../../core/services/notifier.service";

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.scss']
})
export class PersonEditComponent implements OnInit {
  firstname: string = '';
  lastname: string = '';
  birthday: string = '';
  tel: string = '';
  adress: string = '';

  firstnameRegex: RegExp = /^[A-Z][a-z]{2,}$/;
  lastnameRegex: RegExp = /^[A-Z][a-z]{2,}$/;
  birthdayRegex: RegExp = /^\d{2}.\d{2}.\d{4}$/;
  telRegex: RegExp = /^\+\d{2}\s\(\d{1,3}\)\s\d{4,6}$/;
  adressRegex: RegExp = /^([A-Z])-(\d{4})\s(\w+),\s(\w+)\s(\d+)$/;

  firstnameValid = true;
  lastnameValid = true;
  birthdayValid = true;
  telValid = true;
  adressValid = true;

  constructor(private dataProvider: DataProviderService, private notifier: NotifierService) {
  }

  ngOnInit(): void {
  }

  savePerson(): void {
    this.firstnameValid = this.firstnameRegex.test(this.firstname);
    this.lastnameValid = this.lastnameRegex.test(this.lastname);
    this.birthdayValid = this.birthdayRegex.test(this.birthday);
    this.telValid = this.telRegex.test(this.tel);
    this.adressValid = this.adressRegex.test(this.adress);

    if (this.firstnameValid && this.lastnameValid && this.birthdayValid && this.telValid && this.adressValid) {

      const person: Person = {
        id: -1,
        firstname: this.firstname,
        lastname: this.lastname,
        born: this.birthday,
        tel: this.tel,
        adress: this.adress
      };

      this.dataProvider.addPerson(person).subscribe(res => this.notifier.notify());
    }
  }
}
