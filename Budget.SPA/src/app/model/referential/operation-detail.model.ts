import { Select, SelectCode } from '@corporate/model';
import { GMapAddress } from '../g-map.model.';

export class OperationDetail {
    id: number = null;
    operation: Select = null;
    keywordOperation: string = null;
    keywordPlace: string = null;
    operationLabel: string = null;
    placeLabel: string = null;
    operationPlace: SelectCode = null;
    gMapAddress: GMapAddress = null;
}
