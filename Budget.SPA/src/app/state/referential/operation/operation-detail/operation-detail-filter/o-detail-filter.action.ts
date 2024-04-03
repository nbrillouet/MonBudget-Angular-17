import { OForDetail } from 'app/model/referential/operation.model';

export const O_DETAIL_FILTER_LOAD = 'o-detail-filter-load';
export const O_DETAIL_FILTER_CLEAR = 'o-detail-filter-clear';

export class LoadODetailFilter {
    static readonly type = O_DETAIL_FILTER_LOAD;

    constructor(public payload: OForDetail) { }
}

export class ClearODetailFilter {
    static readonly type = O_DETAIL_FILTER_CLEAR;
}

// export const O_DETAIL_LOAD = 'o-detail-load';
// export const O_DETAIL_SAVE = 'o-detail-save';
// export const O_DETAIL_CLEAR = 'o-detail-clear';

// export class LoadODetail {
//     static readonly type = O_DETAIL_LOAD;

//     constructor(public payload: FilterForDetail) { }
// }

// export class SaveODetail {
//     static readonly type = O_DETAIL_SAVE;

//     constructor(public payload: OForDetail) { }
// }

// export class ClearODetail {
//     static readonly type = O_DETAIL_CLEAR;
// }

// export const OPERATION_DETAIL_FILTER_LOAD = 'operation-detail--filter-load';
// export const OPERATION_DETAIL_FILTER_CLEAR = 'operation-detail-filter-clear';

// export class LoadODetailFilter {
//     static readonly type = OPERATION_DETAIL_FILTER_LOAD;

//     constructor(public payload: OForDetail) { }
// }

// export class ClearODetailFilter {
//     static readonly type = OPERATION_DETAIL_FILTER_CLEAR;
// }
