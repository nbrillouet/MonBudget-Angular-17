import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { AddNavigation, ClearNavigation, LoadNavigation } from './navigation.action';


export class NavigationStateModel {
    navigation: any;
}

let navigation : any[] = null;
@State<NavigationStateModel>({
    name: 'navigation',
    defaults : {
        navigation : null
    }
})

@Injectable()
export class NavigationState {
    constructor() {

    }

    @Selector()
    static getNavigation(state: NavigationStateModel): any { return state.navigation; }

    @Action(LoadNavigation)
    loadNavigation(context: StateContext<NavigationStateModel>, action: LoadNavigation): void {
        const state = context.getState();

        context.patchState({ navigation : action.payload });
        // this.userService.getUser(action.payload.id)
        //     .subscribe(result=> {
        // context.dispatch(new LoadNavigationSuccess(action));
            // })
    }

    // @Action(LoadNavigationSuccess)
    // loadNavigationSuccess(context: StateContext<NavigationStateModel>, action: LoadNavigationSuccess) {
    //     let toto= context.getState();

    //     context.patchState({ navigation : action.payload }

    //     );

    // }


    @Action(AddNavigation)
    addNavigation(context: StateContext<NavigationStateModel>, action: AddNavigation): void {

        context.patchState({ navigation : action.payload });
    }

    @Action(ClearNavigation)
    clearNavigation(context: StateContext<NavigationStateModel>): void {
        context.setState(new NavigationStateModel());
    }


}
