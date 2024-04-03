import { NgModule } from '@angular/core';
import { NavigationService } from 'app/core/navigation/navigation.service';
import { NavigationLoaderService } from './navigation.loader.service';

@NgModule({
    imports  : [
        // UserLoggedStoreModule
    ],
    providers: [
        NavigationService,
        NavigationLoaderService
    ]
})
export class NavigationModule { }
