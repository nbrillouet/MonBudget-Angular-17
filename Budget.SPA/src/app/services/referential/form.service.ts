import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Injectable()
export class FormService {
    constructor(
        private _formBuilder: FormBuilder
    ) { }

    createForm(formObject,validators): FormGroup {
        const form: FormGroup = this._formBuilder.group({init:null});
        // let obj = new AccountForDetail();
        // this.form = this._formBuilder.group({init:null});

        Object.keys(formObject).forEach((key) => {
            form.addControl(key, new FormControl(null,validators[key]));
        }
        );

        return form;
    }
}
