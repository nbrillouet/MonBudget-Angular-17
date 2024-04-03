import { FilterAsMainSelected, FilterAsTableSelected } from 'app/model/filters/account-statement.filter';

export const AS_INTERNAL_TRANSFERT_LOAD = 'as-internal-transfert-load';
// export const AS_INTERNAL_TRANSFER_CHANGE = 'as-internal-transfer-change';

export class LoadAsInternalTransfertCouple {
    static readonly type = AS_INTERNAL_TRANSFERT_LOAD;

    constructor(public payload: FilterAsMainSelected) { }
}

// export class ChangeAsInternalTransferFilter {
//     static readonly type = AS_INTERNAL_TRANSFER_CHANGE;

//     constructor(public payload: FilterAsTableSelected) { }
// }
