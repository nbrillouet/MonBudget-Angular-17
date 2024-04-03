
import { FilterForDetail } from '@corporate/model';
import { OtForDetail } from 'app/model/referential/operation-type.model';

export const OT_DETAIL_LOAD = 'ot-detail-load';
export const OT_DETAIL_SAVE = 'ot-detail-save';
export const OT_DETAIL_CLEAR = 'ot-detail-clear';

export class LoadOtDetail {
    static readonly type = OT_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveOtDetail {
    static readonly type = OT_DETAIL_SAVE;

    constructor(public payload: OtForDetail) { }
}

export class ClearOtDetail {
    static readonly type = OT_DETAIL_CLEAR;
}

