import { Injectable } from '@angular/core';
import { EntityCollectionServiceBase, EntityCollectionServiceElementsFactory } from '@ngrx/data';
import { [Entity] } from '../models/[Entity].model';

@Injectable()
export class [Entity]EntityService extends EntityCollectionServiceBase<[Entity]> {

    [Entity]:[Entity];

    constructor(serviceElemetsFactory:EntityCollectionServiceElementsFactory){
        super('[Entity]',serviceElemetsFactory);
    }
}