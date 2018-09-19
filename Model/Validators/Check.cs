using System;

namespace Model.Validators
{
    /// <summary>
    ///     Проверки.
    /// </summary>
    public class Check
    {
        #region Constants

        /// <summary>
        ///     Максимально допустимая частота.
        /// </summary>
        public const double MAX_FREQUENCY = 1000000000000;

        /// <summary>
        ///     Минимально допустимая частота.
        /// </summary>
        public const double MIN_FREQUENCY = 1;

        #endregion

        #region Public methods

        /// <summary>
        ///     Проверить частоты на значения, которые они могут принимать.
        /// </summary>
        /// <param name="frequncies">Частоты.</param>
        /// <exception cref="ArgumentException">Выбрасывает если частоты вне диапазона от 1 Гц. до 1Тгц.</exception>
        public static void CheckFrequencies(params double[] frequncies)
        {
            foreach (double frequency in frequncies)
            {
                if (frequency < MIN_FREQUENCY || frequency > MAX_FREQUENCY)
                {
                    throw new ArgumentException(
                        "Частота может принимать значение только от 1 Гц. до 1 ТГц..");
                }
            }
        }

        #endregion
    }
}