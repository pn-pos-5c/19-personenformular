import {Injectable} from '@angular/core';
import {Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NotifierService {
  subject = new Subject<string>();

  listen(): Observable<string> {
    return this.subject.asObservable();
  }

  notify(): void {
    console.log(`NotifierService::notify`);
    this.subject.next('');
  }

  constructor() {
  }
}
