using System;
using System.Windows.Forms;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Форма редактирования элементов
    /// </summary>
    public partial class EditForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Элемент
        /// </summary>
        private readonly ElementBase _element;

        #endregion

        #region Private fields

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Private methods

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            _element.Value = _value;
            Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                _buttonEdit.Enabled = false;
                return;
            }

            if (_value <= 0 || _value > 1000000000000)
            {
                _buttonEdit.Enabled = false;
                return;
            }

            _buttonEdit.Enabled = true;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент</param>
        public EditForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            Text = "Элемент: " + element.Name;
            _textBoxValue.Text = element.Value.ToString();
        }

        #endregion
    }
}