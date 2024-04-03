import { Component, Input, OnInit } from '@angular/core';
import { of } from 'rxjs';

@Component({
    selector: 'progress-bar-custom',
    templateUrl: './progress-bar-custom.component.html',
    styleUrls: ['./progress-bar-custom.component.scss']
  })
  export class ProgressBarCustomComponent implements OnInit {
    @Input() inputValue: number;
    @Input() reverseColor: boolean;

    valueProgress: number = 0;

    condition: string = 'progress-green';

    constructor() { }

    ngOnInit(): void {
        // console.log('value', this.value);
        this.timeout();

        

    }

    timeout(): void {
        setTimeout (() => {
            // this.value = this.inputValue;
            this.valueProgress = this.inputValue===0 ? 0.0001 : this.inputValue;
            // console.log('value',this.value);
          }, 500);
    }

    getColor(): string {
        console.log('this.reverseColor',this.reverseColor);
        if(this.reverseColor) {
            if(this.inputValue>=0 && this.inputValue<=50)
                return 'progress-red';
            if(this.inputValue>50 && this.inputValue<=70)
                return 'progress-orange';
            if(this.inputValue>70 && this.inputValue<=100)
                return 'progress-green';
            if(this.inputValue>100)
                return 'progress-green-full';
        }
        if(this.inputValue>=0 && this.inputValue<=50)
            return 'progress-green-full';
        if(this.inputValue>50 && this.inputValue<=70)
            return 'progress-green';
        if(this.inputValue>70 && this.inputValue<=100)
            return 'progress-orange';
        if(this.inputValue>100)
            return 'progress-red';
    }

  }
