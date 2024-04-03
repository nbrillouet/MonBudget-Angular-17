import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const AS_MODEL_2_COLUMNS: Column[]=
[
  { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:80}, filter: {type:EnumFilterType.label, datas: null }, pipe: false,style:{type:EnumStyleType.label,datas:null }},
  { field: 'isDuplicated',label:'doublon',isSortable:true, width:{isFixed:true,value:80}, filter: {type:EnumFilterType.none }, pipe: false,style:{type:EnumStyleType.dotBool, datas:null }},
  { field: 'operationMethod-label',label:'Méthode opérations',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.comboMultiple, datas: null }, pipe: false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'operationTypeFamily-label',label:'Catégorie operations',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.comboMultipleGroup, datas: null },pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'operationType-label',label:'Type operations',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.comboMultipleGroup, datas: null},pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'operation-label',label:'Operations',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.comboMultiple, datas: null },pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'dateIntegration',label:'Date int.',isSortable:true,width:{isFixed:false,value:-1}, filter: {type:EnumFilterType.dateRange, datas: null },pipe:true,style:{type:EnumStyleType.label,datas:null}},
  { field: 'amountOperation',label:'montant',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.numberRange, datas: null },pipe:false,style: {type:EnumStyleType.numberUpDown,datas:{isoNumber:0}}}
];
