using System;
using View.Helpers.Enums;

namespace View.Helpers
{
    /// <summary>
    ///     Тип шаблона цепи в ComboBox'е.
    /// </summary>
    public sealed class InitialTemplateCircuitTypeComboBoxItem
    {
        #region Properties

        /// <summary>
        ///     Тип шаблона.
        /// </summary>
        public InitialTemplateCircuitType Value { get; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description
        {
            get
            {
                switch (Value)
                {
                    case InitialTemplateCircuitType.A:
                        return "Шаблон A";
                    case InitialTemplateCircuitType.B:
                        return "Шаблон B";
                    case InitialTemplateCircuitType.C:
                        return "Шаблон C";
                    case InitialTemplateCircuitType.D:
                        return "Шаблон D";
                    case InitialTemplateCircuitType.E:
                        return "Шаблон E";
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
        /// <param name="value">Тип шаблона.</param>
        public InitialTemplateCircuitTypeComboBoxItem(InitialTemplateCircuitType value)
        {
            Value = value;
        }

        #endregion
    }
}