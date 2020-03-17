import { Directive, Input } from '@angular/core';
import { Validator, AbstractControl, ValidationErrors, NG_VALIDATORS } from '@angular/forms';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[compare]',
  providers: [{ provide: NG_VALIDATORS, useExisting: CompareValidatorDirective, multi: true }]
})
export class CompareValidatorDirective implements Validator {
  @Input('compare') controlNameToComapre: string;
  
  validate(c: AbstractControl): ValidationErrors | null {
    const controlNameToComapre = c.root.get(this.controlNameToComapre);
    if (controlNameToComapre) {
      const subscription: Subscription = controlNameToComapre.valueChanges.subscribe(() => {
        c.updateValueAndValidity();
        subscription.unsubscribe();
      });
    }
    return controlNameToComapre && controlNameToComapre.value !== c.value ? { 'compare': true } : null;
  }
}
