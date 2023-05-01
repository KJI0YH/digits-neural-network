namespace NeuralNetworkTesting
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pbImage = new PictureBox();
            pnlImage = new Panel();
            lblState = new Label();
            btnLoad = new Button();
            btnClear = new Button();
            ofdNeuralNetwork = new OpenFileDialog();
            dgvDigits = new DataGridView();
            clDigit = new DataGridViewTextBoxColumn();
            clProbability = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDigits).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.BackColor = Color.Black;
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.Dock = DockStyle.Top;
            pbImage.Location = new Point(0, 0);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(280, 280);
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            pbImage.Paint += pbImage_Paint;
            pbImage.MouseDown += pbImage_MouseDown;
            pbImage.MouseMove += pbImage_MouseMove;
            pbImage.MouseUp += pbImage_MouseUp;
            // 
            // pnlImage
            // 
            pnlImage.Controls.Add(lblState);
            pnlImage.Controls.Add(btnLoad);
            pnlImage.Controls.Add(btnClear);
            pnlImage.Controls.Add(pbImage);
            pnlImage.Dock = DockStyle.Left;
            pnlImage.Location = new Point(0, 0);
            pnlImage.MinimumSize = new Size(280, 0);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(280, 363);
            pnlImage.TabIndex = 1;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Dock = DockStyle.Top;
            lblState.ForeColor = Color.Red;
            lblState.Location = new Point(0, 338);
            lblState.Margin = new Padding(5, 0, 3, 0);
            lblState.Name = "lblState";
            lblState.Size = new Size(226, 20);
            lblState.TabIndex = 3;
            lblState.Text = "The neural network is not loaded";
            // 
            // btnLoad
            // 
            btnLoad.Dock = DockStyle.Top;
            btnLoad.Location = new Point(0, 309);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(280, 29);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load neural network";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Top;
            btnClear.Location = new Point(0, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(280, 29);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // ofdNeuralNetwork
            // 
            ofdNeuralNetwork.DefaultExt = "*.nn";
            ofdNeuralNetwork.Filter = "Neural network files (*.nn)|*.nn";
            ofdNeuralNetwork.Title = "Load neural network";
            // 
            // dgvDigits
            // 
            dgvDigits.AllowUserToAddRows = false;
            dgvDigits.AllowUserToDeleteRows = false;
            dgvDigits.AllowUserToResizeColumns = false;
            dgvDigits.AllowUserToResizeRows = false;
            dgvDigits.BackgroundColor = Color.White;
            dgvDigits.BorderStyle = BorderStyle.None;
            dgvDigits.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDigits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDigits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDigits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDigits.Columns.AddRange(new DataGridViewColumn[] { clDigit, clProbability });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDigits.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDigits.Dock = DockStyle.Left;
            dgvDigits.GridColor = Color.White;
            dgvDigits.Location = new Point(280, 0);
            dgvDigits.MultiSelect = false;
            dgvDigits.Name = "dgvDigits";
            dgvDigits.ReadOnly = true;
            dgvDigits.RowHeadersVisible = false;
            dgvDigits.RowHeadersWidth = 51;
            dgvDigits.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvDigits.RowTemplate.Height = 29;
            dgvDigits.RowTemplate.ReadOnly = true;
            dgvDigits.ScrollBars = ScrollBars.None;
            dgvDigits.Size = new Size(182, 363);
            dgvDigits.TabIndex = 2;
            dgvDigits.TabStop = false;
            // 
            // clDigit
            // 
            clDigit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            clDigit.HeaderText = "Digit";
            clDigit.MinimumWidth = 6;
            clDigit.Name = "clDigit";
            clDigit.ReadOnly = true;
            clDigit.Resizable = DataGridViewTriState.False;
            clDigit.Width = 71;
            // 
            // clProbability
            // 
            clProbability.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            clProbability.HeaderText = "Probability";
            clProbability.MinimumWidth = 6;
            clProbability.Name = "clProbability";
            clProbability.ReadOnly = true;
            clProbability.Resizable = DataGridViewTriState.False;
            clProbability.Width = 110;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(462, 363);
            Controls.Add(dgvDigits);
            Controls.Add(pnlImage);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(480, 410);
            MinimumSize = new Size(480, 410);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digits neural network";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            pnlImage.ResumeLayout(false);
            pnlImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDigits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pbImage;
        private Panel pnlImage;
        private Label lblState;
        private Button btnLoad;
        private Button btnClear;
        public OpenFileDialog ofdNeuralNetwork;
        private DataGridView dgvDigits;
        private DataGridViewTextBoxColumn clDigit;
        private DataGridViewTextBoxColumn clProbability;
    }
}