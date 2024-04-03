import { Injectable } from '@angular/core';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';

@Injectable()
export class HelperFilterService {

    constructor(
    ) { }

    public isFullFill(filter: FilterAsMainSelected): boolean{
        if(filter.user && filter.idAccount && filter.monthYear && filter.monthYear.month && filter.monthYear.year) {
            return true;
        }
        return false;
    }

}
