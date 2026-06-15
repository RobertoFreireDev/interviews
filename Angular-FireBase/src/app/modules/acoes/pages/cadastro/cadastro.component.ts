import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { CadastroTabsEnum } from './cadastrotabs-enum'

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  tabs: {
    novoOuEdicao: CadastroTabsEnum,
    lista : CadastroTabsEnum
  } = {
    novoOuEdicao: CadastroTabsEnum.novo,
    lista : CadastroTabsEnum.lista
  };

  constructor(private route : ActivatedRoute,
              public router : Router){}

  ngOnInit(): void {
    this.route.url.subscribe(() => {
      if ('/acoes/cadastro/edicao' === window.location.pathname){
        this.tabs.novoOuEdicao = CadastroTabsEnum.edicao;
      } else {
        this.tabs.novoOuEdicao = CadastroTabsEnum.novo;
      }
    });
  }

  ehRotaEdicaoOuNovo(){
    return this.router.url.includes('/acoes/cadastro/edicao') || this.router.url.includes('/acoes/cadastro/novo');
  }
}
