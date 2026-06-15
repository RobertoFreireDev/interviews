import { Injectable } from '@angular/core';
import { Subject, Subscription } from 'rxjs';

import { AcaoModel } from '../../../shared/models/acao.model';
import { AcoesFirebaseService } from '../../http/acoes/acoes-firebase.service';

@Injectable({
  providedIn: 'root'
})
export class AcoesService {
  private acoes: AcaoModel[] = [];
  private acoesCadastradasSubscription : Subscription;
  acoesForamAtualizadas: Subject<void> = new Subject();

  constructor(private acoesFirebaseService: AcoesFirebaseService) {
    this.atualizarAcoes();
  }

  public atualizarAcoes() : void {
    this.acoesCadastradasSubscription = this.acoesFirebaseService.obterAcoesCadastradas().subscribe(listaAcoes => {
      this.acoes = listaAcoes;
      this.acoesForamAtualizadas.next();
    });
  }

  cadastrarOuEditarAcao(acaoASerCadastrada: AcaoModel) : void {
    const ehEdicao = this.acoes.some(acao => acao.acaoSimbolo === acaoASerCadastrada.acaoSimbolo);
    if (ehEdicao) {
      this.acoesFirebaseService.atualizarAcaoCadastrada(acaoASerCadastrada);
    } else {
      this.acoesFirebaseService.salvarNovaAcaoCadastrada(acaoASerCadastrada);
    }
  }

  obterAcoes() : AcaoModel[]{
    return [...this.acoes]
  }

  obterAcaoPorSimbolo(simbolo : string) : AcaoModel {
    return this.acoes.find(acao => acao.acaoSimbolo == simbolo);
  }

  deletarAcao(acaoASerDeletada: AcaoModel) : AcaoModel[] {
    const index = this.acoes.findIndex(acao => acao.acaoSimbolo === acaoASerDeletada.acaoSimbolo);
    if (index !== -1) {
      this.acoes.splice(index, 1);
    }
    this.acoesFirebaseService.deletarAcaoCadastrada(acaoASerDeletada);
    return this.obterAcoes();
  }
}
