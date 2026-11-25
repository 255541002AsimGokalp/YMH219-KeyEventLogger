using YMH219_KeyEventLogger.Forms;

namespace YMH219_KeyEventLogger;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
