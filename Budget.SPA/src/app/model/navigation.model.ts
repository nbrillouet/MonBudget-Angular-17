
export enum EnumTheme {
    default = 'default',
    brand = 'brand',
    indigo = 'indigo',
    rose = 'rose',
    purple = 'purple',
    amber = 'amber'
}


export interface IChild {
    id: string;
    title: string;
    translate: string;
    type: string;
    icon: string;
    url: string;
    badge: IBadge;
}

export interface IBadge {
    title: string;
    translate: string;
    bg: string;
    fg: string;
}
