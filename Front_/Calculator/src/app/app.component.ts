import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Calculator } from './Data/Models/calculator';
import { CalculatorService } from './Data/Services/calculator.service';
import { lastValueFrom } from 'rxjs';
import { Result } from './Data/Models/result';
import { ErrorServices } from './Data/Models/error-services';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  dataSend:Calculator = new Calculator();
  accion:string='';
  displayvalue:string='';
  error:string='';
  title = 'Calculator';

  constructor(private srvCalc:CalculatorService){

  }
  clickDigit(data:number):void{
    if(this.accion === ''){
      this.displayvalue += data;
      this.dataSend.ValueA = parseFloat(this.displayvalue);
    }else{
      this.displayvalue += data;
      this.dataSend.ValueB = parseFloat(this.displayvalue);
    }
  }
  clear():void{
    this.displayvalue ='';
    this.dataSend.Reset();
    this.accion ='';
  }
  operador(accionClick:string):void{
    
    if(this.accion !=='' || accionClick === 'F'){
      this.sendService();
      if(accionClick !== 'F')
      {
        this.accion = accionClick;
      }
    }else{
      this.displayvalue='';
      this.accion = accionClick;
    }
  }
  async sendService(){
    this.error ='';
    switch(this.accion){
      case '+':
        var r = await lastValueFrom<Result>(this.srvCalc.Sum(this.dataSend)).catch((e:any)=>{
        this.error =e.message;
       });
       
       if(r){
        this.dataSend.ValueA = r.result;
       }
        break;
      case '-':
        var r = await lastValueFrom<Result>(this.srvCalc.Rest(this.dataSend)).catch((e:any)=>{
          this.error =e.error.message;
         });
         if(r){
          this.dataSend.ValueA = r.result;
         }
        break;
      case '/':
        var r = await lastValueFrom<Result>(this.srvCalc.Div(this.dataSend)).catch((e:any)=>{          
          this.error =e.error.message;
         });         
         if(r){
          this.dataSend.ValueA = r.result;
         }
        break;
      case '*':
        var r = await lastValueFrom<Result>(this.srvCalc.Mult(this.dataSend)).catch((e:any)=>{
          this.error =e.error.message;
         });
         if(r){
          this.dataSend.ValueA = r.result;
         }
        break;
      default:
        var r = await lastValueFrom<Result>(this.srvCalc.Fact({Value:this.dataSend.ValueA})).catch((e:any)=>{
          this.error =e.error.message;
         });
         if(r){
          this.dataSend.ValueA = r.result;
         }
        break;
    }
    this.accion ='';
    this.displayvalue=this.dataSend.ValueA.toString();    
    this.dataSend.ValueB = 0;

  
  }
}
