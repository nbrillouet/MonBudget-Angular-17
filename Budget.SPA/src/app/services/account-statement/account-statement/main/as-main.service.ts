import { Injectable } from '@angular/core';
import { AsMainFilterSelectedService } from './as-main-filter-selected.service';
import { AsMainFilterSelectionService } from './as-main-filter-selection.service';

@Injectable({ providedIn: 'root' })
export class AsMainService
{
    /**
     * Constructor
     */
    constructor(
        public _selectedService: AsMainFilterSelectedService,
        public _selectionService: AsMainFilterSelectionService
    )
    {

    }
}
