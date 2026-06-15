import { Injectable } from '@angular/core';
import { Subject } from "rxjs/internal/Subject";

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  openModal: Subject<void> = new Subject();

  constructor() { }
}
