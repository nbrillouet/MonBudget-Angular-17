import { Select, SelectCode } from '@corporate/model';
import { AsifForDetail } from 'app/model/account-statement-import/account-statement-import-file.model';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';
import { O } from 'app/model/referential/operation.model';
import { ChangeOperationListParameter } from 'app/services/account-statement/account-statement-import-file/detail/form-parameter/asif.parameter';

export const ASIF_DETAIL_FILTER_LOAD = 'asif-detail--filter-load';
export const ASIF_DETAIL_FILTER_CLEAR = 'asif-detail-filter-clear';
export const ASIF_DETAIL_FILTER_CHANGE_OT = 'asif-detail-filter-change-ot';
export const ASIF_DETAIL_FILTER_CHANGE_OPERATION = 'asif-detail-filter-change-operation';
export const ASIF_DETAIL_FILTER_CHANGE_OTF = 'asif-detail-filter-change-otf';
export const ASIF_DETAIL_FILTER_ADD_OPERATION = 'asif-detail-filter-add-operation';
export const ASIF_DETAIL_FILTER_ADD_OPERATION_TRANSVERSE = 'asif-detail-filter-add-operation-transverse';

export class LoadAsifDetailFilter {
    static readonly type = ASIF_DETAIL_FILTER_LOAD;

    constructor(public payload: AsifForDetail) { }
}

export class ClearAsifDetailFilter {
    static readonly type = ASIF_DETAIL_FILTER_CLEAR;
}

//CHANGE OPERATION TYPE FAMILY
export class AsifDetailFilterChangeOtf {
    static readonly type = ASIF_DETAIL_FILTER_CHANGE_OTF;
    constructor(public payload: { otf: SelectCode; operationMethod: Select }) { }
}

//CHANGE OPERATION TYPE//
export class AsifDetailFilterChangeOt {
    static readonly type = ASIF_DETAIL_FILTER_CHANGE_OT;
    constructor(public payload: {idAccount: number; idMovement: number; ot: Select; otf: SelectCode }) { }
}

//CHANGE OPERATION//
export class AsifDetailFilterChangeOperation {
    static readonly type = ASIF_DETAIL_FILTER_CHANGE_OPERATION;
    constructor(public payload: ChangeOperationListParameter) { }
}

export class AsifDetailFilterAddOperation {
    static readonly type = ASIF_DETAIL_FILTER_ADD_OPERATION;

    constructor(public payload: {operation: O }) { }
}

export class AsifDetailFilterAddOperationTransverse {
    static readonly type = ASIF_DETAIL_FILTER_ADD_OPERATION_TRANSVERSE;

    constructor(public payload: {operationTransverse: OperationTransverse }) { }
}
