import { Injectable } from '@angular/core';
import { BServiceService } from '../Schema/bservice.service';
import { RoutsServices } from '../Constants/services';
import { OperationBasic } from '../Models/operation-basic';
import { Observable } from 'rxjs';
import { Result } from '../Models/result';
import { FactorialValue } from '../Models/factorial-value';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService extends BServiceService{

  constructor() { 
    super();
    this.pathService = `${RoutsServices.Calculator.Url}`;
  }

  public Sum(value:OperationBasic):Observable<Result>{
    return this.Post<Result,OperationBasic>(`${RoutsServices.Calculator.Actions.Sum}`,value);
  }
  public Rest(value:OperationBasic):Observable<Result>{
    return this.Post<Result,OperationBasic>(`${RoutsServices.Calculator.Actions.Rest}`,value);
  }
  public Div(value:OperationBasic):Observable<Result>{
    return this.Post<Result,OperationBasic>(`${RoutsServices.Calculator.Actions.Div}`,value);
  }
  public Mult(value:OperationBasic):Observable<Result>{
    return this.Post<Result,OperationBasic>(`${RoutsServices.Calculator.Actions.Mult}`,value);
  }
  public Fact(value:FactorialValue):Observable<Result>{
    return this.Post<Result,FactorialValue>(`${RoutsServices.Calculator.Actions.Fact}`,value);
  }
}
