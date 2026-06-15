import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AcoesService } from 'src/app/core/services/acoes/acoes.service';
import { AcaoModel } from '../../../../../shared/models/acao.model'
import { ConfirmacaoModalService } from 'src/app/shared/modals/confirmacao-modal/confirmacao-modal.service';
import { ModalLabelModel } from 'src/app/shared/models/modal-label.model';

@Component({
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponent implements OnInit {
  acoes: AcaoModel[] = [];
  private acaoASerDeletada : AcaoModel;
  modalLabels : ModalLabelModel = {
    title : "Deleção",
    pergunta : "Deseja deletar esta ação?",
    botao : ""
  };

  constructor(private acoesService : AcoesService,
              private confirmacaoModalService : ConfirmacaoModalService,
              private route : Router) {
  }

  ngOnInit(): void {
    this.acoes = this.acoesService.obterAcoes();

    this.acoesService.acoesForamAtualizadas.subscribe(()=> {
      this.acoes = this.acoesService.obterAcoes();
    });
  }

  editarAcao(acao: AcaoModel){
    this.route.navigate(["/acoes","cadastro","edicao"],{ queryParams : { acao : acao.acaoSimbolo } });
  }

  openModalDeConfirmacaoDeDelecaoDeAcao(acao: AcaoModel){
    this.acaoASerDeletada = acao;
    this.confirmacaoModalService.botaoAbrirModalClidado.next('red');
  }

  confirmadoDelecaoAcao(){
    this.acoes = this.acoesService.deletarAcao(this.acaoASerDeletada);
  }
}
