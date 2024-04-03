import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const PLAN_POSTE_COLUMNS: Column[]=
[
    { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null, isEmpty: true}, pipe: false,style:{type:EnumStyleType.label,datas:null }},
    { field: 'label',label:'libellé',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null, isEmpty: true}, pipe: false,style:{type:EnumStyleType.label,datas:null}}
];
