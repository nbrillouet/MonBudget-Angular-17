/* eslint-disable @typescript-eslint/naming-convention */
import { Injectable } from '@angular/core';
import { EnumAsTab } from 'app/model/enum/enum-as-tab.enum';
import { EnumUserEventCategory } from 'app/model/enum/user-event/enum-user-event-category.enum';
import { EnumUserEventSection } from 'app/model/enum/user-event/enum-user-event-section.enum';
import { EnumUserEventWarning } from 'app/model/enum/user-event/enum-user-event-warning.enum';

@Injectable()
export class EnumService {
    EnumUserEventWarning = EnumUserEventWarning;
    EnumUserEventCategory = EnumUserEventCategory;
    EnumUserEventSection = EnumUserEventSection;
    EnumAsTab = EnumAsTab;

    constructor() { }

}
