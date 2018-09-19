using System;
using System.Numerics;
using Model.Elements;
using Model.Validators;

namespace Model.Circuits
{
    /// <summary>
    ///     Параллельная подцепь.
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Check.CheckFrequencies(frequency);
            if (Nodes.Count <= 1)
            {
                throw new InvalidOperationException(
                    $"В параллельном соединении (Id: {Id}) необходимо минимум 2 узла.");
            }

            Complex resistance = Complex.Zero;

            foreach (ICircuitNode node in Nodes)
            {
                resistance += 1 / node.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }
}