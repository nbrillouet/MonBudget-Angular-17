import { OtfForDetail } from 'app/model/referential/operation-type-family.model';

export const OTF_DETAIL_FILTER_LOAD = 'otf-detail-filter-load';
export const OTF_DETAIL_FILTER_CLEAR = 'otf-detail-filter-clear';

export class LoadOtfDetailFilter {
    static readonly type = OTF_DETAIL_FILTER_LOAD;

    constructor(public payload: OtfForDetail) { }
}

export class ClearOtfDetailFilter {
    static readonly type = OTF_DETAIL_FILTER_CLEAR;
}
