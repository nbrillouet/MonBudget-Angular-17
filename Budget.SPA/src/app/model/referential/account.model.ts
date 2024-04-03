/* eslint-disable id-blacklist */

import { Select, SelectCodeUrl } from '@corporate/model';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { AsSolde } from '../account-statement/account-statement-solde.model';
import { EnumActivationCode } from '../enum/enum-activation-code.enum';
import { SelectGMapAddress } from '../g-map.model.';
import { BankAgencyForDetail, BankAgency } from './bank-agency.model';
import { UserForGroup, UserForLabel } from './user/user.model';


export class Account {
    id: number=null;
    number: string=null;
    label: string=null;
    idBank: number=null;
    bankAgency: BankAgency=new BankAgency();
    startAmount: number=null;
    idAccountType: number=null;
    accountType: Select=null;
    alertThreshold: number=null;
}

export class AccountForLabel {
    id: number=null;
    number: string=null;
    label: string=null;
}

// export class AccountForDetail {
//     id: number;
//     number: string;
//     label: string;
//     bankAgency: ComboSimple<Select>;
//     bankSubFamily: ComboSimple<Select>;
//     bankFamily: ComboSimple<Select>;
//     startAmount: number;
//     accountType: ComboSimple<Select>;
//     alertThreshold: number;
//     linkedUsers: Select[];
// }

export interface AreaImport {
    historicView: boolean;
    fileView: boolean;
    errorView: boolean;
    loadingView: boolean;
}

export class AccountForTable {
    id: number;
    number: string;
    label: string;
    bankAgency: BankAgencyForDetail;
    startAmount: number;
    accountType: Select;
    alertThreshold: number;
    linkedUsers: Select[];
    solde: number;
    enumActivationCode: EnumActivationCode;
    activationCodeIcon: TypeButtonIcon;
    linkedUsersIcon: TypeButtonIcon;

}

export class AccountForDetail {
    id:                 number = null;
    idUserOwner:        number = null;
    user:               UserForGroup = null;
    number:             string = null;
    label:              string = null;
    bankAgency:         SelectGMapAddress = null;
    bankFamily:         SelectCodeUrl = null;
    bankSubFamily:      Select = null;
    startAmount:        number = null;
    accountType:        Select = null;
    alertThreshold:     number = null;
    linkedUsers:        Select[] = null;
}

export class AccountForList {
    solde: AsSolde;
}

export class AccountOwner {
    userCaller: UserForLabel=null;
    userOwner: UserForLabel=null;
    account: AccountForLabel=null;
    enumActivationCode: EnumActivationCode;
}
