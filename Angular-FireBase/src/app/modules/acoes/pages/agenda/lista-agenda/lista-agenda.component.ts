import { Component, Directive, EventEmitter, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';

import { AgendaService } from '../agenda.service';
import { ResultadoTrimestralModel } from './../../../../../shared/models/resultado-trimestral.model';

export type SortColumn = typeof ResultadoTrimestralModel | '';
export type SortDirection = 'asc' | 'desc' | '';
const rotate: {[key: string]: SortDirection} = { asc: 'desc', desc: '', '': 'asc' };

export interface SortEvent {
  column: SortColumn;
  direction: SortDirection;
}

@Directive({
  selector: 'th[sortable]',
  host: {
    '[class.asc]': 'direction === "asc"',
    '[class.desc]': 'direction === "desc"',
    '(click)': 'rotate()'
  }
})
export class NgbdSortableHeader {
  @Input() sortable: SortColumn = '';
  @Input() direction: SortDirection = '';
  @Output() sort = new EventEmitter<SortEvent>();

  rotate() {
    this.direction = rotate[this.direction];
    this.sort.emit({ column: this.sortable, direction: this.direction });
  }
}

@Component({
  selector: 'app-lista-agenda',
  templateUrl: './lista-agenda.component.html',
  styleUrls: ['./lista-agenda.component.css']
})
export class ListaAgendaComponent implements OnInit {
  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;
  resultados: ResultadoTrimestralModel[];
  resultadosBackUp : ResultadoTrimestralModel[];

  constructor(private agendaService : AgendaService) { }

  ngOnInit(): void {
    this.resultados = this.agendaService.obterResultados();

    this.agendaService.resultadosForamAtualizados.subscribe(()=> {
      this.resultados = this.agendaService.obterResultados();
    });
  }

  onSort({column, direction}: SortEvent) {
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    // sorting countries
    if (direction === '' || column === '') {
      this.resultados = this.resultadosBackUp;
    } else {
      this.resultados = [...this.resultados].sort((a, b) => {
        let res;
        if (+a.dataResultadosDoTrimestre.month > +b.dataResultadosDoTrimestre.month){
          res = 1;
        } else if (+a.dataResultadosDoTrimestre.month < +b.dataResultadosDoTrimestre.month){
          res = -1;
        } else {
          res = +a.dataResultadosDoTrimestre.day - +b.dataResultadosDoTrimestre.day;
        }

        return direction === 'desc' ? res : -res;
      });
    }

    this.resultadosBackUp = this.resultados;
  }
}
