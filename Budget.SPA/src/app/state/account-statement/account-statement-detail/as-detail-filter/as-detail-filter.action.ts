import { Select, SelectCode } from '@corporate/model';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';
import { O } from 'app/model/referential/operation.model';
import { ChangeOperationListParameter } from 'app/services/account-statement/account-statement/detail/form-parameter/as-parameter';

export const AS_DETAIL_FILTER_LOAD = 'as-detail--filter-load';
export const AS_DETAIL_FILTER_CLEAR = 'as-detail-filter-clear';
export const AS_DETAIL_FILTER_CHANGE_OT = 'as-detail-filter-change-ot';
export const AS_DETAIL_FILTER_CHANGE_OPERATION = 'as-detail-filter-change-operation';
export const AS_DETAIL_FILTER_CHANGE_OTF = 'as-detail-filter-change-otf';
export const AS_DETAIL_FILTER_ADD_OPERATION = 'as-detail-filter-add-operation';
export const AS_DETAIL_FILTER_ADD_OPERATION_TRANSVERSE = 'as-detail-filter-add-operation-transverse';

export class LoadAsDetailFilter {
    static readonly type = AS_DETAIL_FILTER_LOAD;

    constructor(public payload: AsForDetail) { }
}

export class ClearAsDetailFilter {
    static readonly type = AS_DETAIL_FILTER_CLEAR;
}

//CHANGE OPERATION TYPE FAMILY
export class AsDetailFilterChangeOtf {
    static readonly type = AS_DETAIL_FILTER_CHANGE_OTF;
    constructor(public payload: { otf: SelectCode; operationMethod: Select }) { }
}

//CHANGE OPERATION TYPE//
export class AsDetailFilterChangeOt {
    static readonly type = AS_DETAIL_FILTER_CHANGE_OT;
    constructor(public payload: {idAccount: number; idMovement: number; ot: Select; otf: SelectCode }) { }
}

//CHANGE OPERATION//
export class AsDetailFilterChangeOperation {
    static readonly type = AS_DETAIL_FILTER_CHANGE_OPERATION;
    constructor(public payload: ChangeOperationListParameter) { }
}

export class AsDetailFilterAddOperation {
    static readonly type = AS_DETAIL_FILTER_ADD_OPERATION;

    constructor(public payload: {operation: O }) { }
}

export class AsDetailFilterAddOperationTransverse {
    static readonly type = AS_DETAIL_FILTER_ADD_OPERATION_TRANSVERSE;

    constructor(public payload: {operationTransverse: OperationTransverse }) { }
}

// import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
// import { FilterOperationType } from 'app/model/filters/operation.filter';
// import { ISelect } from 'app/model/generics/select.model';

// export const AS_DETAIL_FILTER_LOAD = 'as-detail--filter-load';
// export const AS_DETAIL_FILTER_CLEAR = 'as-detail-filter-clear';
// export const AS_DETAIL_FILTER_CHANGE_OTF = 'as-detail-filter-change-otf';
// export const AS_DETAIL_FILTER_CHANGE_OT = 'as-detail-filter-change-ot'

// export class LoadAsDetailFilter {
//     static readonly type = AS_DETAIL_FILTER_LOAD;

//     constructor(public payload: AsForDetail) { }
// }

// export class ClearAsDetailFilter {
//     static readonly type = AS_DETAIL_FILTER_CLEAR;
// }

// //CHANGE OPERATION TYPE FAMILY//
// export class AsDetailFilterChangeOtf {
//     static readonly type = AS_DETAIL_FILTER_CHANGE_OTF;
//     constructor(public payload: ISelect) { }
// }

// //CHANGE OPERATION TYPE//
// export class AsDetailFilterChangeOt {
//     static readonly type = AS_DETAIL_FILTER_CHANGE_OT;
//     constructor(public payload: FilterOperationType) { }
// }
