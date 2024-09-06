import { OperationBasic } from "./operation-basic";

export class Calculator implements OperationBasic {
    public ValueA: number=0;
    public ValueB: number=0;

    public Reset():void{
        this.ValueA=0;
        this.ValueB=0;
    }
}
