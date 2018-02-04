using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain
{
    [DataContract(Name = "SituacaoJogo")]
    public enum SituacaoJogo
    {
        [EnumMember]
        Aposta,
        [EnumMember]
        Ganhou,
        [EnumMember]
        Perdeu
    }
}
