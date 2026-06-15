namespace LogLibrary.Structs
{
    public class LogRequestObject
    {
        public string LogId { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string TraceKey { get; private set; }        
        public object AdditionalData { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? ExceptionStackTrace { get; set; }

        public LogRequestObject(DateTime timeStamp, string traceKey)
        {
            LogId = Guid.NewGuid().ToString();
            TimeStamp = timeStamp;  
            TraceKey = traceKey;
        }
    }
}
