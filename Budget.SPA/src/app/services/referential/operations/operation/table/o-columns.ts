import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const O_COLUMNS: Column[]=
[
  { field: 'isUsed',label:'',isSortable:false,width:{isFixed:true,value:50},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type: EnumStyleType.dotBool,datas:null}},
  { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null }},
  { field: 'operationMethod-label',label:'méthode opération',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'operationType-label',label:'type opération',isSortable:false,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'label',label:'libellé',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null},pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'buttonDetail',label:'',isSortable:false,width:{isFixed:true,value:100},filter: {type:EnumFilterType.none, datas: null},pipe:false,style:{type:EnumStyleType.buttonIcon,datas:null}}
];
