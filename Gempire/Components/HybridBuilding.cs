using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gempire.Components
{
    public class HybridBuilding : Building
    {
        public Attribute SecondType { get; set; }
        public int SecondBaseValue { get; set; }
        public VariableType SecondVariableType { get; set; }
        public int SecondVariableConstant { get; set; }
        public int SecondVariableCount { get; set; }
        public int SecondTotalValue
        {
            get
            {
                return SecondBaseValue + SecondVariableConstant * SecondVariableCount;
            }
        }
        public Direction SecondDirection { get; set; }
        public int SecondBuildingCount { get; set; }
    }
}
