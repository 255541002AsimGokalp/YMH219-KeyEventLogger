namespace YMH219_KeyEventLogger.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private Panel pnlHeader = null!;
    private Label lblStatus = null!;
    private Button btnStart = null!;
    private Button btnStop = null!;
    private Button btnClear = null!;
    private Button btnSave = null!;
    private TextBox txtTestArea = null!;
    private ListBox lstLogs = null!;
    private Label lblStats = null!;
    private Label lblInfo = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblStatus = new Label();
        btnStart = new Button();
        btnStop = new Button();
        btnClear = new Button();
        btnSave = new Button();
        txtTestArea = new TextBox();
        lstLogs = new ListBox();
        lblStats = new Label();
        lblInfo = new Label();

        SuspendLayout();

        // pnlHeader
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 64;
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);

        lblStatus.Text = "● DURUM: KAYIT DURDURULDU";
        lblStatus.ForeColor = Color.OrangeRed;
        lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(16, 20);

        btnStart.Text = "Başlat";
        btnStart.Size = new Size(90, 34);
        btnStart.Location = new Point(310, 15);
        btnStart.BackColor = Color.FromArgb(16, 185, 129);
        btnStart.ForeColor = Color.White;
        btnStart.FlatStyle = FlatStyle.Flat;
        btnStart.Click += BtnStart_Click;

        btnStop.Text = "Durdur";
        btnStop.Size = new Size(90, 34);
        btnStop.Location = new Point(408, 15);
        btnStop.BackColor = Color.FromArgb(239, 68, 68);
        btnStop.ForeColor = Color.White;
        btnStop.FlatStyle = FlatStyle.Flat;
        btnStop.Enabled = false;
        btnStop.Click += BtnStop_Click;

        btnClear.Text = "Temizle";
        btnClear.Size = new Size(90, 34);
        btnClear.Location = new Point(506, 15);
        btnClear.BackColor = Color.FromArgb(100, 116, 139);
        btnClear.ForeColor = Color.White;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.Click += BtnClear_Click;

        btnSave.Text = ".txt Kaydet";
        btnSave.Size = new Size(105, 34);
        btnSave.Location = new Point(604, 15);
        btnSave.BackColor = Color.FromArgb(59, 130, 246);
        btnSave.ForeColor = Color.White;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Click += BtnSave_Click;

        pnlHeader.Controls.AddRange(new Control[] { lblStatus, btnStart, btnStop, btnClear, btnSave });

        // lblInfo
        lblInfo.Text = "Not: Bu uygulama eğitsel amaçlıdır. Yalnızca kendi penceresi aktifken (odaktayken) tuş olaylarını yakalar.";
        lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblInfo.ForeColor = Color.DimGray;
        lblInfo.Location = new Point(16, 74);
        lblInfo.AutoSize = true;

        // txtTestArea
        txtTestArea.PlaceholderText = "Kayıt açıkken buraya yazarak klavye olaylarını test edebilirsiniz...";
        txtTestArea.Location = new Point(16, 100);
        txtTestArea.Size = new Size(693, 28);
        txtTestArea.Font = new Font("Segoe UI", 10.5F);

        // lstLogs
        lstLogs.Location = new Point(16, 138);
        lstLogs.Size = new Size(693, 310);
        lstLogs.Font = new Font("Consolas", 9.5F);
        lstLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        // lblStats
        lblStats.Text = "Toplam Olay: 0 | En Sık Basılan Tuş: -";
        lblStats.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblStats.Location = new Point(16, 458);
        lblStats.AutoSize = true;
        lblStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        // MainForm
        ClientSize = new Size(725, 490);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "YMH 219 - Eğitsel Key Event Logger";
        KeyPreview = true;
        Controls.AddRange(new Control[] { pnlHeader, lblInfo, txtTestArea, lstLogs, lblStats });
        KeyDown += MainForm_KeyDown;
        KeyUp += MainForm_KeyUp;

        ResumeLayout(false);
        PerformLayout();
    }
}
