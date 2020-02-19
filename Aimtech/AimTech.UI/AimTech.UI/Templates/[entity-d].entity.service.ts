import { Injectable } from '@angular/core';
import { EntityCollectionServiceBase, EntityCollectionServiceElementsFactory } from '@ngrx/data';
import { [Entity] } from '../models/[Entity-d].model';

@Injectable()
export class [Entity]EntityService extends EntityCollectionServiceBase<[Entity]> {

    [Entity-cc]:[Entity];

    constructor(serviceElemetsFactory:EntityCollectionServiceElementsFactory){
        super('[Entity]',serviceElemetsFactory);
    }
}