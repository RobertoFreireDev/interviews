import { AbstractControl, ValidatorFn } from '@angular/forms';

export function AcaoSimboloValidator(): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    const acaoFormatoRegex = /^[A-Z]{4}(3|4|11|33)$/
    const isValid = acaoFormatoRegex.test(control.value);
    return isValid ? null : { acaoSimbolo : {value: control.value}} ;
  };
}
