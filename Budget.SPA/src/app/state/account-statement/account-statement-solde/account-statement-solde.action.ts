import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';

export const AS_SOLDE_CHANGE = 'as-solde-change';


export class ChangeAsSolde {
    static readonly type = AS_SOLDE_CHANGE;

    constructor(public payload: FilterAsMainSelected) { }
}

// export class LoadAsSoldeSuccess {
//     static readonly type = AS_SOLDE_LOAD_SUCCESS;

//     constructor(public payload: any) { }
// }

// export class ChangeAsSoldeFilter {
//     static readonly type = AS_SOLDE_CHANGE;

//     constructor(public payload: FilterAsTableSelected) { }
// }
