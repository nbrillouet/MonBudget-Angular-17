import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const OT_COLUMNS: Column[]=
[
  { field: 'isUsed',label:'',isSortable:false,width:{isFixed:true,value:50},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type: EnumStyleType.dotBool,datas:null}},
  { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null }},
  { field: 'operationTypeFamily-label',label:'Catégorie opération',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'label',label:'libellé',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null},pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'buttonO',label:'',isSortable:false,width:{isFixed:true,value:100},filter: {type:EnumFilterType.none, datas: null},pipe:false,style:{type:EnumStyleType.buttonIcon,datas:null}},
  { field: 'buttonDetail',label:'',isSortable:false,width:{isFixed:true,value:100},filter: {type:EnumFilterType.none, datas: null},pipe:false,style:{type:EnumStyleType.buttonIcon,datas:null}}
];
