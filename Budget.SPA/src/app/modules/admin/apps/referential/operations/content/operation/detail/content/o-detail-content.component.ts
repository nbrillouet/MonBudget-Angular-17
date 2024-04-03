import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { OForDetail } from 'app/model/referential/operation.model';
import { ODetailService } from 'app/services/referential/operations/operation/detail/o-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'o-detail-content',
    templateUrl    : './o-detail-content.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class ODetailContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OForDetail;

    constructor(
        public _oDetailService: ODetailService
     )
    {
        super();
        this.property = this._oDetailService.form.model as OForDetail;

    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

}
