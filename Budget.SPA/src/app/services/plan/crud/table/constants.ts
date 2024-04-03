import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const PLAN_COLUMNS: Column[]=
[
   { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null }},
   { field: 'label',label:'libellé',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null}, pipe: false,style:{type: EnumStyleType.label,datas:null}},
   { field: 'year',label:'année',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null}}
];
