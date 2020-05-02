namespace ImageResizeAsyncApp
{
    partial class ImageResizeAsyncAppForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageResizeAsyncAppForm));
            this.resizeDropArea = new System.Windows.Forms.Label();
            this.folderSelectTextLabel = new System.Windows.Forms.Label();
            this.folderInputTextbox = new System.Windows.Forms.TextBox();
            this.folderSelectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressDisplayLabel = new System.Windows.Forms.Label();
            this.radioButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton1200pixels = new System.Windows.Forms.RadioButton();
            this.radioButton900pixels = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.radioButtonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // resizeDropArea
            // 
            this.resizeDropArea.AllowDrop = true;
            this.resizeDropArea.BackColor = System.Drawing.Color.PaleGreen;
            this.resizeDropArea.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.resizeDropArea.Location = new System.Drawing.Point(14, 95);
            this.resizeDropArea.Name = "resizeDropArea";
            this.resizeDropArea.Size = new System.Drawing.Size(181, 107);
            this.resizeDropArea.TabIndex = 0;
            this.resizeDropArea.Text = "画像をリサイズして\r\n指定のフォルダに\r\nZIPファイルを作成します\r\nフォルダをドロップしてください";
            this.resizeDropArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resizeDropArea.DragDrop += new System.Windows.Forms.DragEventHandler(this.ResizeDrop);
            this.resizeDropArea.DragEnter += new System.Windows.Forms.DragEventHandler(this.ResizeDrag);
            // 
            // folderSelectTextLabel
            // 
            this.folderSelectTextLabel.AutoSize = true;
            this.folderSelectTextLabel.Location = new System.Drawing.Point(12, 9);
            this.folderSelectTextLabel.Name = "folderSelectTextLabel";
            this.folderSelectTextLabel.Size = new System.Drawing.Size(70, 12);
            this.folderSelectTextLabel.TabIndex = 1;
            this.folderSelectTextLabel.Text = "保存フォルダ：";
            // 
            // folderInputTextbox
            // 
            this.folderInputTextbox.Location = new System.Drawing.Point(14, 25);
            this.folderInputTextbox.Name = "folderInputTextbox";
            this.folderInputTextbox.Size = new System.Drawing.Size(134, 19);
            this.folderInputTextbox.TabIndex = 2;
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(152, 24);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(43, 21);
            this.folderSelectButton.TabIndex = 3;
            this.folderSelectButton.Text = "選択";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.FolderSelectButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 206);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(181, 16);
            this.progressBar.TabIndex = 4;
            // 
            // progressDisplayLabel
            // 
            this.progressDisplayLabel.BackColor = System.Drawing.Color.White;
            this.progressDisplayLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.progressDisplayLabel.Location = new System.Drawing.Point(14, 227);
            this.progressDisplayLabel.Name = "progressDisplayLabel";
            this.progressDisplayLabel.Size = new System.Drawing.Size(181, 23);
            this.progressDisplayLabel.TabIndex = 5;
            this.progressDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonGroupBox
            // 
            this.radioButtonGroupBox.Controls.Add(this.radioButton1200pixels);
            this.radioButtonGroupBox.Controls.Add(this.radioButton900pixels);
            this.radioButtonGroupBox.Location = new System.Drawing.Point(14, 50);
            this.radioButtonGroupBox.Name = "radioButtonGroupBox";
            this.radioButtonGroupBox.Size = new System.Drawing.Size(181, 42);
            this.radioButtonGroupBox.TabIndex = 6;
            this.radioButtonGroupBox.TabStop = false;
            this.radioButtonGroupBox.Text = "画像の高さを選択してください";
            // 
            // radioButton1200pixels
            // 
            this.radioButton1200pixels.AutoSize = true;
            this.radioButton1200pixels.Location = new System.Drawing.Point(94, 18);
            this.radioButton1200pixels.Name = "radioButton1200pixels";
            this.radioButton1200pixels.Size = new System.Drawing.Size(81, 16);
            this.radioButton1200pixels.TabIndex = 1;
            this.radioButton1200pixels.Text = "1200 pixels";
            this.radioButton1200pixels.UseVisualStyleBackColor = true;
            // 
            // radioButton900pixels
            // 
            this.radioButton900pixels.AutoSize = true;
            this.radioButton900pixels.Checked = true;
            this.radioButton900pixels.Location = new System.Drawing.Point(13, 18);
            this.radioButton900pixels.Name = "radioButton900pixels";
            this.radioButton900pixels.Size = new System.Drawing.Size(75, 16);
            this.radioButton900pixels.TabIndex = 0;
            this.radioButton900pixels.TabStop = true;
            this.radioButton900pixels.Text = "900 pixels";
            this.radioButton900pixels.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 254);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(185, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ImageResizeAsyncAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 285);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.radioButtonGroupBox);
            this.Controls.Add(this.progressDisplayLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.folderInputTextbox);
            this.Controls.Add(this.folderSelectTextLabel);
            this.Controls.Add(this.resizeDropArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(70, 160);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageResizeAsyncAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "画像リサイズZIPアプリ";
            this.Load += new System.EventHandler(this.ImageResizeAppForm_Load);
            this.radioButtonGroupBox.ResumeLayout(false);
            this.radioButtonGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resizeDropArea;
        private System.Windows.Forms.Label folderSelectTextLabel;
        private System.Windows.Forms.TextBox folderInputTextbox;
        private System.Windows.Forms.FolderBrowserDialog folderSelectDialog;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressDisplayLabel;
        private System.Windows.Forms.GroupBox radioButtonGroupBox;
        private System.Windows.Forms.RadioButton radioButton1200pixels;
        private System.Windows.Forms.RadioButton radioButton900pixels;
        private System.Windows.Forms.Button cancelButton;
    }
}

