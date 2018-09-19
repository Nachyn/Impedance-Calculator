namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._comboBoxSelectCircuit = new System.Windows.Forms.ComboBox();
            this._labelSelectCircuit = new System.Windows.Forms.Label();
            this._buttonClearCircuit = new System.Windows.Forms.Button();
            this._treeViewCircuit = new System.Windows.Forms.TreeView();
            this._comboBoxAddNodeType = new System.Windows.Forms.ComboBox();
            this._textBoxAddElementValue = new System.Windows.Forms.TextBox();
            this._buttonAddElement = new System.Windows.Forms.Button();
            this._buttonRemoveElement = new System.Windows.Forms.Button();
            this._buttonCalculateFormShow = new System.Windows.Forms.Button();
            this._textBoxAddElementName = new System.Windows.Forms.TextBox();
            this._buttonOpenEditForm = new System.Windows.Forms.Button();
            this._pictureBoxCircuit = new System.Windows.Forms.PictureBox();
            this._panelCircuit = new System.Windows.Forms.Panel();
            this._buttonDrawCircuit = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxCircuit)).BeginInit();
            this._panelCircuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _comboBoxSelectCircuit
            // 
            this._comboBoxSelectCircuit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSelectCircuit.FormattingEnabled = true;
            this._comboBoxSelectCircuit.Location = new System.Drawing.Point(88, 12);
            this._comboBoxSelectCircuit.Name = "_comboBoxSelectCircuit";
            this._comboBoxSelectCircuit.Size = new System.Drawing.Size(117, 21);
            this._comboBoxSelectCircuit.TabIndex = 0;
            this._comboBoxSelectCircuit.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectCircuit_SelectedIndexChanged);
            // 
            // _labelSelectCircuit
            // 
            this._labelSelectCircuit.AutoSize = true;
            this._labelSelectCircuit.Location = new System.Drawing.Point(12, 15);
            this._labelSelectCircuit.Name = "_labelSelectCircuit";
            this._labelSelectCircuit.Size = new System.Drawing.Size(70, 13);
            this._labelSelectCircuit.TabIndex = 1;
            this._labelSelectCircuit.Text = "Выбор цепи:";
            // 
            // _buttonClearCircuit
            // 
            this._buttonClearCircuit.Location = new System.Drawing.Point(15, 39);
            this._buttonClearCircuit.Name = "_buttonClearCircuit";
            this._buttonClearCircuit.Size = new System.Drawing.Size(190, 23);
            this._buttonClearCircuit.TabIndex = 2;
            this._buttonClearCircuit.Text = "Очистить цепь";
            this._buttonClearCircuit.UseVisualStyleBackColor = true;
            this._buttonClearCircuit.Click += new System.EventHandler(this.ButtonClearCircuit_Click);
            // 
            // _treeViewCircuit
            // 
            this._treeViewCircuit.Location = new System.Drawing.Point(15, 68);
            this._treeViewCircuit.Name = "_treeViewCircuit";
            this._treeViewCircuit.Size = new System.Drawing.Size(190, 183);
            this._treeViewCircuit.TabIndex = 3;
            this._treeViewCircuit.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCircuit_AfterSelect);
            // 
            // _comboBoxAddNodeType
            // 
            this._comboBoxAddNodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxAddNodeType.FormattingEnabled = true;
            this._comboBoxAddNodeType.Location = new System.Drawing.Point(15, 257);
            this._comboBoxAddNodeType.Name = "_comboBoxAddNodeType";
            this._comboBoxAddNodeType.Size = new System.Drawing.Size(190, 21);
            this._comboBoxAddNodeType.TabIndex = 6;
            this._comboBoxAddNodeType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAddNodeType_SelectedIndexChanged);
            // 
            // _textBoxAddElementValue
            // 
            this._textBoxAddElementValue.ForeColor = System.Drawing.SystemColors.GrayText;
            this._textBoxAddElementValue.Location = new System.Drawing.Point(15, 313);
            this._textBoxAddElementValue.Name = "_textBoxAddElementValue";
            this._textBoxAddElementValue.Size = new System.Drawing.Size(92, 20);
            this._textBoxAddElementValue.TabIndex = 7;
            this._textBoxAddElementValue.Text = "Номинал..";
            this._textBoxAddElementValue.TextChanged += new System.EventHandler(this.TextBoxAddElementValue_TextChanged);
            // 
            // _buttonAddElement
            // 
            this._buttonAddElement.Location = new System.Drawing.Point(128, 284);
            this._buttonAddElement.Name = "_buttonAddElement";
            this._buttonAddElement.Size = new System.Drawing.Size(77, 49);
            this._buttonAddElement.TabIndex = 8;
            this._buttonAddElement.Text = "Добавить";
            this._buttonAddElement.UseVisualStyleBackColor = true;
            this._buttonAddElement.Click += new System.EventHandler(this.ButtonAddElement_Click);
            // 
            // _buttonRemoveElement
            // 
            this._buttonRemoveElement.Location = new System.Drawing.Point(128, 339);
            this._buttonRemoveElement.Name = "_buttonRemoveElement";
            this._buttonRemoveElement.Size = new System.Drawing.Size(77, 23);
            this._buttonRemoveElement.TabIndex = 9;
            this._buttonRemoveElement.Text = "Удалить";
            this._buttonRemoveElement.UseVisualStyleBackColor = true;
            this._buttonRemoveElement.Click += new System.EventHandler(this.ButtonRemoveElement_Click);
            // 
            // _buttonCalculateFormShow
            // 
            this._buttonCalculateFormShow.Location = new System.Drawing.Point(15, 368);
            this._buttonCalculateFormShow.Name = "_buttonCalculateFormShow";
            this._buttonCalculateFormShow.Size = new System.Drawing.Size(190, 23);
            this._buttonCalculateFormShow.TabIndex = 10;
            this._buttonCalculateFormShow.Text = "Открыть калькулятор";
            this._buttonCalculateFormShow.UseVisualStyleBackColor = true;
            this._buttonCalculateFormShow.Click += new System.EventHandler(this.ButtonCalculateFormShow_Click);
            // 
            // _textBoxAddElementName
            // 
            this._textBoxAddElementName.ForeColor = System.Drawing.SystemColors.GrayText;
            this._textBoxAddElementName.Location = new System.Drawing.Point(15, 284);
            this._textBoxAddElementName.Name = "_textBoxAddElementName";
            this._textBoxAddElementName.Size = new System.Drawing.Size(92, 20);
            this._textBoxAddElementName.TabIndex = 12;
            this._textBoxAddElementName.Text = "Имя..";
            this._textBoxAddElementName.TextChanged += new System.EventHandler(this.TextBoxAddElementValue_TextChanged);
            // 
            // _buttonOpenEditForm
            // 
            this._buttonOpenEditForm.Location = new System.Drawing.Point(15, 339);
            this._buttonOpenEditForm.Name = "_buttonOpenEditForm";
            this._buttonOpenEditForm.Size = new System.Drawing.Size(92, 23);
            this._buttonOpenEditForm.TabIndex = 13;
            this._buttonOpenEditForm.Text = "Изменить";
            this._buttonOpenEditForm.UseVisualStyleBackColor = true;
            this._buttonOpenEditForm.Click += new System.EventHandler(this.ButtonOpenEditForm_Click);
            // 
            // _pictureBoxCircuit
            // 
            this._pictureBoxCircuit.Location = new System.Drawing.Point(0, 0);
            this._pictureBoxCircuit.Name = "_pictureBoxCircuit";
            this._pictureBoxCircuit.Size = new System.Drawing.Size(75, 50);
            this._pictureBoxCircuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._pictureBoxCircuit.TabIndex = 14;
            this._pictureBoxCircuit.TabStop = false;
            // 
            // _panelCircuit
            // 
            this._panelCircuit.AutoScroll = true;
            this._panelCircuit.Controls.Add(this._pictureBoxCircuit);
            this._panelCircuit.Location = new System.Drawing.Point(211, 12);
            this._panelCircuit.Name = "_panelCircuit";
            this._panelCircuit.Size = new System.Drawing.Size(433, 379);
            this._panelCircuit.TabIndex = 15;
            // 
            // _buttonDrawCircuit
            // 
            this._buttonDrawCircuit.Location = new System.Drawing.Point(15, 368);
            this._buttonDrawCircuit.Name = "_buttonDrawCircuit";
            this._buttonDrawCircuit.Size = new System.Drawing.Size(190, 23);
            this._buttonDrawCircuit.TabIndex = 16;
            this._buttonDrawCircuit.Text = "Построить цепь";
            this._buttonDrawCircuit.UseVisualStyleBackColor = true;
            this._buttonDrawCircuit.Click += new System.EventHandler(this.ButtonDrawCircuit_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 406);
            this.Controls.Add(this._buttonAddElement);
            this.Controls.Add(this._buttonDrawCircuit);
            this.Controls.Add(this._panelCircuit);
            this.Controls.Add(this._buttonOpenEditForm);
            this.Controls.Add(this._textBoxAddElementName);
            this.Controls.Add(this._buttonCalculateFormShow);
            this.Controls.Add(this._buttonRemoveElement);
            this.Controls.Add(this._textBoxAddElementValue);
            this.Controls.Add(this._comboBoxAddNodeType);
            this.Controls.Add(this._treeViewCircuit);
            this.Controls.Add(this._buttonClearCircuit);
            this.Controls.Add(this._labelSelectCircuit);
            this.Controls.Add(this._comboBoxSelectCircuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор импедансов.";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxCircuit)).EndInit();
            this._panelCircuit.ResumeLayout(false);
            this._panelCircuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxSelectCircuit;
        private System.Windows.Forms.Label _labelSelectCircuit;
        private System.Windows.Forms.Button _buttonClearCircuit;
        private System.Windows.Forms.TreeView _treeViewCircuit;
        private System.Windows.Forms.ComboBox _comboBoxAddNodeType;
        private System.Windows.Forms.TextBox _textBoxAddElementValue;
        private System.Windows.Forms.Button _buttonAddElement;
        private System.Windows.Forms.Button _buttonRemoveElement;
        private System.Windows.Forms.Button _buttonCalculateFormShow;
        private System.Windows.Forms.TextBox _textBoxAddElementName;
        private System.Windows.Forms.Button _buttonOpenEditForm;
        private System.Windows.Forms.PictureBox _pictureBoxCircuit;
        private System.Windows.Forms.Panel _panelCircuit;
        private System.Windows.Forms.Button _buttonDrawCircuit;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}

