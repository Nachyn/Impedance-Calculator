using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Model.Circuits;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Рисовальщик цепи.
    /// </summary>
    public class Drawer
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Высота нижней части конденсатора.
        /// </summary>
        private readonly int _bottomHeightCapacitor = 35;

        /// <summary>
        ///     Позиция конденсатора от линии.
        /// </summary>
        private readonly int _CapacitorPositionY = 15;

        /// <summary>
        ///     Сжатие элементов по X.
        /// </summary>
        private readonly int _compressionElementX = 30;

        /// <summary>
        ///     Сжатие элементов по Y.
        /// </summary>
        private readonly int _compressionElementY = 20;


        /// <summary>
        ///     Позиция элемента по Y от линии.
        /// </summary>
        private readonly int _elementPositionY = 25;

        /// <summary>
        ///     Часть круга катушки в градусах.
        /// </summary>
        private readonly int _inductorPartСircleDegrees = 180;

        /// <summary>
        ///     Отступ после элемента.
        /// </summary>
        private readonly int _lineSpacingAfterElement = 50;

        /// <summary>
        ///     Ширина элемента.
        /// </summary>
        private readonly int _lineSpacingElementWidth = 40;

        /// <summary>
        ///     Радиус катушки.
        /// </summary>
        private readonly int _radiusInductor = 10;

        #endregion

        #region Private fields

        /// <summary>
        ///     Формат текста.
        /// </summary>
        private Font _font = new Font(new FontFamily("Calibri"), 10, FontStyle.Regular);

        /// <summary>
        ///     Ручка.
        /// </summary>
        private Pen _pen = new Pen(Color.Black);

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Отступ.
        /// </summary>
        private Point Displacement { get; } = new Point(0, 0);


        /// <summary>
        ///     Формат текста.
        /// </summary>
        public Font Font
        {
            get => _font;
            set => _font = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///     Ручка.
        /// </summary>
        public Pen Pen
        {
            get => _pen;
            set => _pen = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Рисовать схему электрической цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <returns>Положение поддерева.</returns>
        private Point DrawCircuit(ICircuitNode root, Point displacement, Graphics graphics)
        {
            if (root is ElementBase element)
            {
                DrawElement(graphics, Pen, element, displacement);
                return new Point(1, 1);
            }

            int maxCount = 0;
            List<int> steps = new List<int>();

            if (root is ParallelSubcircuit)
            {
                graphics.DrawLine(Pen, new Point(displacement.X, _elementPositionY + displacement.Y),
                    new Point(_elementPositionY + displacement.X, _elementPositionY + displacement.Y));

                for (int i = 0; i < root.Nodes.Count; i++)
                {
                    Point count = DrawCircuit(root.Nodes[i],
                        new Point(_elementPositionY + displacement.X,
                            steps.Sum() * _lineSpacingElementWidth + displacement.Y), graphics);

                    steps.Add(count.Y);

                    if (maxCount < count.X)
                    {
                        int step = 0;
                        for (int j = 0; j < i; j++)
                        {
                            graphics.DrawLine(Pen,
                                new Point(_elementPositionY + maxCount * _lineSpacingAfterElement + displacement.X,
                                    _elementPositionY + step * _lineSpacingElementWidth + displacement.Y),
                                new Point(_elementPositionY + count.X * _lineSpacingAfterElement + displacement.X,
                                    _elementPositionY + step * _lineSpacingElementWidth + displacement.Y));

                            step += steps[j];
                        }

                        maxCount = count.X;
                    }
                    else
                    {
                        int step = 0;
                        for (int j = 0; j < i; j++)
                        {
                            step += steps[j];
                        }

                        graphics.DrawLine(Pen,
                            new Point(_elementPositionY + count.X * _lineSpacingAfterElement + displacement.X,
                                _elementPositionY + step * _lineSpacingElementWidth + displacement.Y),
                            new Point(_elementPositionY + maxCount * _lineSpacingAfterElement + displacement.X,
                                _elementPositionY + step * _lineSpacingElementWidth + displacement.Y));
                    }
                }

                graphics.DrawLine(Pen,
                    new Point(_elementPositionY + maxCount * _lineSpacingAfterElement + displacement.X,
                        _elementPositionY + displacement.Y),
                    new Point(_lineSpacingAfterElement + maxCount * _lineSpacingAfterElement + displacement.X,
                        _elementPositionY + displacement.Y));


                graphics.DrawLine(Pen,
                    new Point(_elementPositionY + displacement.X, _elementPositionY + displacement.Y),
                    new Point(_elementPositionY + displacement.X,
                        _elementPositionY + (steps.Sum() - steps[steps.Count - 1]) * _lineSpacingElementWidth +
                        displacement.Y));

                graphics.DrawLine(Pen,
                    new Point(_elementPositionY + maxCount * _lineSpacingAfterElement + displacement.X,
                        _elementPositionY + displacement.Y),
                    new Point(_elementPositionY + maxCount * _lineSpacingAfterElement + displacement.X,
                        _elementPositionY + (steps.Sum() - steps[steps.Count - 1]) * _lineSpacingElementWidth +
                        displacement.Y));

                return new Point(maxCount + 1, steps.Sum());
            }

            foreach (ICircuitNode child in root.Nodes)
            {
                Point count = DrawCircuit(child,
                    new Point(steps.Sum() * _lineSpacingAfterElement + displacement.X, displacement.Y), graphics);

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }


        /// <summary>
        ///     Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <param name="pen">Ручка.</param>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private void DrawElement(Graphics graphics, Pen pen, ElementBase element,
            Point displacement)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            switch (element)
            {
                case Resistor _:
                    graphics.DrawLine(pen,
                        new Point(_radiusInductor + displacement.X, _compressionElementY + displacement.Y),
                        new Point(_radiusInductor + displacement.X, _compressionElementX + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_radiusInductor + displacement.X, _compressionElementX + displacement.Y),
                        new Point(_lineSpacingElementWidth + displacement.X, _compressionElementX + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_lineSpacingElementWidth + displacement.X, _compressionElementY + displacement.Y),
                        new Point(_lineSpacingElementWidth + displacement.X, _compressionElementX + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_lineSpacingElementWidth + displacement.X, _compressionElementY + displacement.Y),
                        new Point(_radiusInductor + displacement.X, _compressionElementY + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_radiusInductor + displacement.X, _elementPositionY + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_lineSpacingElementWidth + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_lineSpacingAfterElement + displacement.X, _elementPositionY + displacement.Y));

                    break;
                case Capacitor _:
                    graphics.DrawLine(pen,
                        new Point(_compressionElementY + displacement.X, _CapacitorPositionY + displacement.Y),
                        new Point(_compressionElementY + displacement.X, _bottomHeightCapacitor + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_compressionElementX + displacement.X, _CapacitorPositionY + displacement.Y),
                        new Point(_compressionElementX + displacement.X, _bottomHeightCapacitor + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_compressionElementY + displacement.X, _elementPositionY + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_compressionElementX + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_lineSpacingAfterElement + displacement.X, _elementPositionY + displacement.Y));


                    break;
                case Inductor _:
                    graphics.DrawArc(pen, _radiusInductor + displacement.X, _compressionElementY + displacement.Y,
                        _radiusInductor, _radiusInductor, _inductorPartСircleDegrees, _inductorPartСircleDegrees);

                    graphics.DrawArc(pen, _compressionElementY + displacement.X, _compressionElementY + displacement.Y,
                        _radiusInductor, _radiusInductor, _inductorPartСircleDegrees, _inductorPartСircleDegrees);

                    graphics.DrawArc(pen, _compressionElementX + displacement.X, _compressionElementY + displacement.Y,
                        _radiusInductor, _radiusInductor, _inductorPartСircleDegrees, _inductorPartСircleDegrees);

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_radiusInductor + displacement.X, _elementPositionY + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(_lineSpacingElementWidth + displacement.X, _elementPositionY + displacement.Y),
                        new Point(_lineSpacingAfterElement + displacement.X, _elementPositionY + displacement.Y));

                    break;
            }

            graphics.DrawString(element.Name, Font, brush, _CapacitorPositionY + displacement.X,
                _lineSpacingElementWidth + displacement.Y);
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Нарисовать цепь.
        /// </summary>
        public Bitmap DrawCircuit(Circuit circuit)
        {
            if (circuit is null)
            {
                throw new ArgumentNullException(nameof(circuit));
            }
            Bitmap bitmap = new Bitmap(1000, 1000);
            DrawCircuit(circuit.Root, Displacement, Graphics.FromImage(bitmap));
            return bitmap;
        }

        #endregion
    }
}