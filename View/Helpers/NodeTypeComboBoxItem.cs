using System;
using Model.Enums;

namespace View.Helpers
{
    /// <summary>
    ///     Тип элемента в ComboBox'е.
    /// </summary>
    public sealed class NodeTypeComboBoxItem
    {
        #region Properties

        /// <summary>
        ///     Тип элемента.
        /// </summary>
        public NodeType Value { get; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description
        {
            get
            {
                switch (Value)
                {
                    case NodeType.Parallel:
                        return "Параллельное соединение";
                    case NodeType.Series:
                        return "Последовательное соединение";
                    case NodeType.Resistor:
                        return "Резистор";
                    case NodeType.Capacitor:
                        return "Конденсатор";
                    case NodeType.Inductor:
                        return "Катушка";
                    default:
                        throw new ArgumentException();
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="value">Тип элемента.</param>
        public NodeTypeComboBoxItem(NodeType value)
        {
            Value = value;
        }

        #endregion
    }
}