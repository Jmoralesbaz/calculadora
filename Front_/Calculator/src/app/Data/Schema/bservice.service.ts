import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CONFIG } from '../Constants/config';
import { Observable } from 'rxjs';

const httpOptionsDefault = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json; charset=utf-8',            
    Accept: 'application/json',

  })};

export class BServiceService {

  protected http=inject(HttpClient);
  protected endPoint: string = '';
  protected pathService: string = '';

  constructor() { 
    this.endPoint = CONFIG.ENDPOINT;
  }
  protected Post<TSalida, TDatos>(method: string, datos: TDatos): Observable<TSalida> {
    return this.http.post<TSalida>(this.endPoint + this.pathService + method, datos,httpOptionsDefault);
  }
}
