using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gempire.Components
{
    public class Building
    {
        // the building's type and whether or not it has a constant value
        public string Name { get; set; }
        public Attribute Type { get; set; }
        public int BaseValue { get; set; }

        // take into account value dependency on other buildings, attributes, palace level, or technology count
        public VariableType VariableType { get; set; }
        public int VariableCount { get; set; }
        public int VariableConstant { get; set; }

        // finds the total value of the building
        public int TotalValue
        {
            get
            {
                return BaseValue + VariableConstant * VariableCount;
            }
        }

        // what direction adds to VariableCount 
        public Direction Direction { get; set; }

        // does the building count as just one or multiple buildings?
        public int BuildingCount { get; set; }
        public int PalaceDiamonds { get; set; }
        public int ScienceSymbols { get; set; }

        // How many of this building are in the deck?
        public int Multiplicity { get; set; }

        // Need properties to enable the following buildings:
        // buildings that purely give science
        // buildings with adjacency bonuses
        // buildings with second row bonuses
    }
}
