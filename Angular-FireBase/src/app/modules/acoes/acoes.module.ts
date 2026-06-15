import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';

import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { AgendaComponent } from './pages/agenda/agenda.component';
import { NovoComponent } from './pages/cadastro/novo/novo.component';
import { ListaComponent } from './pages/cadastro/lista/lista.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { ToastsContainer } from '../../shared/toast/toasts-container.component';
import { CadastroService } from './pages/cadastro/cadastro.service';
import { ConfirmacaoModalComponent } from '../../shared/modals/confirmacao-modal/confirmacao-modal.component';
import { ConfirmacaoModalService } from '../../shared/modals/confirmacao-modal/confirmacao-modal.service';
import { AgendamentoComponent } from './pages/agenda/agendamento/agendamento.component';
import { ListaAgendaComponent, NgbdSortableHeader } from './pages/agenda/lista-agenda/lista-agenda.component';

@NgModule({
  declarations: [CadastroComponent,
    AgendaComponent,
    NovoComponent,
    ListaComponent,
    ToastsContainer,
    NgbdSortableHeader,
    ConfirmacaoModalComponent,
    AgendamentoComponent,
    ListaAgendaComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers : [CadastroService,ConfirmacaoModalService]
})
export class AcoesModule { }



