export interface IHandler {
    setNext(handler: IHandler): IHandler;

    handle(request: any): any;
}