﻿namespace LoraTool
{
    partial class mainForm
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(25, 61);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(396, 357);
            this.textBox.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(22, 25);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(112, 15);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "状态：未连接！";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(316, 15);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(105, 34);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "重新连接";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(25, 434);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(312, 25);
            this.sendTextBox.TabIndex = 3;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendTextBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(356, 424);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(65, 41);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 488);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.textBox);
            this.Name = "mainForm";
            this.Text = "SkyLoraWings 工具包 1.0";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}
