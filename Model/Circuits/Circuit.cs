using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Elements;
using Model.Validators;

namespace Model.Circuits
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Properties

        /// <summary>
        ///     Корень.
        /// </summary>
        public ICircuitNode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Пустая ли цепь.
        /// </summary>
        /// <returns>Пустая ли цепь.</returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        /// <summary>
        ///     Очистить цепь.
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        ///     Рассчитать импедансы.
        /// </summary>
        /// <param name="frequencies">Частоты.</param>
        /// <returns>Импедансы.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            Check.CheckFrequencies(frequencies);

            if (Root == null)
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            return frequencies.Select(frequency => Root.CalculateZ(frequency)).ToList();
        }

        /// <summary>
        ///     Удалить узел.
        /// </summary>
        /// <param name="node">Узел.</param>
        /// <returns>Удален ли узел.</returns>
        public void Remove(ICircuitNode node)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Цепь пуста. Удалять нечего.");
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node),
                    "Узел не может быть null, потому что в цепи есть узлы.");
            }

            if (node == Root)
            {
                Root = null;
                return;
            }

            node.Parent.Nodes.Remove(node);
        }

        /// <summary>
        ///     Добавить новый узел в дети узла.
        /// </summary>
        /// <param name="node">Узел в который добавляют детей.</param>
        /// <param name="newNode">Новый узел.</param>
        public void AddAfter(ICircuitNode node, ICircuitNode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode),
                    "Новый узел не может быть не определен.");
            }

            if (node == newNode)
            {
                throw new ArgumentOutOfRangeException("Узел был равен новому узлу.");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (!IsEmpty() && node == null)
            {
                throw new ArgumentNullException(nameof(newNode),
                    "Выберите узел относительно которого будет происходить добавление. Для добавления нового корня сделайте очистку цепи или удалите корень.");
            }

            if (node is ElementBase)
            {
                throw new ArgumentException("Узел не может быть элементом.");
            }

            if (node is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes == null)
                {
                    throw new InvalidOperationException("Дети узла были null");
                }

                subcircuit.Nodes.Add(newNode);

                if (newNode is SubcircuitBase newSubcircuit)
                {
                    newSubcircuit.Parent = subcircuit;
                    ;
                }

                if (newNode is ElementBase newElementBase)
                {
                    newElementBase.Parent = subcircuit;
                }
            }
        }

        #endregion
    }
}