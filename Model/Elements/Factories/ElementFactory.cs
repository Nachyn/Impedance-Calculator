using System;
using Model.Enums;

namespace Model.Elements.Factories
{
    /// <summary>
    ///     Фаблика элементов
    /// </summary>
    public static class ElementFactory
    {
 
        /// <summary>
        ///     Получить элемент
        /// </summary>
        /// <param name="nodeType">Тип узла</param>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        /// <returns>Элемент</returns>
        public static ElementBase GetInstance(NodeType nodeType, string name,
            double value)
        {
            ElementBase newElement;
            switch (nodeType)
            {
                case NodeType.Resistor:
                    newElement = new Resistor(name, value);

                    break;
                case NodeType.Inductor:
                    newElement = new Inductor(name, value);

                    break;
                case NodeType.Capacitor:
                    newElement = new Capacitor(name, value);

                    break;
                default:
                    throw new ArgumentException("Некорректный тип узла.");
            }

            return newElement;
        }
        

    }
}