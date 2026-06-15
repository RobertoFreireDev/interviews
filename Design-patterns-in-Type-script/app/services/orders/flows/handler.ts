import { IHandler } from "./ihandler";

export abstract class Handler implements IHandler
{
    private nextHandler: IHandler;

    public setNext(handler: IHandler): IHandler {
        this.nextHandler = handler;
        return handler;
    }

    public handle(request: any): any {
        if (this.nextHandler) {
            return this.nextHandler.handle(request);
        }

        return request;
    }
}