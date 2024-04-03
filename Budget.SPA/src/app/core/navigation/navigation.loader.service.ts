import { Injectable } from '@angular/core';
import { FuseNavigationItem } from '@fuse/components/navigation';
import { Navigation } from 'app/core/navigation/navigation.types';
import { EnumUserRole, UserForLogged } from 'app/model/referential/user/user.model';
import { environment } from 'environments/environment';
import { cloneDeep } from 'lodash';

@Injectable()
export class NavigationLoaderService {
baseUrl = environment.apiUrl;

_defaultNavigation: FuseNavigationItem[] = [];

// defaultNavigation: FuseNavigationItem[] = [
//     {
//         id   : 'example',
//         title: 'Example',
//         type : 'basic',
//         icon : 'heroicons_outline:chart-pie',
//         link : '/example'
//     }
// ];

//MENU REFERENTIEL
referential: FuseNavigationItem = {
    id  : 'referential',
    title: 'Référentiel',
    subtitle:'Référentiel de votre budget',
    type : 'collapsable',
    icon : 'heroicons_outline:cog',
    children: [] = []
};
referentialChildUser: FuseNavigationItem = {
    id   : 'referential.users',
    title: 'Utilisateurs',
    type : 'basic',
    icon : 'heroicons_outline:clipboard-check',
    link  : '/apps/referential/users'
};
referentialChildAccount: FuseNavigationItem = {
    id   : 'referential.accounts',
    title: 'Comptes bancaires',
    type : 'basic',
    icon : 'heroicons_outline:clipboard-check',
    link  : '/apps/referential/accounts'
};
referentialChildOperation: FuseNavigationItem = {
    id   : 'referential.operations',
    title: 'Opérations',
    type : 'basic',
    icon : 'heroicons_outline:clipboard-check',
    link  : '/apps/referential/operations'
};
//MENU IMPORT RELEVE
importAccount: FuseNavigationItem = {
    id   : 'import',
    title: 'Import relevés',
    subtitle:'Import de vos relevés bancaires',
    type : 'basic',
    icon : 'insert_drive_file',
    link  : '/apps/account-statement-import'
};
//MENU BANQUE
bank: FuseNavigationItem = {
    id   : 'bank',
    title: 'Banques',
    subtitle:'vos comptes bancaires',
    type : 'collapsable',
    icon : 'account_balance',
    link  : '/apps/account-statement-import',
    children: [] = []
};
bankChildPrimary: FuseNavigationItem = {
    id   : 'bank_0',
    title: 'Tous les comptes',
    type : 'basic',
    link  : '/apps/account-statement/accounts/ALL'
};
//MENU PLAN
plan: FuseNavigationItem = {
    id  : 'plan',
    title: 'Budget',
    subtitle:'vos budgets',
    type : 'collapsable',
    icon : 'donut_small',
    children: []
};
planChildAddEdit: FuseNavigationItem = {
    id   : 'plan.addEdit',
    title: 'Création/modification',
    type : 'basic',
    link  : '/apps/plans'
};
planChildSuivi: FuseNavigationItem = {
    id   : 'plan.suivi',
    title: 'Suivi',
    type : 'basic',
    link  : '/apps/plans/follow-up'
};

constructor(
    // private _httpClient: HttpClient
    // private _authService: AuthService
) { }

    getNavigation(user: UserForLogged): Navigation {

        this.initNavigation();

        // this._defaultNavigation = [];
        // this.referential.children = [];
        // this.bank.children = [];
        // this.plan.children = [];

        this._defaultNavigation.push(this.getReferentialMenu(user));
        this._defaultNavigation.push(this.getImportAccountMenu());
        this._defaultNavigation.push(this.getBankMenu(user));
        this._defaultNavigation.push(this.getPlanMenu());

        return {
            compact   : cloneDeep(this._defaultNavigation),
            default   : cloneDeep(this._defaultNavigation),
            futuristic: cloneDeep(this._defaultNavigation),
            horizontal: cloneDeep(this._defaultNavigation)
        };
    }

    getReferentialMenu(user: UserForLogged): FuseNavigationItem {
        if(user.role===EnumUserRole.admin) {
            this.referential.children.push(this.referentialChildUser);
        }
        this.referential.children.push(this.referentialChildAccount);
        this.referential.children.push(this.referentialChildOperation);

        return this.referential;
    }

    getImportAccountMenu(): FuseNavigationItem {
        return this.importAccount;
    }

    getBankMenu(user: UserForLogged): FuseNavigationItem {
        this.bank.children.push(this.bankChildPrimary);

        for(const bank of user.bankAgencies)
        {
            const bankChild: FuseNavigationItem = {
                id   : `bank_${bank.id}`,
                title: bank.bankFamily.label,
                type : 'collapsable',
                children: []
            };

            for(const account of bank.accounts)
            {
                const accountChild: FuseNavigationItem = {
                    id   : `bank_${account.number}`,
                    title: account.label + ' (...' + account.number.substring(account.number.length-3) + ')',
                    type : 'basic',
                    link  : `/apps/account-statement/accounts/${account.id}`
                };

                bankChild.children.push(accountChild);
            }

            this.bank.children.push(bankChild);
        }

        return this.bank;
     }

     getPlanMenu(): FuseNavigationItem {
        this.plan.children.push(this.planChildAddEdit);
        this.plan.children.push(this.planChildSuivi);

        return this.plan;
     }

     initNavigation(){
        this._defaultNavigation = [];
        this.referential.children = [];
        this.bank.children = [];
        this.plan.children = [];
     }



}
