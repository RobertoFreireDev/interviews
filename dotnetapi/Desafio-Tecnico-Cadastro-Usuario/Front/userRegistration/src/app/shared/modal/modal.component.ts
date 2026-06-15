import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';

import { ModalModel } from '../models/modal/modal-model';
import { ModalService } from './modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @Input() modalObject : ModalModel;
  @Output() confirmationEvent = new EventEmitter<boolean>();
  @ViewChild("content") content: ElementRef;

  modalSubscription : Subscription;

  constructor(private modal: NgbModal,
              private modalService : ModalService) {
    this.modalSubscription = this.modalService.openModal.subscribe(() => {
      this.modal.open(this.content);
    });
  }

  confirm(){
    this.confirmationEvent.emit(true);
  }

  ngOnDestroy(): void {
    this.modalSubscription.unsubscribe();
  }
}
