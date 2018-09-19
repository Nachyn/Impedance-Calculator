using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;
using Model.Events;

namespace Model.Circuits
{
    /// <summary>
    ///     Подцепь.
    /// </summary>
    public abstract class SubcircuitBase : ICircuitNode
    {
        #region Static fields

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        private static int _id;

        #endregion

        #region Private fields

        /// <summary>
        ///     Родитель
        /// </summary>
        private ICircuitNode _parent;

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        /// <summary>
        ///     Родитель.
        /// </summary>
        public ICircuitNode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                ParentChanged?.Invoke(this,
                    new SubcircuitParentEventArgs("Родитель изменен", value));
            }
        }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<ICircuitNode> Nodes { get; } = new List<ICircuitNode>();

        #endregion

        #region Events

        /// <summary>
        ///     Событие на изменение родителя.
        /// </summary>
        public event EventHandler<SubcircuitParentEventArgs> ParentChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        protected SubcircuitBase()
        {
            _id++;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}