import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListaComponent } from './modules/acoes/pages/cadastro/lista/lista.component';
import { NovoComponent } from './modules/acoes/pages/cadastro/novo/novo.component';
import { CadastroComponent } from './modules/acoes/pages/cadastro/cadastro.component';
import { AgendaComponent } from './modules/acoes/pages/agenda/agenda.component';
import { AgendamentoComponent } from './modules/acoes/pages/agenda/agendamento/agendamento.component';
import { ListaAgendaComponent } from './modules/acoes/pages/agenda/lista-agenda/lista-agenda.component';

const routes: Routes = [
  { path : 'acoes/cadastro', component: CadastroComponent, children: [
      { path : 'novo', component: NovoComponent },
      { path : 'edicao', component: NovoComponent },
      { path : 'lista', component: ListaComponent }
    ]
  },
  { path : 'acoes/agenda', component: AgendaComponent, children: [
    { path : 'agendamento', component: AgendamentoComponent },
    { path : 'lista', component: ListaAgendaComponent }
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
