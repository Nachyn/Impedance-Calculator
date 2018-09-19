using System.Numerics;
using Model.Validators;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор.
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="resistance">Сопротивление.</param>
        public Resistor(string name, double resistance) : base(name, resistance)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента.
        /// </summary>
        /// <param name="frequency">Частоста.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Check.CheckFrequencies(frequency);

            return new Complex(Value, 0);
        }

        /// <summary>
        ///     Возвращает символ элемента.
        /// </summary>
        /// <returns>Тип узла.</returns>
        public override string GetSymbol()
        {
            return "R";
        }

        #endregion
    }
}