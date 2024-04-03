
import { Select, SelectCodeUrl } from '@corporate/model';
import { AccountForDetail } from 'app/model/referential/account.model';

export const ACCOUNT_DETAIL_FILTER_LOAD = 'account-detail-filter-load';
export const ACCOUNT_DETAIL_FILTER_CLEAR = 'account-detail-filter-clear';

export const ACCOUNT_DETAIL_FILTER_CHANGE_BANK_SUB_FAMILY = 'account-detail-filter-change-bank-sub-family';
export const ACCOUNT_DETAIL_FILTER_CHANGE_BANK_AGENCY = 'account-detail-filter-change-bank-agency';

export class LoadAccountDetailFilter {
    static readonly type = ACCOUNT_DETAIL_FILTER_LOAD;

    constructor(public payload: AccountForDetail) { }
}

export class ClearAccountDetailFilter {
    static readonly type = ACCOUNT_DETAIL_FILTER_CLEAR;
}

//CHANGE BANK SUB FAMILY LIST//
export class AccountDetailFilterChangeBankSubFamily {
    static readonly type = ACCOUNT_DETAIL_FILTER_CHANGE_BANK_SUB_FAMILY;
    constructor(public payload: {bankFamily: SelectCodeUrl }) { }
}

//CHANGE BANK AGENCY LIST//
export class AccountDetailFilterChangeBankAgency {
    static readonly type = ACCOUNT_DETAIL_FILTER_CHANGE_BANK_AGENCY;
    constructor(public payload: { bankSubFamily: Select }) { }
}
