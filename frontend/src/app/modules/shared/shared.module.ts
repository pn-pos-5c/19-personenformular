import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonListComponent } from './components/person-list/person-list.component';
import { PersonEditComponent } from './components/person-edit/person-edit.component';
import {FormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    PersonListComponent,
    PersonEditComponent
  ],
  exports: [
    PersonEditComponent,
    PersonListComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class SharedModule { }
