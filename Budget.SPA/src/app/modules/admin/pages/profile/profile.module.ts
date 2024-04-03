import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { TranslocoModule } from '@ngneat/transloco';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { ProfileAboutMeComponent } from './profile-information/profile-about-me/profile-about-me.component';
import { ProfileInformationComponent } from './profile-information/profile-information.component';
import { ProfileLocalisationComponent } from './profile-information/profile-localisation/profile-localisation.component';
import { ProfilePreferenceComponent } from './profile-information/profile-preference/profile-preference.component';
import { ProfileAboutMeReadComponent } from './profile-information/profile-about-me/profile-about-me-read/profile-about-me-read.component';
import { ProfileAboutMeEditComponent } from './profile-information/profile-about-me/profile-about-me-edit/profile-about-me-edit.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ProfileComponent } from './profile.component';
import { profileRoutes } from './profile.routing';
import { ProfileCommonModule } from 'app/services/referential/user/profile/profile.module';
import { SharedModule } from 'app/shared/shared.module';
import { FuseCardComponent } from '@fuse/components/card';
import { GMapModule } from 'app/shared/web-component/g-map/g-map-search/g-map.module';

@NgModule({
    declarations: [
        ProfileComponent,
        ProfileInformationComponent,
        ProfileAboutMeComponent,
        ProfileAboutMeReadComponent,
        ProfileAboutMeEditComponent,
        ProfileLocalisationComponent,
        ProfilePreferenceComponent

    ],
    imports     : [
        RouterModule.forChild(profileRoutes),
        // AgmCoreModule.forRoot({
        //     apiKey: GMAP_KEY
        //   }),
        MatButtonModule,
        MatDividerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatTooltipModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatDatepickerModule,
        // FuseCardModule,
        SharedModule,
        GMapModule,

        ProfileCommonModule,
        TranslocoModule,
        NgxsFormPluginModule,
        FuseCardComponent
    ]
})
export class ProfileModule
{
}
