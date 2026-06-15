import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

import { AcoesService } from 'src/app/core/services/acoes/acoes.service';
import { AcaoModel } from 'src/app/shared/models/acao.model';
import { ResultadoTrimestralModel } from 'src/app/shared/models/resultado-trimestral.model';
import { ResultadosTrimestraisService } from './../../../../../core/http/resultadostrimestrais/resultadostrimestrais-firebase.service';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {
  agendamentoForm: FormGroup;
  model: NgbDateStruct;
  acoesDisponiveis : string[] = [];
  trimestresDisponiveis : string[] = [];
  acoes : AcaoModel[];

  constructor(private acoesService : AcoesService,
            private resultadosTrimestraisService : ResultadosTrimestraisService,
            private router : Router) {
    this.acoesService.atualizarAcoes();
    this.setarTrimestresDisponiveis();
  }

  setarTrimestresDisponiveis(){
    const dataAtual = new Date();
    const mesAtual = (dataAtual.getMonth() + 1)
    const anoAtual = dataAtual.getFullYear().toString().substring(2);

    if (mesAtual >= 0 && mesAtual <= 3){
      this.trimestresDisponiveis.push("4T" + anoAtual);
    }

    if (mesAtual > 3 && mesAtual <= 6){
      this.trimestresDisponiveis.push("1T" + anoAtual);
    }

    if (mesAtual >= 6 && mesAtual <= 9){
      this.trimestresDisponiveis.push("2T" + anoAtual);
    }

    if (mesAtual >= 9 && mesAtual <= 12){
      this.trimestresDisponiveis.push("3T" + anoAtual);
    }
  }

  ngOnInit(): void {
    this.agendamentoForm = new FormGroup({
      'acaoSimbolo' : new FormControl(null, [Validators.required]),
      'trimestre' : new FormControl(null, [Validators.required]),
      'dataResultadosDoTrimestre' : new FormControl(null, [Validators.required])
    });

    this.acoesService.acoesForamAtualizadas.subscribe(()=>{
      this.acoes = this.acoesService.obterAcoes();
      this.setarAcoesDisponiveis();
    });
  }

  setarAcoesDisponiveis(){
    this.acoesDisponiveis = this.acoes.map(acao => acao.acaoSimbolo);
  };

  salvar(){
    this.resultadosTrimestraisService.salvarNovoResultado(this.agendamentoForm.value as ResultadoTrimestralModel);
    this.router.navigate(["/acoes","agenda","lista"]);
  }
}

