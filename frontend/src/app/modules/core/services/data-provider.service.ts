import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import Person from "../../../models/Person";

@Injectable({
  providedIn: 'root'
})
export class DataProviderService {
  private rootUrl = 'http://localhost:5000/api/Persons';

  constructor(private http: HttpClient) {
  }

  public getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.rootUrl);
  }

  public getPerson(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.rootUrl}/${id}`);
  }

  public addPerson(person: Person) {
    return this.http.post(this.rootUrl, person);
  }
}
