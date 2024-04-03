import { Injectable } from '@angular/core';
import { OtfTableService } from './operation-type-family/table/otf-table.service';
import { OtTableService } from './operation-type/table/ot-table.service';

@Injectable({ providedIn: 'root' })
export class OperationsService
{

    /**
     * Constructor
     */
    constructor(
        public _otfTableService: OtfTableService,
        public _otTableService: OtTableService

    )
    {

    }

}
