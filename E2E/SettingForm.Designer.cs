using System.ComponentModel;

namespace E2E;

partial class SettingForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(SettingForm));
        SettingList = new ListView();
        SuspendLayout();
        // 
        // SettingList
        // 
        SettingList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        SettingList.Location = new Point(12, 1);
        SettingList.Name = "SettingList";
        SettingList.Size = new Size(328, 562);
        SettingList.TabIndex = 0;
        SettingList.UseCompatibleStateImageBehavior = false;
        // 
        // Setting
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        CausesValidation = false;
        ClientSize = new Size(386, 271);
        Controls.Add(SettingList);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "SettingForm";
        Text = "Setting";
        FormClosed += Setting_FormClosed;
        ResumeLayout(false);
    }

    #endregion

    private ListView SettingList;
}