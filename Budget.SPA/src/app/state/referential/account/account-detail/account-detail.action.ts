import { FilterForDetail, Select } from '@corporate/model';
import { SelectGMapAddress } from 'app/model/g-map.model.';
import { AccountForDetail } from 'app/model/referential/account.model';

export const ACCOUNT_DETAIL_LOAD = 'account-detail-load';
export const ACCOUNT_DETAIL_SAVE = 'account-detail-save';
export const ACCOUNT_DETAIL_CLEAR = 'account-detail-clear';

export const ACCOUNT_DETAIL_CHANGE_BANK_SUB_FAMILY = 'account-detail-change-bank-sub-family';
export const ACCOUNT_DETAIL_CHANGE_BANK_AGENCY = 'account-detail-change-bank-agency';

export class LoadAccountDetail {
    static readonly type = ACCOUNT_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class SaveAccountDetail {
    static readonly type = ACCOUNT_DETAIL_SAVE;

    constructor(public payload: { accountDetail: AccountForDetail } ) { }
}

export class ClearAccountDetail {
    static readonly type = ACCOUNT_DETAIL_CLEAR;
}

export class AccountDetailChangeBankSubFamily {
    static readonly type = ACCOUNT_DETAIL_CHANGE_BANK_SUB_FAMILY;

    constructor(public payload: { bankSubFamily: Select }) { }
}

export class AccountDetailChangeBankAgency {
    static readonly type = ACCOUNT_DETAIL_CHANGE_BANK_AGENCY;

    constructor(public payload: { bankAgency: SelectGMapAddress }) { }
}
