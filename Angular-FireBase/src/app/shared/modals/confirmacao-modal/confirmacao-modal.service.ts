import { Subject } from "rxjs/internal/Subject";

export class ConfirmacaoModalService {
  botaoAbrirModalClidado: Subject<string> = new Subject();

  constructor() {
  }
}
