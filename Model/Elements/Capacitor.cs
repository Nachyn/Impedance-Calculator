using System;
using System.Numerics;
using Model.Validators;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор.
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="capacity">Емкость.</param>
        public Capacitor(string name, double capacity) : base(name, capacity)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента.
        /// </summary>
        /// <param name="frequency">Частоста.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Check.CheckFrequencies(frequency);
            double valueZ = 1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }

        /// <summary>
        ///     Возвращает символ элемента.
        /// </summary>
        /// <returns>Тип узла.</returns>
        public override string GetSymbol() => "C";

        #endregion
    }
}