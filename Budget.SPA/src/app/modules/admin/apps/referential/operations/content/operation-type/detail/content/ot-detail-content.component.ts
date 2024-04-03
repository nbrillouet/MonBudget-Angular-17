import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { OtDetailService } from 'app/services/referential/operations/operation-type/detail/ot-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'ot-detail-content',
    templateUrl    : './ot-detail-content.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class OtDetailContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OtForDetail;

    constructor(
        public _otDetailService: OtDetailService
     )
    {
        super();
        this.property = this._otDetailService.form.model as OtForDetail;

    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

}
