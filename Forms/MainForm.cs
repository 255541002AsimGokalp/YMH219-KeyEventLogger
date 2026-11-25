using YMH219_KeyEventLogger.Services;

namespace YMH219_KeyEventLogger.Forms;

public partial class MainForm : Form
{
    private readonly KeyLogManager _manager = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void BtnStart_Click(object? sender, EventArgs e)
    {
        _manager.Start();
        UpdateStatusUi();
        txtTestArea.Focus();
    }

    private void BtnStop_Click(object? sender, EventArgs e)
    {
        _manager.Stop();
        UpdateStatusUi();
    }

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        _manager.Clear();
        lstLogs.Items.Clear();
        UpdateStatsUi();
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (_manager.TotalCount == 0)
        {
            MessageBox.Show("Kaydedilecek herhangi bir tuş olayı bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "Metin Dosyası (*.txt)|*.txt",
            FileName = $"key_events_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
            Title = "Tuş Kayıtlarını Dışa Aktar"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _manager.SaveToFile(dialog.FileName);
                MessageBox.Show("Kayıtlar başarıyla dışa aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        LogKeyEvent("KeyDown", e.KeyCode);
    }

    private void MainForm_KeyUp(object? sender, KeyEventArgs e)
    {
        LogKeyEvent("KeyUp", e.KeyCode);
    }

    private void LogKeyEvent(string eventType, Keys keyCode)
    {
        var entry = _manager.Record(eventType, keyCode);
        if (entry == null) return;

        lstLogs.Items.Add(entry.ToString());
        lstLogs.TopIndex = lstLogs.Items.Count - 1;
        UpdateStatsUi();
    }

    private void UpdateStatusUi()
    {
        if (_manager.IsLogging)
        {
            lblStatus.Text = "● DURUM: KAYIT AKTİF";
            lblStatus.ForeColor = Color.LimeGreen;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }
        else
        {
            lblStatus.Text = "● DURUM: KAYIT DURDURULDU";
            lblStatus.ForeColor = Color.OrangeRed;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }

    private void UpdateStatsUi()
    {
        lblStats.Text = $"Toplam Olay: {_manager.TotalCount} | En Sık Basılan Tuş: {_manager.GetMostFrequentKey()}";
    }
}
