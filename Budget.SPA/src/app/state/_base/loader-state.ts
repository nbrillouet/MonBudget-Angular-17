import { Loader, LoadingInfo } from '@corporate/model';
import { StateContext } from '@ngxs/store';

export class LoaderState {

    constructor() { }

    loading<T extends Loader>(context: StateContext<T>, key: string): void {
        const loadingInfo = this.loadSwitch(true);

        this.changeLoader(context, key, loadingInfo);
    }

    loaded<T extends Loader>(context: StateContext<T>, key: string): void {
        const loadingInfo = this.loadSwitch(false);
        this.changeLoader(context, key, loadingInfo);
    }

    private loadSwitch(isLoading: boolean): LoadingInfo {
        return { loaded: !isLoading, loading: isLoading } as LoadingInfo;
    }

    private changeLoader<T extends Loader>(context: StateContext<T>, key: string, loadingInfo: LoadingInfo): void {

        context.patchState({
            loader: {
                ...context.getState().loader,
                [key]: loadingInfo
            }
        } as T);
        // (<T>state).loader[key] = loadingInfo;

        // context.patchState(state);
    }

}
