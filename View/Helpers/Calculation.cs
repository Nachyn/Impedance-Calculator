namespace View.Helpers
{
    /// <summary>
    ///     Расчеты для отображения.
    /// </summary>
    internal class Calculation
    {
        #region Properties

        /// <summary>
        ///     Отформатированный в строку импеданс для удобного отображения пользователю.
        /// </summary>
        public string Impedance { get; set; }

        /// <summary>
        ///     Отформатированная в строку частота для удобного отображения пользователю.
        /// </summary>
        public string Frequency { get; set; }

        #endregion
    }
}