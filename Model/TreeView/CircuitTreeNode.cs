using System;
using System.Windows.Forms;
using Model.Circuits;
using Model.Elements;

namespace Model.TreeView
{
    /// <summary>
    ///     Узел TreeView содержащий INode.
    /// </summary>
    public class CircuitTreeNode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение.
        /// </summary>
        public ICircuitNode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="node">Нода.</param>
        public CircuitTreeNode(ICircuitNode node)
        {
            Value = node ?? throw new ArgumentNullException(nameof(node));

            Value = node;

            switch (node)
            {
                case SeriesSubcircuit series:
                    Text = $"[Послед] (Id:{series.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.Id})";
                    break;
                case Resistor resistor:
                    Text = $"[R] [{resistor.Value}] ({resistor.Name})";
                    break;
                case Capacitor capacitor:
                    Text = $"[C] [{capacitor.Value}] ({capacitor.Name})";
                    break;
                case Inductor inductor:
                    Text = $"[L] [{inductor.Value}] ({inductor.Name})";
                    break;
                default:
                    throw new InvalidOperationException(nameof(node));
            }
        }

        #endregion
    }
}