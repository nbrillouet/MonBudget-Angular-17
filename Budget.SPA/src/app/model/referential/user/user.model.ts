import { Injectable } from '@angular/core';
import { EnumUserStatus } from 'app/model/enum/enum-user-status.enum';
import { GMapAddress } from 'app/model/g-map.model.';
import { BankAgencyAccounts } from '../bank-agency.model';
import { UserEvent } from './user-event.model';
import { UserShortcut } from './user-shortcut.model';

export class UserTable {
    id: number;
    userName: string;
    lastName: string;
    firstName: string;
    gender: string;
    age: number;
    dateCreated: Date;
    dateLastActive: Date;
    avatarUrl: string;
}

export class UserForMinimal {
    id: number = null;
    role: EnumUserRole = null;
    idUserGroup: number = null;
}

export class UserForInfo extends UserForMinimal {
    userName: string = null;
    lastName:  string = null;
    firstName: string = null;
    email: string = null;
    gender: string = null;
    age: number = null;
}

export class UserForLogged extends UserForInfo {
    shortcuts: UserShortcut[] = null;
    bankAgencies: BankAgencyAccounts[] = null;
    userEvents: UserEvent[] = null;
    userPreference: UserPreference = new UserPreference();
}

export class UserForDetail extends UserForLogged {
    gMapAddress: GMapAddress = new GMapAddress();
    dateCreated: Date = null;
    dateLastActive: Date = null;
    dateOfBirth: Date = null;
    idGMapAddress: number = null;
    idAvatarCloud: string = null;
}

export class UserForLabel {
    id: number;
    lastName: string;
    firstName: string;
}

export class UserForGroup {
    id: number = null;
    idUserGroup: number = null;
}

export class UserForAuth extends UserForGroup {
    role: string;
    token: string;
}

export class UserForRegister {
    userName: string;
    email: string;
    password: string;
    passwordConfirm: string;
}

export class UserForPasswordChange {
    idCrypted: string;
    name: string;
    email: string;
    password: string;
}

export class UserPreference {
    id: number = null;
    theme: string = null;
    scheme: string = null;
    layout: string = null;
    language: string = null;
    avatarUrl: string = null;
    bannerUrl: string = null;
    status: EnumUserStatus = null;
}

export enum EnumUserRole {
    user = 1,
    admin = 2
}

@Injectable()
export class UserLoaded {
    isLoaded: boolean = false;
}


