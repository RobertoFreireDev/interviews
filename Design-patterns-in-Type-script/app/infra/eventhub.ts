export class EventHub {
    public static send(event : string) {
        console.log("Sending event...");
        console.log(event);
    }
}