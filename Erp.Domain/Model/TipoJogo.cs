using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain
{
    [DataContract(Name = "TipoJogo")]
    public enum TipoJogo
    {
        [EnumMember]
        MegaSena,

        [EnumMember]
        LotoMania

    }
}
