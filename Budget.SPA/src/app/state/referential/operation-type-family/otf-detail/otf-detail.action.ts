import { FilterForDetail } from '@corporate/model';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';

export const OTF_DETAIL_LOAD = 'otf-detail-load';
export const OTF_DETAIL_SAVE = 'otf-detail-save';
export const OTF_DETAIL_CLEAR = 'otf-detail-clear';

export class LoadOtfDetail {
    static readonly type = OTF_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveOtfDetail {
    static readonly type = OTF_DETAIL_SAVE;

    constructor(public payload: { otfDetail: OtfForDetail } ) { }
}

export class ClearOtfDetail {
    static readonly type = OTF_DETAIL_CLEAR;
}

