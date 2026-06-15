import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { AcaoSimboloValidator } from '../../../../../shared/formValidators/acaoSimbolos';
import { AcoesService } from '../../../../../core/services/acoes/acoes.service'
import { AcaoModel } from './../../../../../shared/models/acao.model';
import { ToastService } from '../../../../../shared/toast/toast-service';
import { ModalLabelModel } from './../../../../../shared/models/modal-label.model';
import { ConfirmacaoModalService } from 'src/app/shared/modals/confirmacao-modal/confirmacao-modal.service';

@Component({
  templateUrl: './novo.component.html',
  styleUrls: ['./novo.component.css'],
  providers : []
})
export class NovoComponent implements OnInit {
  cadastroForm: FormGroup;
  ehModoDeEdicao : boolean;
  modalLabels : ModalLabelModel = {
    title : "Cadastro",
    pergunta : "Deseja cadastrar esta ação?",
    botao : "Cadastrar"
  };

  constructor(private acoesService : AcoesService,
              private toastService: ToastService,
              private route : ActivatedRoute,
              private router : Router,
              private confirmacaoModalService : ConfirmacaoModalService){
    this.acoesService.atualizarAcoes();
  };

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      'acaoSimbolo' : new FormControl(null, [Validators.required, AcaoSimboloValidator()]),
      'empresa' : new FormControl(null, Validators.required)
    });

    this.cadastroForm.valueChanges.subscribe(value => {
      this.validarCampos(value);
    });

    this.ehModoDeEdicao = this.obterInfoEhModoDeEdicao();

    if (this.ehModoDeEdicao){
      this.setarModalLabelsCasoEdicao();
      this.acoesService.acoesForamAtualizadas.subscribe(() => {
        this.setarAcaoASerEditada();
      });
    } else {
      this.setarModalLabelsCasoCriacao();
    }
  }

  validarCampos(value: any){
    const acaoEditadaJaExiste = this.acoesService.obterAcaoPorSimbolo(value.acaoSimbolo);
    if (acaoEditadaJaExiste && !this.ehModoDeEdicao){
      this.cadastroForm.controls['acaoSimbolo'].setErrors({ 'acaoJaExiste' : true });
    }
  }

  private obterInfoEhModoDeEdicao() : boolean{
    return this.route.snapshot.url[0].path === 'edicao';
  }

  private setarModalLabelsCasoEdicao(){
    this.modalLabels = {
      title : "Edição",
      pergunta : "Deseja editar esta ação?",
      botao : "Editar"
    };
  }

  private setarModalLabelsCasoCriacao(){
    this.ehModoDeEdicao = false;
    this.modalLabels = {
      title : "Cadastro",
      pergunta : "Deseja cadastrar esta ação?",
      botao : "Cadastrar"
    };
  }

  private setarAcaoASerEditada(){
    const simboldoDaAcaoASerEditada = this.route.snapshot.queryParams.acao;
    const acaoASerEditada = this.acoesService.obterAcaoPorSimbolo(simboldoDaAcaoASerEditada);

    if (!acaoASerEditada) return;

    this.cadastroForm.setValue({
      acaoSimbolo : acaoASerEditada.acaoSimbolo,
      empresa : acaoASerEditada.empresa
    });
  }

  confirmadoCadastrarOuEditarAcao(){
    if (this.cadastroForm.invalid) return;

    this.acoesService.cadastrarOuEditarAcao(this.cadastroForm.value as AcaoModel);

    this.toastService.show(`Ação ${this.cadastroForm.get('acaoSimbolo').value} ${ this.ehModoDeEdicao ? 'alterada' : 'cadastrada'}`, { classname: 'bg-success text-light', delay: 1000 });

    this.router.navigate(["/acoes","cadastro","lista"]);
  }

  openModalDeConfirmacao(){
    if (this.cadastroForm.invalid) return;

    this.confirmacaoModalService.botaoAbrirModalClidado.next('');
  }
}
