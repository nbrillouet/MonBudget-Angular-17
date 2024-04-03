import { CorpDataForm } from '@corporate/data';
import { AbstractControl } from '@angular/forms';

export class GenericFormComponent {

    getValue(service: CorpDataForm<any, any>, property: any): any {
        return service.form.getValue(property);
    }

    getControl(service: CorpDataForm<any, any>, property: string): AbstractControl {
        return service.form.getControl(property);
    }

    getProperty(service: CorpDataForm<any, any>, property: any): string {
        return service.form.getProperty(property);
    }

    /**
     * Track by function for ngFor loops
     *
     * @param index
     * @param item
     */
     trackByFn(index: number, item: any): any
     {
         return item.id || index;
     }

     compareObjects(o1: any, o2: any): boolean {
        if(o1?.label === o2?.label && o1?.id === o2?.id ) {
            return true;
        }
        return false;
    }
}

