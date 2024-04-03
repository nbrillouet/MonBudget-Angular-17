import { OtForDetail } from 'app/model/referential/operation-type.model';

export const OT_DETAIL_FILTER_LOAD = 'ot-detail-filter-load';
export const OT_DETAIL_FILTER_CLEAR = 'ot-detail-filter-clear';

export class LoadOtDetailFilter {
    static readonly type = OT_DETAIL_FILTER_LOAD;

    constructor(public payload: OtForDetail) { }
}

export class ClearOtDetailFilter {
    static readonly type = OT_DETAIL_FILTER_CLEAR;
}
