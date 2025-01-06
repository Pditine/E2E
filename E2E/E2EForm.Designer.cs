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
            this.Converter = new System.Windows.Forms.ComboBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.LinkLabel = new System.Windows.Forms.LinkLabel();
            this.Convert = new System.Windows.Forms.Button();
            this.Setting = new System.Windows.Forms.Button();
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Converter
            // 
            this.Converter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Converter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Converter.Location = new System.Drawing.Point(6, 435);
            this.Converter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Converter.MinimumSize = new System.Drawing.Size(63, 0);
            this.Converter.Name = "Converter";
            this.Converter.Size = new System.Drawing.Size(195, 24);
            this.Converter.TabIndex = 2;
            this.Converter.Text = "Converter";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogBox.Location = new System.Drawing.Point(209, 7);
            this.LogBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.LogBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(367, 535);
            this.LogBox.TabIndex = 3;
            this.LogBox.Text = "欢迎使用ExcelToEverything，这是一个Excel格式转换工具，支持自定义格式转换规则，详细使用说明请点击左下方链接【工程地址】";
            // 
            // LinkLabel
            // 
            this.LinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.LinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LinkLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.LinkLabel.Location = new System.Drawing.Point(107, 475);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(77, 23);
            this.LinkLabel.TabIndex = 4;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.Text = "工程链接";
            this.LinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LinkLabel.Click += new System.EventHandler(this.LinkLabel_Click);
            // 
            // Convert
            // 
            this.Convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Convert.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Convert.Location = new System.Drawing.Point(7, 505);
            this.Convert.MinimumSize = new System.Drawing.Size(1, 1);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(92, 35);
            this.Convert.TabIndex = 5;
            this.Convert.Text = "Convert";
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Setting
            // 
            this.Setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Setting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Setting.Location = new System.Drawing.Point(7, 467);
            this.Setting.MinimumSize = new System.Drawing.Size(1, 1);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(94, 32);
            this.Setting.TabIndex = 6;
            this.Setting.Text = "Setting";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckedListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckedListBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckedListBox.HorizontalScrollbar = true;
            this.CheckedListBox.Location = new System.Drawing.Point(6, 7);
            this.CheckedListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckedListBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.CheckedListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size(195, 418);
            this.CheckedListBox.TabIndex = 1;
            // 
            // Refresh
            // 
            this.Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Refresh.Location = new System.Drawing.Point(104, 505);
            this.Refresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(97, 35);
            this.Refresh.TabIndex = 7;
            this.Refresh.Text = "Refresh";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // E2EForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 549);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.Converter);
            this.Controls.Add(this.CheckedListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2560, 1600);
            this.MinimizeBox = false;
            this.Name = "E2EForm";
            this.Padding = new System.Windows.Forms.Padding(2, 29, 2, 2);
            this.Text = "E2E - Convert Excel To Everything!";
            this.Load += new System.EventHandler(this.E2E_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox Converter;
        private RichTextBox LogBox;
        private LinkLabel LinkLabel;
        private Button Convert;
        private Button Setting;
        private CheckedListBox CheckedListBox;
        private Button Refresh;
    }
}

