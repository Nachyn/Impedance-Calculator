using System;

namespace Model.Events
{
    /// <summary>
    ///     Класс для обработчика события ValueChanged.
    /// </summary>
    public class ElementValueEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        ///     Новое значение.
        /// </summary>
        public double Value
        {
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                _value = value;
            }
            get => _value;
        }

        /// <summary>
        ///     Сообщение.
        /// </summary>
        public string Message
        {
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Message));
                }

                _message = value;
            }
            get => _message;
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="value">Новое значение.</param>
        public ElementValueEventArgs(string message, double value)
        {
            Message = message;
            Value = value;
        }

        #endregion

        #region Fields

        #region Private fields

        /// <summary>
        ///     Сообщение.
        /// </summary>
        private string _message;

        /// <summary>
        ///     Новое значение.
        /// </summary>
        private double _value;

        #endregion

        #endregion
    }
}