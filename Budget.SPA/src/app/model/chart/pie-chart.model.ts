export class PieChart {
    // currentRange : string;
    legend: boolean;
    explodeSlices: boolean;
    labels: boolean;
    doughnut: boolean;
    gradient: boolean;
    scheme: Scheme;

    constructor( colors: string[]) {
        this.legend         = false;
        this.explodeSlices  = true;
        this.labels         = true;
        this.doughnut       = false;
        this.gradient       = true;

        // this.currentRange   = currentRange;
        this.scheme         = new Scheme(colors);

    }
    // onSelect(ev) => {

    //   }
}

class Scheme {
    domain: string[];

    constructor(domain: string[]) {
        this.domain=domain;
    }
}
