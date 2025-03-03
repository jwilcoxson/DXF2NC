namespace DXF2NC
{
    partial class Scale
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
            lblXScale = new Label();
            txtXScale = new TextBox();
            label1 = new Label();
            lblYScale = new Label();
            txtYScale = new TextBox();
            label3 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblXScale
            // 
            lblXScale.AutoSize = true;
            lblXScale.Location = new Point(12, 9);
            lblXScale.Name = "lblXScale";
            lblXScale.Size = new Size(55, 20);
            lblXScale.TabIndex = 0;
            lblXScale.Text = "X scale";
            // 
            // txtXScale
            // 
            txtXScale.Location = new Point(73, 6);
            txtXScale.Name = "txtXScale";
            txtXScale.Size = new Size(52, 27);
            txtXScale.TabIndex = 1;
            txtXScale.Text = "100";
            txtXScale.TextChanged += txtXScale_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 9);
            label1.Name = "label1";
            label1.Size = new Size(21, 20);
            label1.TabIndex = 2;
            label1.Text = "%";
            // 
            // lblYScale
            // 
            lblYScale.AutoSize = true;
            lblYScale.Location = new Point(12, 42);
            lblYScale.Name = "lblYScale";
            lblYScale.Size = new Size(54, 20);
            lblYScale.TabIndex = 3;
            lblYScale.Text = "Y scale";
            // 
            // txtYScale
            // 
            txtYScale.Location = new Point(73, 39);
            txtYScale.Name = "txtYScale";
            txtYScale.Size = new Size(52, 27);
            txtYScale.TabIndex = 4;
            txtYScale.Text = "100";
            txtYScale.TextChanged += txtYScale_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(131, 42);
            label3.Name = "label3";
            label3.Size = new Size(21, 20);
            label3.TabIndex = 5;
            label3.Text = "%";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 84);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 41);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(118, 84);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 41);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Scale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(231, 138);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label3);
            Controls.Add(txtYScale);
            Controls.Add(lblYScale);
            Controls.Add(label1);
            Controls.Add(txtXScale);
            Controls.Add(lblXScale);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Scale";
            Text = "Scale";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblXScale;
        private TextBox txtXScale;
        private Label label1;
        private Label lblYScale;
        private TextBox txtYScale;
        private Label label3;
        private Button btnOk;
        private Button btnCancel;
    }
}