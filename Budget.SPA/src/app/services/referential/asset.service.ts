import { Injectable } from '@angular/core';
import { FuseConfigService } from '@fuse/services/config';


@Injectable()
export class AssetService {
config: any = null;

    constructor(
        private _fuseConfigService: FuseConfigService
    ) {
        this._fuseConfigService.config$.subscribe((config) => {
            this.config = config;
        });
     }

    get(assetUrl: string): string {
        if(!this.config) {
            return null;
        }
        // let assetUrl: string = this._helperService.getDeepClone(this._asifDetailService.form.getValue(x=>x.operationTypeFamily)?.code);

        // if(!assetUrl){
        //     return null;
        // }
        assetUrl = assetUrl.replace('[theme]', this.config.theme);

        return assetUrl;
    }


}



