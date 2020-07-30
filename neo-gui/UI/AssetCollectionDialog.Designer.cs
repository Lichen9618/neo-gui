namespace Neo.UI
{
    partial class AssetCollectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.comboBoxAssetHash = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCollectTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxAssetHash
            // 
            this.comboBoxAssetHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAssetHash.FormattingEnabled = true;
            this.comboBoxAssetHash.Location = new System.Drawing.Point(116, 52);
            this.comboBoxAssetHash.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAssetHash.Name = "comboBoxAssetHash";
            this.comboBoxAssetHash.Size = new System.Drawing.Size(386, 20);
            this.comboBoxAssetHash.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Asset Hash:";
            // 
            // textBoxCollectTo
            // 
            this.textBoxCollectTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCollectTo.Location = new System.Drawing.Point(116, 104);
            this.textBoxCollectTo.Name = "textBoxCollectTo";
            this.textBoxCollectTo.Size = new System.Drawing.Size(386, 21);
            this.textBoxCollectTo.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Collect to:";
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(116, 174);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(75, 23);
            this.buttonPreview.TabIndex = 17;
            this.buttonPreview.Text = "preview";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(341, 174);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 18;
            this.buttonConfirm.Text = "confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // AssetCollectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 242);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.textBoxCollectTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAssetHash);
            this.Name = "AssetCollectionDialog";
            this.Text = "AssetCollectionDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAssetHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCollectTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonConfirm;
    }
}