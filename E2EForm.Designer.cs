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
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.LogBox = new Sunny.UI.UIRichTextBox();
            this.LinkLabel = new Sunny.UI.UILinkLabel();
            this.Convert = new Sunny.UI.UIButton();
            this.Setting = new Sunny.UI.UIButton();
            this.CheckBoxList = new Sunny.UI.UIListBox();
            this.SuspendLayout();
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(18, 429);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(192, 29);
            this.uiComboBox1.SymbolSize = 24;
            this.uiComboBox1.TabIndex = 2;
            this.uiComboBox1.Text = "uiComboBox1";
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // LogBox
            // 
            this.LogBox.FillColor = System.Drawing.Color.White;
            this.LogBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogBox.Location = new System.Drawing.Point(218, 45);
            this.LogBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LogBox.Name = "LogBox";
            this.LogBox.Padding = new System.Windows.Forms.Padding(2);
            this.LogBox.ReadOnly = true;
            this.LogBox.ShowText = false;
            this.LogBox.Size = new System.Drawing.Size(350, 494);
            this.LogBox.TabIndex = 3;
            this.LogBox.Text = "欢迎使用ExcelToEverything，这是一个Excel格式转换工具，详细使用说明请点击左下方链接【工程地址】";
            this.LogBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.LogBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // LinkLabel
            // 
            this.LinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.LinkLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.LinkLabel.Location = new System.Drawing.Point(125, 478);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(86, 23);
            this.LinkLabel.TabIndex = 4;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.TagString = "";
            this.LinkLabel.Text = "工程链接";
            this.LinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LinkLabel.Click += new System.EventHandler(this.LinkLabel_Click);
            // 
            // Convert
            // 
            this.Convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Convert.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Convert.Location = new System.Drawing.Point(18, 504);
            this.Convert.MinimumSize = new System.Drawing.Size(1, 1);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(192, 35);
            this.Convert.TabIndex = 5;
            this.Convert.Text = "Convert";
            this.Convert.TipsFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Setting
            // 
            this.Setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Setting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Setting.Location = new System.Drawing.Point(18, 466);
            this.Setting.MinimumSize = new System.Drawing.Size(1, 1);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(100, 32);
            this.Setting.TabIndex = 6;
            this.Setting.Text = "Setting";
            this.Setting.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // CheckBoxList
            // 
            this.CheckBoxList.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckBoxList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBoxList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CheckBoxList.ItemSelectForeColor = System.Drawing.Color.White;
            this.CheckBoxList.Location = new System.Drawing.Point(18, 45);
            this.CheckBoxList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxList.MinimumSize = new System.Drawing.Size(1, 1);
            this.CheckBoxList.Name = "CheckBoxList";
            this.CheckBoxList.Padding = new System.Windows.Forms.Padding(2);
            this.CheckBoxList.ShowText = false;
            this.CheckBoxList.Size = new System.Drawing.Size(192, 374);
            this.CheckBoxList.TabIndex = 1;
            this.CheckBoxList.Text = "CheckListBox";
            // 
            // E2EForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 549);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.uiComboBox1);
            this.Controls.Add(this.CheckBoxList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2560, 1600);
            this.MinimizeBox = false;
            this.Name = "E2EForm";
            this.Padding = new System.Windows.Forms.Padding(2, 29, 2, 2);
            this.ShowFullScreen = true;
            this.ShowRadius = true;
            this.ShowShadow = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "E2E - Convert Excel To Everything!";
            this.TitleHeight = 29;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 499, 514);
            this.Load += new System.EventHandler(this.E2E_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIRichTextBox LogBox;
        private Sunny.UI.UILinkLabel LinkLabel;
        private Sunny.UI.UIButton Convert;
        private Sunny.UI.UIButton Setting;
        private Sunny.UI.UIListBox CheckBoxList;
    }
}

