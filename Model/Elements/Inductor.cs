using System;
using System.Numerics;
using Model.Validators;

namespace Model.Elements
{
    /// <summary>
    ///     Катушка индуктивности.
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="inductance">Индуктивность.</param>
        public Inductor(string name, double inductance) : base(name, inductance)
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
            double valueZ = 2 * Math.PI * frequency * Value;
            return new Complex(0, valueZ);
        }

        /// <summary>
        ///     Возвращает символ элемента.
        /// </summary>
        /// <returns>Тип узла.</returns>
        public override string GetSymbol()
        {
            return "L";
        }

        #endregion
    }
}