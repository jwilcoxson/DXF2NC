namespace DXF2NC
{
    partial class Rotate
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
            lblAngle = new Label();
            txtAngle = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            lblDegree = new Label();
            SuspendLayout();
            // 
            // lblAngle
            // 
            lblAngle.AutoSize = true;
            lblAngle.Location = new Point(12, 12);
            lblAngle.Name = "lblAngle";
            lblAngle.Size = new Size(48, 20);
            lblAngle.TabIndex = 0;
            lblAngle.Text = "Angle";
            // 
            // txtAngle
            // 
            txtAngle.Location = new Point(68, 9);
            txtAngle.Name = "txtAngle";
            txtAngle.Size = new Size(64, 27);
            txtAngle.TabIndex = 1;
            txtAngle.Text = "0.000";
            txtAngle.TextChanged += txtAngle_TextChanged;
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
            // lblDegree
            // 
            lblDegree.AutoSize = true;
            lblDegree.Location = new Point(138, 12);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(64, 20);
            lblDegree.TabIndex = 10;
            lblDegree.Text = "Degrees";
            // 
            // Rotate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 126);
            ControlBox = false;
            Controls.Add(lblDegree);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtAngle);
            Controls.Add(lblAngle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            Name = "Rotate";
            Text = "Rotate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAngle;
        private TextBox txtAngle;
        private Button btnCancel;
        private Button btnOk;
        private Label lblDegree;
    }
}