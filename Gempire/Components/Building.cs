using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gempire.Components
{
    public class Building
    {
        public string Name { get; set; }
        public Attribute Type { get; set; }
        public int BaseValue { get; set; }
        public VariableType VariableType { get; set; }
        public int VariableCount { get; set; }
        public int VariableConstant { get; set; }
        public int TotalValue
        {
            get
            {
                return BaseValue + VariableConstant * VariableCount;
            }
        }
        public Direction Direction { get; set; }
        public int BuildingCount { get; set; }
        public int PalaceDiamonds { get; set; }
        public int ScienceSymbols { get; set; }
        public int ScienceVariableValue { get; set; }


    }

    public enum Attribute
    {
        Gold,
        Population,
        Culture
    }

    public enum Direction
    {
        Left,
        Right
    }

    public enum VariableType
    {
        Building,
        PalaceLevel,
        GoldGem,
        PopulationGem,
        CultureGem
    }
}
