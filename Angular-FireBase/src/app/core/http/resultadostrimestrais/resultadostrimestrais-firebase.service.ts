import { Injectable } from "@angular/core";
import { AngularFireDatabase } from "@angular/fire/database";
import { Observable } from "rxjs";

import { ResultadoTrimestralModel } from "src/app/shared/models/resultado-trimestral.model";

@Injectable({
  providedIn: 'root'
})
export class ResultadosTrimestraisService {

  constructor(private afb: AngularFireDatabase) { }

  salvarNovoResultado(resultado : ResultadoTrimestralModel) : void {
    this.afb.object('resultadostrimestrais/' + resultado.acaoSimbolo).set(resultado);
  }

  atualizarResultado(resultado : ResultadoTrimestralModel) : void {
    this.afb.object('resultadostrimestrais/' + resultado.acaoSimbolo).update(resultado);
  }

  obterResultados() : Observable<any> {
    return this.afb.list('resultadostrimestrais').valueChanges();
  }

  deletarResultados(resultado : ResultadoTrimestralModel) : void {
    this.afb.object('resultadostrimestrais/' + resultado.acaoSimbolo).remove();
  }
}
