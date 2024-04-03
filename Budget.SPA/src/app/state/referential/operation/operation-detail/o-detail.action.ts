import { FilterForDetail } from '@corporate/model';
import { OForDetail } from 'app/model/referential/operation.model';

export const O_DETAIL_LOAD = 'o-detail-load';
export const O_DETAIL_SAVE = 'o-detail-save';
export const O_DETAIL_CLEAR = 'o-detail-clear';

export class LoadODetail {
    static readonly type = O_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveODetail {
    static readonly type = O_DETAIL_SAVE;

    constructor(public payload: OForDetail) { }
}

export class ClearODetail {
    static readonly type = O_DETAIL_CLEAR;
}

// export const OPERATION_DETAIL_LOAD = 'operation-detail-load';
// export const OPERATION_DETAIL_SYNCHRONIZE = 'operation-detail-synchronize';
// export const OPERATION_DETAIL_CLEAR = 'operation-detail-clear';

// export class LoadOperationDetail {
//     static readonly type = OPERATION_DETAIL_LOAD;

//     constructor(public payload: FilterForDetail) { }
// }

// export class SynchronizeOperationDetail {
//     static readonly type = OPERATION_DETAIL_SYNCHRONIZE;

//     constructor(public payload: OperationForDetail) { }
// }

// export class ClearOperationDetail {
//     static readonly type = OPERATION_DETAIL_CLEAR;
// }

