namespace YMH219_KeyEventLogger.Models;

public class KeyLogEntry
{
    public DateTime Timestamp { get; }
    public string EventType { get; }
    public string KeyName { get; }
    public int KeyValue { get; }

    public KeyLogEntry(string eventType, Keys keyCode)
    {
        Timestamp = DateTime.Now;
        EventType = eventType;
        KeyName = keyCode.ToString();
        KeyValue = (int)keyCode;
    }

    public override string ToString()
    {
        return $"[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] {EventType,-8} | Tuş: {KeyName,-15} | Kod: {KeyValue}";
    }
}
