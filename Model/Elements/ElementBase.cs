using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Events;
using Model.Validators;

namespace Model.Elements
{
    /// <summary>
    ///     Базовый элемент эл. элементов.
    /// </summary>
    public abstract class ElementBase : ICircuitNode
    {
        #region Properties

        /// <summary>
        ///     Имя элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),
                        "Имя не может быть пустым.");
                }

                if (value.Contains(" "))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),
                        "Имя не может содержать пробелы.");
                }

                if (value.Length > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),
                        "Имя не может содержать более 5 символов.");
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Номинал.
        /// </summary>
        public double Value
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                Check.CheckFrequencies(value);
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueEventArgs
                    (Name, _value));
            }
            get => _value;
        }

        /// <summary>
        ///     Родитель.
        /// </summary>
        public ICircuitNode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<ICircuitNode> Nodes { get; } = new List<ICircuitNode>();

        #endregion

        #region Events

        /// <summary>
        ///     Событие на изменение номинала.
        /// </summary>
        public event EventHandler<ElementValueEventArgs> ValueChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="value">Номинал.</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Возвращает символ элемента.
        /// </summary>
        /// <returns>Тип узла.</returns>
        public abstract string GetSymbol();

        /// <summary>
        ///     Расчитать комплексное сопротивление.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Fields

        #region Private fields

        /// <summary>
        ///     Имя.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал.
        /// </summary>
        private double _value;

        #endregion

        #endregion
    }
}