using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcessoElevador
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DescricaoWS : Attribute
    {
        public string _Descricao;
        public Type _Type;
        public bool _Lista;

        public DescricaoWS(string sDescricao, Type oType, bool bLista = false)
        {
            this._Descricao = sDescricao;
            this._Type = oType;
            this._Lista = bLista;
        }
    }
}
