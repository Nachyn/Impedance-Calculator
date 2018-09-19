using System;
using System.Numerics;
using Model.Elements;
using Model.Validators;

namespace Model.Circuits
{
    /// <summary>
    ///     Последовательная подцепь.
    /// </summary>
    public class SeriesSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 1)
            {
                throw new InvalidOperationException(
                    $"В последовательном соединении (Id: {Id}) нет узлов.");
            }

            Check.CheckFrequencies(frequency);

            Complex resistance = Complex.Zero;

            foreach (ICircuitNode node in Nodes)
            {
                resistance += node.CalculateZ(frequency);
            }

            return resistance;
        }

        #endregion
    }
}