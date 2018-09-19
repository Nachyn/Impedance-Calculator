using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model.Circuits;
using Model.Elements;
using Model.Elements.Factories;
using Model.Enums;
using Model.TreeView;
using Model.Validators;
using View.Helpers;
using View.Helpers.Enums;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Рисовальщик цепи.
        /// </summary>
        private readonly Drawer _drawer;

        #endregion

        #region Private fields

        private ICircuitNode _currentNode;

        /// <summary>
        ///     Номинал нового элемента
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Private methods

        /// <summary>
        ///     Инициализировать ComboBox'ы
        /// </summary>
        private void InitializeComboBoxesType()
        {
            List<InitialTemplateCircuitTypeComboBoxItem> initialCircuitTypes =
                new List<InitialTemplateCircuitTypeComboBoxItem>
                {
                    new InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType.A),
                    new InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType.B),
                    new InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType.C),
                    new InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType.D),
                    new InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType.E)
                };

            _comboBoxSelectCircuit.DataSource = initialCircuitTypes;
            _comboBoxSelectCircuit.ValueMember = "Value";
            _comboBoxSelectCircuit.DisplayMember = "Description";

            List<NodeTypeComboBoxItem> connectionTypes = new List<NodeTypeComboBoxItem>
            {
                new NodeTypeComboBoxItem(NodeType.Resistor),
                new NodeTypeComboBoxItem(NodeType.Capacitor),
                new NodeTypeComboBoxItem(NodeType.Inductor),
                new NodeTypeComboBoxItem(NodeType.Series),
                new NodeTypeComboBoxItem(NodeType.Parallel)
            };

            _comboBoxAddNodeType.DataSource = connectionTypes;
            _comboBoxAddNodeType.ValueMember = "Value";
            _comboBoxAddNodeType.DisplayMember = "Description";
        }

        /// <summary>
        ///     Инициализировать подсказки
        /// </summary>
        private void InitializePlaceholders()
        {
            _textBoxAddElementName.GotFocus += (sender, e) =>
            {
                ((TextBox) sender).Text = string.Empty;
                ((TextBox) sender).ForeColor = Color.Black;
            };

            _textBoxAddElementName.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(((TextBox) sender).Text))
                {
                    ((TextBox) sender).Text = "Имя..";
                    ((TextBox) sender).ForeColor = Color.Gray;
                }
            };

            _textBoxAddElementValue.GotFocus += (sender, e) =>
            {
                ((TextBox) sender).Text = string.Empty;
                ((TextBox) sender).ForeColor = Color.Black;
            };

            _textBoxAddElementValue.LostFocus += (sender, e) =>
            {
                if (!double.TryParse(((TextBox) sender).Text, out _value))
                {
                    ((TextBox) sender).Text = "Номинал..";
                    ((TextBox) sender).ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        ///     Очистить TreeViewCircuit
        /// </summary>
        private void ClearTreeViewCircuit()
        {
            _treeViewCircuit.Nodes.Clear();
            _currentNode = null;
        }

        /// <summary>
        ///     Обновить дерево
        /// </summary>
        private void UpdateTreeView()
        {
            ClearTreeViewCircuit();
            if (_circuit == null || _circuit.IsEmpty())
            {
                return;
            }

            _treeViewCircuit.BeginUpdate();

            void AddNodeTreeNodes(ICircuitNode node, TreeNode treeNode)
            {
                if (node is ElementBase)
                {
                    return;
                }

                foreach (ICircuitNode children in node.Nodes)
                {
                    CircuitTreeNode newTreeNode = new CircuitTreeNode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            _treeViewCircuit.Nodes.Clear();

            CircuitTreeNode root = new CircuitTreeNode(_circuit.Root);
            _treeViewCircuit.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            _treeViewCircuit.EndUpdate();
            _treeViewCircuit.ExpandAll();
        }

        private void ButtonClearCircuit_Click(object sender, EventArgs e)
        {
            _circuit.Clear();
            UpdateTreeView();
            DrawCircuit();
        }

        private void ComboBoxSelectCircuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_comboBoxSelectCircuit.SelectedItem is InitialTemplateCircuitTypeComboBoxItem initialCircuitType)
            {
                InitialTemplateCircuitInitializer.Initialize(_circuit, initialCircuitType.Value);
                UpdateTreeView();
                DrawCircuit();
                _buttonDrawCircuit.Visible = false;
                _buttonCalculateFormShow.Visible = true;
            }
        }

        private void ButtonAddElement_Click(object sender, EventArgs e)
        {
            if (_comboBoxAddNodeType.SelectedItem is NodeTypeComboBoxItem type)
            {
                try
                {
                    switch (type.Value)
                    {
                        case NodeType.Series:
                            _circuit.AddAfter(_currentNode, new SeriesSubcircuit());
                            break;
                        case NodeType.Parallel:
                            _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
                            break;
                        default:
                            _circuit.AddAfter(_currentNode,
                                ElementFactory.GetInstance(type.Value, _textBoxAddElementName.Text, _value));

                            break;
                    }

                    ClearCircuit();
                    UpdateTreeView();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void TextBoxAddElementValue_TextChanged(object sender, EventArgs e)
        {
            _errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(_textBoxAddElementName.Text))
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementName, "Имя не может быть пустым.");
                return;
            }

            if (_textBoxAddElementName.Text.Contains(" "))
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementName, "Имя не может содержать пробелы.");
                return;
            }

            if (_textBoxAddElementName.Text.Length > 5)
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementName, "Имя не может содержать более 5 символов.");
                return;
            }

            if (_textBoxAddElementValue.Text.Contains(" "))
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementName, "Значение не может содержать пробелы.");
                return;
            }

            if (!double.TryParse(_textBoxAddElementValue.Text, out _value))
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementValue, "Значение не является числом.");
                return;
            }

            if (_value < Check.MIN_FREQUENCY || _value > Check.MAX_FREQUENCY)
            {
                _buttonAddElement.Enabled = false;
                _errorProvider.SetError(_textBoxAddElementValue,
                    "Частота может принимать значение только от 1 Гц. до 1 ТГц..");

                return;
            }

            _errorProvider.Clear();
            _buttonAddElement.Enabled = true;
        }

        private void TreeViewCircuit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is CircuitTreeNode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        private void ButtonOpenEditForm_Click(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    DialogResult result = new EditForm(element).ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        UpdateTreeView();
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный вами узел не является элементом.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент, который хотите изменить.");
            }
        }


        /// <summary>
        ///     Корректна ли цепь.
        /// </summary>
        /// <returns>Корректна ли цепь.</returns>
        private bool IsCircuitCorrect()
        {
            try
            {
                _circuit.CalculateZ(new double[] {1});
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }


        private void ButtonCalculateFormShow_Click(object sender, EventArgs e)
        {
            if (IsCircuitCorrect())
            {
                new ImpedanceForm(_circuit).ShowDialog();
            }
            else
            {
                _buttonCalculateFormShow.Visible = false;
                _buttonDrawCircuit.Visible = true;
            }
        }

        private void ButtonRemoveElement_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
            {
                MessageBox.Show("Выберите элемент, который хотите удалить.");
            }
            else
            {
                try
                {
                    _circuit.Remove(_currentNode);
                    UpdateTreeView();
                    ClearCircuit();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        ///     Очистить цепь.
        /// </summary>
        private void ClearCircuit()
        {
            _pictureBoxCircuit.Image = null;
            _buttonCalculateFormShow.Visible = false;
            _buttonDrawCircuit.Visible = true;
        }

        /// <summary>
        ///     Нарисовать цепь.
        /// </summary>
        private void DrawCircuit()
        {
            ClearCircuit();
            if (_circuit == null || _circuit.IsEmpty())
            {
                return;
            }

            _pictureBoxCircuit.Image = _drawer.DrawCircuit(_circuit);
        }

        private void ButtonDrawCircuit_Click(object sender, EventArgs e)
        {
            if (IsCircuitCorrect())
            {
                DrawCircuit();

                _buttonCalculateFormShow.Visible = true;
                _buttonDrawCircuit.Visible = false;
            }
            else
            {
                _buttonCalculateFormShow.Visible = false;
                _buttonDrawCircuit.Visible = true;
            }
        }

        private void ComboBoxAddNodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableAddElementControls(false);

            if (_comboBoxAddNodeType.SelectedItem is NodeTypeComboBoxItem item)
            {
                switch (item.Value)
                {
                    case NodeType.Resistor:
                        EnableAddElementControls(true);
                        break;
                    case NodeType.Capacitor:
                        EnableAddElementControls(true);
                        break;
                    case NodeType.Inductor:
                        EnableAddElementControls(true);
                        break;
                }
            }
        }

        /// <summary>
        ///     Включить контролы для добавления.
        /// </summary>
        /// <param name="isEnable">Включить?</param>
        private void EnableAddElementControls(bool isEnable)
        {
            _errorProvider.Clear();
            _textBoxAddElementName.Enabled = isEnable;
            _textBoxAddElementValue.Enabled = isEnable;
            _buttonAddElement.Enabled = !isEnable;
            _textBoxAddElementName.Text = "Имя..";
            _textBoxAddElementValue.Text = "Номинал..";
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeComboBoxesType();
            InitializePlaceholders();
            _circuit = new Circuit();
            _drawer = new Drawer();
            _buttonAddElement.Enabled = false;
        }

        #endregion
    }
}