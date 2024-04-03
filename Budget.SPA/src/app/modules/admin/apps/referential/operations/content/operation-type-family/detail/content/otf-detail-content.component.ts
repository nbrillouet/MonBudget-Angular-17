import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';
import { OtfDetailService } from 'app/services/referential/operations/operation-type-family/detail/otf-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'otf-detail-content',
    templateUrl    : './otf-detail-content.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class OtfDetailContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OtfForDetail;

    constructor(
        public _otfDetailService: OtfDetailService
     )
    {
        super();
        this.property = this._otfDetailService.form.model as OtfForDetail;

    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

}
