using System.Collections.Generic;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Узел.
    /// </summary>
    public interface ICircuitNode
    {
        #region Properties

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        List<ICircuitNode> Nodes { get; }

        /// <summary>
        ///     Родитель.
        /// </summary>
        ICircuitNode Parent { get; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}