import { Subject, Subscription } from 'rxjs';

import { ResultadoTrimestralModel } from 'src/app/shared/models/resultado-trimestral.model';
import { AcoesModule } from './../../acoes.module';
import { ResultadosTrimestraisService } from '../../../../core/http/resultadostrimestrais/resultadostrimestrais-firebase.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AgendaService {
  private resultadosTrimestrais: ResultadoTrimestralModel[] = [];
  private resultadosSubscription : Subscription;
  resultadosForamAtualizados: Subject<void> = new Subject();

  constructor(private resultadosTrimestraisService : ResultadosTrimestraisService) {
    this.atualizarResultados();
  }

  public atualizarResultados() : void {
    this.resultadosSubscription = this.resultadosTrimestraisService.obterResultados().subscribe(resultados => {
      this.resultadosTrimestrais = resultados;
      this.resultadosForamAtualizados.next();
    });
  }

  obterResultados() : ResultadoTrimestralModel[]{
    return [...this.resultadosTrimestrais]
  }

  atualizarResultadosTrimestrais(resultado : ResultadoTrimestralModel){
    this.resultadosTrimestraisService.salvarNovoResultado(resultado);
  }
}
