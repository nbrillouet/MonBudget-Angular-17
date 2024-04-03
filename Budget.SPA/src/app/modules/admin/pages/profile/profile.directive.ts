import { UserForDetail } from 'app/model/referential/user/user.model';
// import { CorpForm } from 'app/shared/corp-form/corp.form';
// import { CommonDetailDirective } from 'app/shared/directive/common-detail.directive';
import { UserForDetailFormBuilderOptions } from './user-for-detail.form-builder-option';
import { CorpForm } from '@corporate/projects/corporate/data/src/lib/corp-data-form/corp.form';
import { Select } from '@corporate/model';

export class ProfileDirective {

    profileForm: CorpForm<UserForDetail, UserForDetailFormBuilderOptions>;

    constructor(
        // public _store: Store,
        // public _helperService: HelperService,
        // public _enums: EnumsService
    ) {

    }

    getBannerUrlValue(): any {
        return this.profileForm.getValue(x=>x.userPreference.bannerUrl);
    }

    getAvatarUrlValue(): any {
        return this.profileForm.getValue(x=>x.userPreference.avatarUrl);
    }

    getUsernameValue(): any {
        return this.profileForm.getValue(x=>x.userName);
    }

    getFirstNameValue(): any {
        return this.profileForm.getValue(x=>x.firstName);
    }

    getLastNameValue(): any {
        return this.profileForm.getValue(x=>x.lastName);
    }

    getRoleValue(): any {
        return this.profileForm.getValue(x=>x.role);
    }

    getDateOfBirthValue(): any{
        return this.profileForm.getValue(x=>x.dateOfBirth);
    }

    getAgeValue(): any {
        return this.profileForm.getValue(x=>x.age);
    }

    getDateCreatedValue(): any {
        return this.profileForm.getValue(x=>x.dateCreated);
    }

    getDateLastActiveValue(): any {
        return this.profileForm.getValue(x=>x.dateLastActive);
    }

    getStatusValue(): any {
        return this.profileForm.getValue(x=>x.userPreference.status);
    }

    compareObjects(o1: Select, o2: Select): any {
        return o1 && o2 ? o1.id === o2.id : o1 === o2;
    }
}
