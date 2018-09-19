using Model.Circuits;
using Model.Elements;
using View.Helpers.Enums;

namespace View.Helpers
{
    /// <summary>
    ///     Инициализирует шаблон цепи с изначально заданными элементами.
    /// </summary>
    public static class InitialTemplateCircuitInitializer
    {
        #region Public methods

        /// <summary>
        ///     Инициализировать цепь.
        /// </summary>
        /// <param name="circuit">Цепь.</param>
        /// <param name="initialTemplateCircuitType">Тип шаблона.</param>
        public static void Initialize(Circuit circuit, InitialTemplateCircuitType initialTemplateCircuitType)
        {
            if (circuit == null)
            {
                circuit = new Circuit();
            }

            circuit.Clear();

            switch (initialTemplateCircuitType)
            {
                case InitialTemplateCircuitType.A:
                {
                    Inductor inductor1 = new Inductor("L1", 20);
                    Resistor resistor2 = new Resistor("R2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    seriesSubcircuit1.Nodes.Add(inductor1);
                    inductor1.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(resistor2);
                    resistor2.Parent = seriesSubcircuit1;

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = seriesSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(resistor3);
                    resistor3.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;

                    circuit.AddAfter(null, seriesSubcircuit1);
                    break;
                }

                case InitialTemplateCircuitType.B:
                {
                    Capacitor capacitor1 = new Capacitor("C1", 20);
                    Inductor inductor2 = new Inductor("L2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    parallelSubcircuit1.Nodes.Add(capacitor1);
                    capacitor1.Parent = parallelSubcircuit1;

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit1);
                    seriesSubcircuit1.Parent = parallelSubcircuit1;

                    seriesSubcircuit1.Nodes.Add(inductor2);
                    inductor2.Parent = seriesSubcircuit1;

                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    parallelSubcircuit2.Nodes.Add(resistor3);
                    resistor3.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit2;

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    circuit.AddAfter(null, parallelSubcircuit1);

                    break;
                }


                case InitialTemplateCircuitType.C:
                {
                    Resistor resistor1 = new Resistor("R1", 20);
                    Inductor inductor2 = new Inductor("L2", 20);
                    Inductor inductor3 = new Inductor("L3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Resistor resistor6 = new Resistor("R6", 20);
                    Inductor inductor7 = new Inductor("L7", 20);

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    SeriesSubcircuit seriesSubcircuit2 = new SeriesSubcircuit();

                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit1);
                    seriesSubcircuit1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit2);
                    seriesSubcircuit2.Parent = parallelSubcircuit1;

                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit3 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(inductor3);
                    inductor3.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit2;

                    seriesSubcircuit2.Nodes.Add(inductor2);
                    inductor2.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(resistor5);
                    resistor5.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = seriesSubcircuit2;
                    parallelSubcircuit3.Nodes.Add(resistor6);
                    resistor6.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor7);
                    inductor7.Parent = parallelSubcircuit3;
                    circuit.AddAfter(null, parallelSubcircuit1);
                    break;
                }


                case InitialTemplateCircuitType.D:
                {
                    Resistor resistor1 = new Resistor("R1", 1);
                    Capacitor capacitor2 = new Capacitor("C2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Inductor inductor6 = new Inductor("L6", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(resistor3);
                    resistor3.Parent = seriesSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    capacitor2.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(resistor5);
                    resistor5.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    inductor6.Parent = parallelSubcircuit2;
                    circuit.AddAfter(null, seriesSubcircuit1);

                    break;
                }


                case InitialTemplateCircuitType.E:
                {
                    Resistor resistor1 = new Resistor("R1", 20);
                    Capacitor capacitor2 = new Capacitor("C2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Inductor inductor6 = new Inductor("L6", 20);
                    Resistor resistor7 = new Resistor("R7", 20);
                    Inductor inductor8 = new Inductor("L8", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    SeriesSubcircuit seriesSubcircuit2 = new SeriesSubcircuit();
                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit3 = new ParallelSubcircuit();
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = seriesSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    capacitor2.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(seriesSubcircuit2);
                    seriesSubcircuit2.Parent = parallelSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(resistor7);
                    resistor7.Parent = seriesSubcircuit2;
                    parallelSubcircuit3.Nodes.Add(resistor5);
                    resistor5.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor8);
                    inductor8.Parent = parallelSubcircuit3;
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    inductor6.Parent = parallelSubcircuit2;
                    seriesSubcircuit1.Nodes.Add(resistor3);
                    resistor3.Parent = seriesSubcircuit1;

                    circuit.AddAfter(null, seriesSubcircuit1);
                    break;
                }
            }
        }

        #endregion
    }
}