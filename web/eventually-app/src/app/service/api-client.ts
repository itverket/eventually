
import { environment } from '../../environments/environment'
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()
export class ApiClient<T> {

private baseUrl = environment.baseUrl;

constructor(private httpClient: HttpClient){}

public get(url:string, id: string = null) : Observable<T>{
    return this.httpClient.get<T>('https://reqres.in/api/users/');
    // return this.httpClient.get<T>(this.appendUrlWithBase(url,id);
}

public put(url: string, id: string, data : T){
   return this.httpClient.put<T>(this.appendUrlWithBase(url, id), data);
}

public post(url: string, data : T){
    return this.httpClient.post(this.appendUrlWithBase(url),data);
}

public delete(url: string, id: string){
    return this.httpClient.delete(this.appendUrlWithBase(url));
}

private appendUrlWithBase(url: string, id = ''): string{
    return `${this.baseUrl}/${url}/${id}`;
}

}
