using System.Windows.Forms;

namespace E2E
{
    partial class E2EForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E2EForm));
            ConverterOption = new ComboBox();
            LogBox = new RichTextBox();
            LinkLabel = new LinkLabel();
            Convert = new Button();
            Setting = new Button();
            CheckedListBox = new CheckedListBox();
            Refresh = new Button();
            SuspendLayout();
            // 
            // ConverterOption
            // 
            ConverterOption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConverterOption.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ConverterOption.Location = new Point(6, 435);
            ConverterOption.Margin = new Padding(4, 5, 4, 5);
            ConverterOption.MinimumSize = new Size(63, 0);
            ConverterOption.Name = "ConverterOption";
            ConverterOption.Size = new Size(195, 24);
            ConverterOption.TabIndex = 2;
            ConverterOption.Text = "Converter";
            // 
            // LogBox
            // 
            LogBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogBox.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LogBox.Location = new Point(209, 7);
            LogBox.Margin = new Padding(4, 5, 4, 5);
            LogBox.MaximumSize = new Size(1000, 1000);
            LogBox.MinimumSize = new Size(1, 1);
            LogBox.Name = "LogBox";
            LogBox.ReadOnly = true;
            LogBox.Size = new Size(367, 535);
            LogBox.TabIndex = 3;
            LogBox.Text = "欢迎使用ExcelToEverything，这是一个Excel格式转换工具，支持自定义格式转换规则，详细使用说明请点击左下方链接【工程地址】";
            // 
            // LinkLabel
            // 
            LinkLabel.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            LinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LinkLabel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LinkLabel.ForeColor = Color.FromArgb(48, 48, 48);
            LinkLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;
            LinkLabel.Location = new Point(114, 475);
            LinkLabel.MaximumSize = new Size(77, 23);
            LinkLabel.Name = "LinkLabel";
            LinkLabel.Size = new Size(77, 23);
            LinkLabel.TabIndex = 4;
            LinkLabel.TabStop = true;
            LinkLabel.Text = "工程链接";
            LinkLabel.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            LinkLabel.LinkClicked += LinkLabel_LinkClicked;
            LinkLabel.Click += LinkLabel_Click;
            // 
            // Convert
            // 
            Convert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Convert.Cursor = Cursors.Hand;
            Convert.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Convert.Location = new Point(7, 505);
            Convert.MaximumSize = new Size(92, 35);
            Convert.MinimumSize = new Size(1, 1);
            Convert.Name = "Convert";
            Convert.Size = new Size(92, 35);
            Convert.TabIndex = 5;
            Convert.Text = "Convert";
            Convert.Click += Convert_Click;
            // 
            // Setting
            // 
            Setting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Setting.Cursor = Cursors.Hand;
            Setting.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Setting.Location = new Point(7, 467);
            Setting.MaximumSize = new Size(94, 32);
            Setting.MinimumSize = new Size(1, 1);
            Setting.Name = "Setting";
            Setting.Size = new Size(92, 32);
            Setting.TabIndex = 6;
            Setting.Text = "Setting";
            Setting.Click += Setting_Click;
            // 
            // CheckedListBox
            // 
            CheckedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            CheckedListBox.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            CheckedListBox.HorizontalScrollbar = true;
            CheckedListBox.Location = new Point(6, 7);
            CheckedListBox.Margin = new Padding(4, 5, 4, 5);
            CheckedListBox.MaximumSize = new Size(1000, 1000);
            CheckedListBox.MinimumSize = new Size(1, 1);
            CheckedListBox.Name = "CheckedListBox";
            CheckedListBox.Size = new Size(195, 418);
            CheckedListBox.TabIndex = 1;
            // 
            // Refresh
            // 
            Refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Refresh.Cursor = Cursors.Hand;
            Refresh.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Refresh.Location = new Point(104, 505);
            Refresh.MaximumSize = new Size(97, 35);
            Refresh.MinimumSize = new Size(1, 1);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(97, 35);
            Refresh.TabIndex = 7;
            Refresh.Text = "Refresh";
            Refresh.Click += Refresh_Click;
            // 
            // E2EForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(582, 549);
            Controls.Add(Refresh);
            Controls.Add(Setting);
            Controls.Add(Convert);
            Controls.Add(LinkLabel);
            Controls.Add(LogBox);
            Controls.Add(ConverterOption);
            Controls.Add(CheckedListBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MaximumSize = new Size(2560, 1600);
            MinimizeBox = false;
            Name = "E2EForm";
            Padding = new Padding(2, 29, 2, 2);
            Text = "E2E - Convert Excel To Everything!";
            Load += E2E_Load;
            ResumeLayout(false);
        }

        #endregion
        private ComboBox ConverterOption;
        private RichTextBox LogBox;
        private LinkLabel LinkLabel;
        private Button Convert;
        private Button Setting;
        private CheckedListBox CheckedListBox;
        private Button Refresh;
    }
}

