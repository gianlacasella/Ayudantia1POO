using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ayudantia1
{
    public class ObjetoDePruebaNieto11 : ObjetoDePruebaHijo1
    {
        private bool f;

        public ObjetoDePruebaNieto11(int a, bool f) : base(a, false)
        {
            this.f = f;
        }
    }
}
