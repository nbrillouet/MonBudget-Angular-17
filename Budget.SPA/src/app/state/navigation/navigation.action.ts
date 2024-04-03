export const NAVIGATION_LOAD = 'navigation-load';
export const NAVIGATION_CLEAR = 'navigation-clear';

export const NAVIGATION_ADD = 'navigation-add';

export class LoadNavigation {
    static readonly type = NAVIGATION_LOAD;

    constructor(public payload: any) { }
}

export class ClearNavigation {
    static readonly type = NAVIGATION_CLEAR;
}


export class AddNavigation {
    static readonly type = NAVIGATION_ADD;

    constructor(public payload: any) { }
}
