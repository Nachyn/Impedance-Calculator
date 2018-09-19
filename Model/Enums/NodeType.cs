namespace Model.Enums
{
    /// <summary>
    ///     Тип соединения.
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        ///     Последовательное соединение.
        /// </summary>
        Series,

        /// <summary>
        ///     Параллельное соединение.
        /// </summary>
        Parallel,

        /// <summary>
        ///     Резистор
        /// </summary>
        Resistor,

        /// <summary>
        ///     Конденсатор
        /// </summary>
        Capacitor,

        /// <summary>
        ///     Катушка
        /// </summary>
        Inductor
    }
}