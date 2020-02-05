import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap, first,filter } from 'rxjs/operators';
import { [Entity]EntityService } from './[Entity:d].entity.service';

@Injectable()
export class [Entity]Resolver implements Resolve<boolean>{

    constructor(private service:[Entity]EntityService){

    }

    resolve(route:ActivatedRouteSnapshot,state: RouterStateSnapshot):Observable<boolean>{
      return this.service.loaded$.pipe(
        tap(loaded=>{
            if(!loaded)
                this.service.getAll();
        }),
        filter(loaded => !!loaded),
        first()
        );
    }
}