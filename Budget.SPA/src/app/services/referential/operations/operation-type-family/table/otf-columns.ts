/* eslint-disable max-len */
import { Column, EnumFilterType, EnumStyleType } from '@corporate/mat-table-filter';

export const OTF_COLUMNS: Column[]=
[
  { field: 'isUsed',label:'',isSortable:false,width:{isFixed:true,value:50},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type: EnumStyleType.dotBool,datas:null}},
  { field: 'id',label:'id',isSortable:true,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.label,datas:null }},
  { field: 'asset-code',label:'',isSortable:false,width:{isFixed:true,value:70},filter: {type:EnumFilterType.none, datas: null}, pipe: false,style:{type:EnumStyleType.image,datas:null}},
  { field: 'label',label:'libellé',isSortable:true,width:{isFixed:false,value:-1},filter: {type:EnumFilterType.label, datas: null},pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'movement-label',label:'sens',isSortable:true,width:{isFixed:true,value:100},filter: {type:EnumFilterType.comboMultiple, datas: null},pipe:false,style:{type:EnumStyleType.label,datas:null}},
  { field: 'buttonOt',label:'',isSortable:false,width:{isFixed:true,value:100},filter: {type:EnumFilterType.none, datas: null},pipe:false,style:{type:EnumStyleType.buttonIcon,datas:null}},
  { field: 'buttonDetail',label:'',isSortable:false,width:{isFixed:true,value:100},filter: {type:EnumFilterType.none, datas: null},pipe:false,style:{type:EnumStyleType.buttonIcon,datas:null}}
];
