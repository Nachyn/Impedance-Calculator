using View.Helpers;

namespace View
{
    partial class ImpedanceForm
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
            this.components = new System.ComponentModel.Container();
            this._labelStart = new System.Windows.Forms.Label();
            this._labelStep = new System.Windows.Forms.Label();
            this._textBoxStart = new System.Windows.Forms.TextBox();
            this._textBoxStep = new System.Windows.Forms.TextBox();
            this.impedanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._trackBarCount = new System.Windows.Forms.TrackBar();
            this._labelCount = new System.Windows.Forms.Label();
            this._labelError = new System.Windows.Forms.Label();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.frequencyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impedanceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._calculationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._trackBarCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _labelStart
            // 
            this._labelStart.AutoSize = true;
            this._labelStart.Location = new System.Drawing.Point(12, 9);
            this._labelStart.Name = "_labelStart";
            this._labelStart.Size = new System.Drawing.Size(47, 13);
            this._labelStart.TabIndex = 0;
            this._labelStart.Text = "Начало:";
            // 
            // _labelStep
            // 
            this._labelStep.AutoSize = true;
            this._labelStep.Location = new System.Drawing.Point(12, 35);
            this._labelStep.Name = "_labelStep";
            this._labelStep.Size = new System.Drawing.Size(30, 13);
            this._labelStep.TabIndex = 2;
            this._labelStep.Text = "Шаг:";
            // 
            // _textBoxStart
            // 
            this._textBoxStart.Location = new System.Drawing.Point(65, 6);
            this._textBoxStart.Name = "_textBoxStart";
            this._textBoxStart.Size = new System.Drawing.Size(168, 20);
            this._textBoxStart.TabIndex = 3;
            this._textBoxStart.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // _textBoxStep
            // 
            this._textBoxStep.Location = new System.Drawing.Point(65, 32);
            this._textBoxStep.Name = "_textBoxStep";
            this._textBoxStep.Size = new System.Drawing.Size(168, 20);
            this._textBoxStep.TabIndex = 4;
            this._textBoxStep.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // impedanceDataGridViewTextBoxColumn
            // 
            this.impedanceDataGridViewTextBoxColumn.DataPropertyName = "Impedance";
            this.impedanceDataGridViewTextBoxColumn.HeaderText = "Impedance";
            this.impedanceDataGridViewTextBoxColumn.Name = "impedanceDataGridViewTextBoxColumn";
            this.impedanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            this.frequencyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _trackBarCount
            // 
            this._trackBarCount.Location = new System.Drawing.Point(15, 58);
            this._trackBarCount.Maximum = 20;
            this._trackBarCount.Minimum = 1;
            this._trackBarCount.Name = "_trackBarCount";
            this._trackBarCount.Size = new System.Drawing.Size(218, 45);
            this._trackBarCount.TabIndex = 7;
            this._trackBarCount.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackBarCount.Value = 1;
            this._trackBarCount.Scroll += new System.EventHandler(this.Control_TextChanged);
            // 
            // _labelCount
            // 
            this._labelCount.AutoSize = true;
            this._labelCount.Location = new System.Drawing.Point(12, 90);
            this._labelCount.Name = "_labelCount";
            this._labelCount.Size = new System.Drawing.Size(127, 13);
            this._labelCount.TabIndex = 8;
            this._labelCount.Text = "Количество расчетов: 1";
            // 
            // _labelError
            // 
            this._labelError.AutoSize = true;
            this._labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelError.ForeColor = System.Drawing.Color.Red;
            this._labelError.Location = new System.Drawing.Point(32, 266);
            this._labelError.Name = "_labelError";
            this._labelError.Size = new System.Drawing.Size(183, 24);
            this._labelError.TabIndex = 9;
            this._labelError.Text = "Максимальная частота может принимать\r\nзначение только от 1 Гц. до 1 ТГц..";
            this._labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AutoGenerateColumns = false;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frequencyDataGridViewTextBoxColumn1,
            this.impedanceDataGridViewTextBoxColumn1});
            this._dataGridView.DataSource = this._calculationBindingSource;
            this._dataGridView.Location = new System.Drawing.Point(15, 106);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridView.Size = new System.Drawing.Size(218, 157);
            this._dataGridView.TabIndex = 10;
            // 
            // frequencyDataGridViewTextBoxColumn1
            // 
            this.frequencyDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.frequencyDataGridViewTextBoxColumn1.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn1.HeaderText = "Частота";
            this.frequencyDataGridViewTextBoxColumn1.Name = "frequencyDataGridViewTextBoxColumn1";
            this.frequencyDataGridViewTextBoxColumn1.ReadOnly = true;
            this.frequencyDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // impedanceDataGridViewTextBoxColumn1
            // 
            this.impedanceDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.impedanceDataGridViewTextBoxColumn1.DataPropertyName = "Impedance";
            this.impedanceDataGridViewTextBoxColumn1.HeaderText = "Импеданс";
            this.impedanceDataGridViewTextBoxColumn1.Name = "impedanceDataGridViewTextBoxColumn1";
            this.impedanceDataGridViewTextBoxColumn1.ReadOnly = true;
            this.impedanceDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _calculationBindingSource
            // 
            this._calculationBindingSource.DataSource = typeof(Calculation);
            // 
            // ImpedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 293);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._labelError);
            this.Controls.Add(this._labelCount);
            this.Controls.Add(this._trackBarCount);
            this.Controls.Add(this._textBoxStep);
            this.Controls.Add(this._textBoxStart);
            this.Controls.Add(this._labelStep);
            this.Controls.Add(this._labelStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImpedanceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расчеты";
            ((System.ComponentModel.ISupportInitialize)(this._trackBarCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._calculationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelStart;
        private System.Windows.Forms.Label _labelStep;
        private System.Windows.Forms.TextBox _textBoxStart;
        private System.Windows.Forms.TextBox _textBoxStep;
        private System.Windows.Forms.TrackBar _trackBarCount;
        private System.Windows.Forms.Label _labelCount;
        private System.Windows.Forms.Label _labelError;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn impedanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource _calculationBindingSource;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn impedanceDataGridViewTextBoxColumn1;
    }
}