import { Injectable } from '@angular/core';
import { DefaultDataService, HttpUrlGenerator } from '@ngrx/data';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'environments/environment';
import { Router } from '@angular/router';
import { [Entity] } from '../models/[entity-d].model';

@Injectable()
export class [Entity]DataService extends DefaultDataService<[Entity]>{

    constructor(http:HttpClient,httpUrlGenerator:HttpUrlGenerator,
       private router:Router){
        super('[Entity]',http,httpUrlGenerator);
    }

    getWithQuery(params):Observable<[Entity][]>{
        var url = `${environment.[entity-cc]}`;
        
         return this.http.get<[Entity][]>(`${url}/${params.Id}`).pipe(      
        map(res=> res['responseData']));
    }


    getAll():Observable<[Entity][]>{
        var url = `${environment.[entity-cc]}`;
    
        return this.http.get<[Entity][]>(`${url}`).pipe(
            map(res=>  res['responseData'] )
            //,catchError(err => { return this.errorHandler(err) })
            );
    }

    add([Entity]:any):Observable<[Entity]>{
      
     return this.http.post(environment.[entity-cc],[Entity]).pipe(
         map(res => res['responseData']
         )
     );   
    }

    update([Entity]:any):Observable<[Entity]>{
        return this.http.put(environment.[entity-cc],[Entity].changes).pipe(
            map(res => res['responseData'])
        );
    }

    delete(id:any){
        return this.http.delete(environment.[entity] + "/" + id).pipe(
            map(res => res['responseData'])
        );
    }

    errorHandler(error:HttpErrorResponse){
       
        this.router.navigate(['/error'])
        return ""
    }
}