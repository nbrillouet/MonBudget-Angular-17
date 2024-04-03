import { FilterForDetail, Select, SelectCode } from '@corporate/model';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { OperationDetail } from 'app/model/referential/operation-detail.model';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';

export const ASIF_DETAIL_LOAD = 'asif-detail-load';
export const ASIF_DETAIL_SAVE = 'asif-detail-save';
export const ASIF_DETAIL_CHANGE_OPERATION_DETAIL = 'asif-detail-change-operation-detail';
export const ASIF_DETAIL_CHANGE_OPERATION = 'asif-detail-change-operation';
export const ASIF_DETAIL_CHANGE_OTF = 'asif-detail-change-otf';
export const ASIF_DETAIL_CHANGE_OT = 'asif-detail-change-ot';
export const ASIF_DETAIL_CHANGE_OPERATION_TRANSVERSE = 'asif-detail-change-operation-transverse';
export const ASIF_DETAIL_CHANGE_OPERATION_DETAIL_OPERATION_PLACE = 'asif-detail-change-operation-detail-operation-place';
export const ASIF_DETAIL_CHECK_IN_LIST_OTF = 'asif-detail-check-in-list-otf';

export class LoadAsifDetail {
    static readonly type = ASIF_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveAsifDetail {
    static readonly type = ASIF_DETAIL_SAVE;

    constructor(public payload: { asDetail: AsForDetail }) { }
}

export class AsifDetailChangeOperationDetail {
    static readonly type = ASIF_DETAIL_CHANGE_OPERATION_DETAIL;

    constructor(public payload: OperationDetail) { }
}

export class AsifDetailChangeOperationDetailOperationPlace {
    static readonly type = ASIF_DETAIL_CHANGE_OPERATION_DETAIL_OPERATION_PLACE;

    constructor(public payload: {operationPlace: SelectCode; operationMethod: Select } ) { }
}

export class AsifDetailChangeOtf {
    static readonly type = ASIF_DETAIL_CHANGE_OTF;

    constructor(public payload: { otf: SelectCode }) { }
}

export class AsifDetailChangeOt {
    static readonly type = ASIF_DETAIL_CHANGE_OT;

    constructor(public payload: { ot: Select }) { }
}

export class AsifDetailChangeOperation {
    static readonly type = ASIF_DETAIL_CHANGE_OPERATION;

    constructor(public payload: { operation: Select } ) { }
}

export class AsifDetailChangeOperationTransverse {
    static readonly type = ASIF_DETAIL_CHANGE_OPERATION_TRANSVERSE;

    constructor(public payload: OperationTransverse) { }
}



// export class AsifDetailCheckInListOtf {
//     static readonly type = ASIF_DETAIL_CHECK_IN_LIST_OTF;

//     constructor(public payload: SelectCode[]) { }
// }
