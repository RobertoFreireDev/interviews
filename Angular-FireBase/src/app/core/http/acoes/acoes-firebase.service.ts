import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';

import { AcaoModel } from '../../../shared/models/acao.model';

@Injectable({
  providedIn: 'root'
})
export class AcoesFirebaseService {
  constructor(private afb: AngularFireDatabase) {}

  salvarNovaAcaoCadastrada(acao : AcaoModel) : void {
    this.afb.object('acoes/' + acao.acaoSimbolo).set(acao);
  }

  atualizarAcaoCadastrada(acao : AcaoModel) : void {
    this.afb.object('acoes/' + acao.acaoSimbolo).update(acao);
  }

  obterAcoesCadastradas() : Observable<any> {
    return this.afb.list('acoes').valueChanges();
  }

  deletarAcaoCadastrada(acao : AcaoModel) : void {
    this.afb.object('acoes/' + acao.acaoSimbolo).remove();
  }
}
