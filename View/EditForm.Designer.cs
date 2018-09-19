namespace View
{
    partial class EditForm
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
            this._labelValue = new System.Windows.Forms.Label();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this._buttonEdit = new System.Windows.Forms.Button();
            this._buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(12, 9);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(56, 13);
            this._labelValue.TabIndex = 1;
            this._labelValue.Text = "Номинал:";
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(74, 6);
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(68, 20);
            this._textBoxValue.TabIndex = 2;
            this._textBoxValue.TextChanged += new System.EventHandler(this.TextBoxValue_TextChanged);
            // 
            // _buttonEdit
            // 
            this._buttonEdit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonEdit.Location = new System.Drawing.Point(15, 32);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Size = new System.Drawing.Size(127, 23);
            this._buttonEdit.TabIndex = 3;
            this._buttonEdit.Text = "Изменить";
            this._buttonEdit.UseVisualStyleBackColor = true;
            this._buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // _buttonClose
            // 
            this._buttonClose.Location = new System.Drawing.Point(15, 61);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(127, 23);
            this._buttonClose.TabIndex = 4;
            this._buttonClose.Text = "Отмена";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 94);
            this.ControlBox = false;
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._buttonEdit);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this._labelValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "R2018";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.TextBox _textBoxValue;
        private System.Windows.Forms.Button _buttonEdit;
        private System.Windows.Forms.Button _buttonClose;
    }
}