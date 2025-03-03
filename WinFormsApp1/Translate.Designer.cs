namespace DXF2NC
{
    partial class Translate
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
            lblXAxis = new Label();
            txtXAxis = new TextBox();
            txtYAxis = new TextBox();
            lblYAxis = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblXAxis
            // 
            lblXAxis.AutoSize = true;
            lblXAxis.Location = new Point(12, 12);
            lblXAxis.Name = "lblXAxis";
            lblXAxis.Size = new Size(47, 20);
            lblXAxis.TabIndex = 0;
            lblXAxis.Text = "X axis";
            // 
            // txtXAxis
            // 
            txtXAxis.Location = new Point(68, 9);
            txtXAxis.Name = "txtXAxis";
            txtXAxis.Size = new Size(64, 27);
            txtXAxis.TabIndex = 1;
            txtXAxis.Text = "0.000";
            txtXAxis.TextChanged += txtXAxis_TextChanged;
            // 
            // txtYAxis
            // 
            txtYAxis.Location = new Point(68, 42);
            txtYAxis.Name = "txtYAxis";
            txtYAxis.Size = new Size(64, 27);
            txtYAxis.TabIndex = 3;
            txtYAxis.Text = "0.000";
            txtYAxis.TextChanged += txtYAxis_TextChanged;
            // 
            // lblYAxis
            // 
            lblYAxis.AutoSize = true;
            lblYAxis.Location = new Point(12, 45);
            lblYAxis.Name = "lblYAxis";
            lblYAxis.Size = new Size(46, 20);
            lblYAxis.TabIndex = 2;
            lblYAxis.Text = "Y axis";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(118, 75);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 41);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 75);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 41);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // Translate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 126);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtYAxis);
            Controls.Add(lblYAxis);
            Controls.Add(txtXAxis);
            Controls.Add(lblXAxis);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            Name = "Translate";
            Text = "Translate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblXAxis;
        private TextBox txtXAxis;
        private TextBox txtYAxis;
        private Label lblYAxis;
        private Button btnCancel;
        private Button btnOk;
    }
}