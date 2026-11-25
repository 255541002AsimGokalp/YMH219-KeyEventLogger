using YMH219_KeyEventLogger.Models;

namespace YMH219_KeyEventLogger.Services;

public class KeyLogManager
{
    private readonly List<KeyLogEntry> _entries = new();
    private readonly Dictionary<string, int> _frequency = new();

    public bool IsLogging { get; private set; }
    public IReadOnlyList<KeyLogEntry> Entries => _entries.AsReadOnly();
    public int TotalCount => _entries.Count;

    public void Start() => IsLogging = true;
    public void Stop() => IsLogging = false;

    public KeyLogEntry? Record(string eventType, Keys keyCode)
    {
        if (!IsLogging)
            return null;

        var entry = new KeyLogEntry(eventType, keyCode);
        _entries.Add(entry);

        if (eventType == "KeyDown")
        {
            _frequency[entry.KeyName] = _frequency.GetValueOrDefault(entry.KeyName) + 1;
        }

        return entry;
    }

    public void Clear()
    {
        _entries.Clear();
        _frequency.Clear();
    }

    public string GetMostFrequentKey()
    {
        if (_frequency.Count == 0)
            return "-";

        var top = _frequency.OrderByDescending(kv => kv.Value).First();
        return $"{top.Key} ({top.Value} kez)";
    }

    public void SaveToFile(string filePath)
    {
        using var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
        writer.WriteLine("=== YMH 219 Eğitsel Key Event Logger Kayıtları ===");
        writer.WriteLine($"Dışa Aktarma Tarihi: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        writer.WriteLine($"Toplam Olay Sayısı : {TotalCount}");
        writer.WriteLine(new string('-', 60));
        foreach (var entry in _entries)
        {
            writer.WriteLine(entry.ToString());
        }
    }
}
