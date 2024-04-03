export interface IWidgetCardFlip {
    ranges: IDataTime[];
    currentRange: IDataTime;
    data: IData;
    detail: string;
}

export interface IDataTime {
    id: string;
    value: string;
}

export interface IData {
    label: string;
    count: IDataTime[];
    extra: IExtra;
}

export interface IExtra {
    label: string;
    count: IDataTime[];
}
