import { Component, EventEmitter, Input, Output, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import { SelectControlValueAccessor } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';

import { ModalLabelModel } from '../../../shared/models/modal-label.model';
import { ConfirmacaoModalService } from './confirmacao-modal.service';

@Component({
  selector: 'app-confirmacao-modal',
  templateUrl: './confirmacao-modal.component.html',
  encapsulation: ViewEncapsulation.None,
  styles: [`
    .dark-modal .modal-content {
      color: #52a599;
    }
    .dark-modal .close {
      color: #52a599;
    }
    .red-modal .modal-content {
      color: #e60000;
    }
    .red-modal .close {
      color: #e60000;
    }
  `]
})
export class ConfirmacaoModalComponent {
  @Input() modalLabels : ModalLabelModel;
  @Output() confirmacaoEvent = new EventEmitter<boolean>();
  @ViewChild("content") content: ElementRef;

  corModal: {
    windowClass : string,
    backdropClass: string
  } = null;
  confirmacaoModalSubscription : Subscription;

  constructor(private modalService: NgbModal,
              private confirmacaoModalService : ConfirmacaoModalService) {
    this.confirmacaoModalSubscription = this.confirmacaoModalService.botaoAbrirModalClidado.subscribe((color) => {
      this.setarCor(color);
      this.modalService.open(this.content, this.corModal);
    });
  }

  private setarCor(color : string){
    if (color === 'red'){
      this.corModal = { windowClass: 'red-modal', backdropClass: 'red-backdrop' }
    } else if (color === 'dark'){
      this.corModal = {
        windowClass : 'dark-modal',
        backdropClass: 'dark-backdrop'
      }
    }
  }

  confirmar(){
    this.confirmacaoEvent.emit(true);
  }

  ngOnDestroy(): void {
    this.confirmacaoModalSubscription.unsubscribe();
  }
}
