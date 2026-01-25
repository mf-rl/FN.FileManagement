
namespace FN.WinForm
{
    partial class ImageUploader
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
            imagePreview = new System.Windows.Forms.PictureBox();
            oImagePath = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label2 = new System.Windows.Forms.Label();
            cmbSizeMax = new System.Windows.Forms.ComboBox();
            button2 = new System.Windows.Forms.Button();
            dImageProperties = new System.Windows.Forms.TextBox();
            imageSaved = new System.Windows.Forms.PictureBox();
            oImageProperties = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            cmbPercent = new System.Windows.Forms.ComboBox();
            button3 = new System.Windows.Forms.Button();
            lblStatusUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)imagePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageSaved).BeginInit();
            SuspendLayout();
            // 
            // imagePreview
            // 
            imagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            imagePreview.Location = new System.Drawing.Point(4, 40);
            imagePreview.Name = "imagePreview";
            imagePreview.Size = new System.Drawing.Size(624, 306);
            imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            imagePreview.TabIndex = 15;
            imagePreview.TabStop = false;
            // 
            // oImagePath
            // 
            oImagePath.Location = new System.Drawing.Point(103, 7);
            oImagePath.Name = "oImagePath";
            oImagePath.ReadOnly = true;
            oImagePath.Size = new System.Drawing.Size(247, 23);
            oImagePath.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(4, 7);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(93, 23);
            button1.TabIndex = 13;
            button1.Text = "Select image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "JPG files | *.jpg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(620, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 15);
            label2.TabIndex = 23;
            label2.Text = "Size lim.";
            // 
            // cmbSizeMax
            // 
            cmbSizeMax.FormattingEnabled = true;
            cmbSizeMax.Location = new System.Drawing.Point(671, 7);
            cmbSizeMax.Name = "cmbSizeMax";
            cmbSizeMax.Size = new System.Drawing.Size(66, 23);
            cmbSizeMax.TabIndex = 22;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(740, 7);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(104, 23);
            button2.TabIndex = 19;
            button2.Text = "Compress image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dImageProperties
            // 
            dImageProperties.Location = new System.Drawing.Point(634, 352);
            dImageProperties.Multiline = true;
            dImageProperties.Name = "dImageProperties";
            dImageProperties.ReadOnly = true;
            dImageProperties.Size = new System.Drawing.Size(210, 180);
            dImageProperties.TabIndex = 18;
            // 
            // imageSaved
            // 
            imageSaved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            imageSaved.Location = new System.Drawing.Point(4, 352);
            imageSaved.Name = "imageSaved";
            imageSaved.Size = new System.Drawing.Size(624, 306);
            imageSaved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            imageSaved.TabIndex = 17;
            imageSaved.TabStop = false;
            // 
            // oImageProperties
            // 
            oImageProperties.Location = new System.Drawing.Point(634, 40);
            oImageProperties.Multiline = true;
            oImageProperties.Name = "oImageProperties";
            oImageProperties.ReadOnly = true;
            oImageProperties.Size = new System.Drawing.Size(210, 180);
            oImageProperties.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(534, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 15);
            label4.TabIndex = 27;
            label4.Text = "Perc.";
            // 
            // cmbPercent
            // 
            cmbPercent.FormattingEnabled = true;
            cmbPercent.Location = new System.Drawing.Point(567, 8);
            cmbPercent.Name = "cmbPercent";
            cmbPercent.Size = new System.Drawing.Size(55, 23);
            cmbPercent.TabIndex = 26;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(684, 274);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(104, 23);
            button3.TabIndex = 28;
            button3.Text = "Upload image";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblStatusUpdate
            // 
            lblStatusUpdate.AutoSize = true;
            lblStatusUpdate.Location = new System.Drawing.Point(634, 559);
            lblStatusUpdate.Name = "lblStatusUpdate";
            lblStatusUpdate.Size = new System.Drawing.Size(38, 15);
            lblStatusUpdate.TabIndex = 30;
            lblStatusUpdate.Text = "status";
            lblStatusUpdate.Visible = false;
            // 
            // ImageUploader
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(849, 665);
            Controls.Add(lblStatusUpdate);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(cmbPercent);
            Controls.Add(imagePreview);
            Controls.Add(oImagePath);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(cmbSizeMax);
            Controls.Add(button2);
            Controls.Add(dImageProperties);
            Controls.Add(imageSaved);
            Controls.Add(oImageProperties);
            Name = "ImageUploader";
            Text = "Image Uploader";
            Load += ImageUploader_Load;
            ((System.ComponentModel.ISupportInitialize)imagePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageSaved).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.TextBox oImagePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSizeMax;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox dImageProperties;
        private System.Windows.Forms.PictureBox imageSaved;
        private System.Windows.Forms.TextBox oImageProperties;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPercent;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblStatusUpdate;
    }
}