import { Injectable } from '@angular/core';
import { DateTimeFactory, MonthYear } from '@corporate/model';
import { UserForAuth, UserForGroup } from 'app/model/referential/user/user.model';
import { isEqual } from 'lodash';

@Injectable({ providedIn: 'root' })
export class HelperService {

    constructor(
    ) { }

    getUtc(date: Date): Date {
        if(date!=null)
        {
            const myDate = new Date(date);
            const utcDate = Date.UTC(myDate.getFullYear(), myDate.getMonth(), myDate.getDate()) - myDate.getTimezoneOffset();
            return new Date(utcDate);
        }
        return null;
    }

    getMonthYear(): MonthYear {
        const currentDate = new Date();
        currentDate.setMonth(currentDate.getMonth()-1);
        const id = currentDate.getMonth()+1;
        const month =  DateTimeFactory.getMonths.filter(x=>x.id===id)[0];
        const monthYear = {
            month: month,
            year: null //annee a null pour forcer anne utilisé par user currentDate.getFullYear()
        } as MonthYear;
        return monthYear;
    }

    getUserForGroupFromStorage(): UserForGroup {
        const userAuth: UserForAuth = JSON.parse(localStorage.getItem('userInfo'));
        const userForGroup: UserForGroup = {id:userAuth.id,idUserGroup:userAuth.idUserGroup};

        return userForGroup;
    }

    getDeepClone(object): any {
        return !object ? null : JSON.parse(JSON.stringify(object));
    }

    areEquals(object1: any, object2: any): any {
        return isEqual(object1, object2); // this.getDeepClone(object1) === this.getDeepClone(object2);
    }

    //affecter une valeur (valueToSet) à une propriété (propertyName) dun objet (object)
    //propertyName est un string , proprietes separé par .
    setDeepProperty(object: any, propertyName: string, valueToSet: any): any {
        const propertySplit = propertyName.split('.');
        const key = propertySplit[0];

        if (propertySplit.length === 1) {
            object[key] = valueToSet;
        }
        else {
            this.setDeepProperty(object[key], propertySplit.slice(1).join('.'), valueToSet);
        }

        return object;
    }

    isFullScreen(): boolean {
        return !(window.screenTop === 0);
    }

}
