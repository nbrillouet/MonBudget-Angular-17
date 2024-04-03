import { FilterForDetail, Select, SelectCode } from '@corporate/model';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { OperationDetail } from 'app/model/referential/operation-detail.model';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';

export const AS_DETAIL_LOAD = 'as-detail-load';
export const AS_DETAIL_SAVE = 'as-detail-save';
export const AS_DETAIL_CHANGE_OPERATION_DETAIL = 'as-detail-change-operation-detail';
export const AS_DETAIL_CHANGE_OPERATION = 'as-detail-change-operation';
export const AS_DETAIL_CHANGE_OTF = 'as-detail-change-otf';
export const AS_DETAIL_CHANGE_OT = 'as-detail-change-ot';
export const AS_DETAIL_CHANGE_OPERATION_TRANSVERSE = 'as-detail-change-operation-transverse';
export const AS_DETAIL_CHANGE_OPERATION_DETAIL_OPERATION_PLACE = 'as-detail-change-operation-detail-operation-place';
export const AS_DETAIL_CHECK_IN_LIST_OTF = 'as-detail-check-in-list-otf';

export class LoadAsDetail {
    static readonly type = AS_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveAsDetail {
    static readonly type = AS_DETAIL_SAVE;

    constructor(public payload: { asDetail: AsForDetail }) { }
}

export class AsDetailChangeOperationDetail {
    static readonly type = AS_DETAIL_CHANGE_OPERATION_DETAIL;

    constructor(public payload: OperationDetail) { }
}

export class AsDetailChangeOperationDetailOperationPlace {
    static readonly type = AS_DETAIL_CHANGE_OPERATION_DETAIL_OPERATION_PLACE;

    constructor(public payload: {operationPlace: SelectCode; operationMethod: Select } ) { }
}

export class AsDetailChangeOtf {
    static readonly type = AS_DETAIL_CHANGE_OTF;

    constructor(public payload: { otf: SelectCode }) { }
}

export class AsDetailChangeOt {
    static readonly type = AS_DETAIL_CHANGE_OT;

    constructor(public payload: { ot: Select }) { }
}

export class AsDetailChangeOperation {
    static readonly type = AS_DETAIL_CHANGE_OPERATION;

    constructor(public payload: { operation: Select } ) { }
}

export class AsDetailChangeOperationTransverse {
    static readonly type = AS_DETAIL_CHANGE_OPERATION_TRANSVERSE;

    constructor(public payload: OperationTransverse) { }
}

// import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
// import { FilterForDetail } from 'app/model/filters/shared/filterDetail.filter';

// export const AS_DETAIL_LOAD = 'as-detail-load';
// export const AS_DETAIL_SYNCHRONIZE = 'as-detail-synchronize';
// export const AS_DETAIL_CLEAR = 'as-detail-clear';

// export class LoadAsDetail {
//     static readonly type = AS_DETAIL_LOAD;

//     constructor(public payload: FilterForDetail) { }
// }

// export class SynchronizeAsDetail {
//     static readonly type = AS_DETAIL_SYNCHRONIZE;

//     constructor(public payload: AsForDetail) { }
// }

// export class ClearAsDetail {
//     static readonly type = AS_DETAIL_CLEAR;
// }
