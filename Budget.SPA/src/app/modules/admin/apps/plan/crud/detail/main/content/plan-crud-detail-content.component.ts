import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { fuseAnimations } from '@fuse/animations';
import { PlanForDetail } from 'app/model/plan/plan.model';
import { EnumPoste } from 'app/model/plan/poste/poste.enum';
import { PlanCrudDetailService } from 'app/services/plan/crud/detail/plan-crud-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'plan-crud-detail-content',
    templateUrl    : './plan-crud-detail-content.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class PlanCrudDetailContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: PlanForDetail;
    enumPoste: typeof EnumPoste = EnumPoste;
    selectedIndex: number = 0;

    constructor(
        // private _activatedRoute: ActivatedRoute,
        // private _location: Location,
        // private _store: Store,
        // private _helperService: HelperService,
        // public _userLoggedService: UserLoggedService,
        public _planCrudDetailService: PlanCrudDetailService,
        // public _fuseConfigService: FuseConfigService
     )
    {
        super();
        this.property = this._planCrudDetailService.form.model as PlanForDetail;
    }

    ngOnDestroy(): void {
        this._planCrudDetailService.destroyForm();
    }

    ngOnInit(): void {
        // this._fuseConfigService.config$.subscribe((config: AppConfig) => {
        //     this.config = config;
        // });
    }

    onTabClick($event): void{
        this.selectedIndex=$event.index;
    }
    // save(): void {
    //     // this._asifDetailService.saveAsifDetail();

    // }

    // movePrevious(): void {
    //     // this._location.back();
    // }
    // onChangeColor(color: string): void {
    //     // const t = this.getValue(this.property.plan.color);
    //     // console.log('color', t);
    //     // console.log('event', color);
    //     this._planCrudDetailService.form.setValue(x=>x.plan.color,color);
    // }

    // getValue(property: any): any {
    //     return this._planCrudDetailService.form.getValue(property);
    // }

    // getControl(property: string): AbstractControl {
    //     return this._planCrudDetailService.form.getControl(property);
    // }

    // getProperty(property: any): string {
    //     return this._planCrudDetailService.form.getProperty(property);
    // }
}
