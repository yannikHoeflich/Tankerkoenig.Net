using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net.Data;
[Flags]
public enum GasType {
    Diesel = 1 << 0,
    E5 = 1 << 1,
    E10 = 1 << 2,

    All = Diesel | E5 | E10,
}
