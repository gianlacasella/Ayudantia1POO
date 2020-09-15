using System;
using System.Collections.Generic;
using System.Text;

namespace Ayudantia1
{
    public class ObjetoDePrueba : InterfazEjemplo
    {
        protected int a, b, c;

        public int A { get => this.a; set => this.a = value; }
        public int B { get => this.b; set => this.b = value; }
        public int C { get => this.c; set => this.c = value; }

        public ObjetoDePrueba(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        // Estamos obligados a implementar el metodo que nos impone la interfaz
        public void restar10()
        {
            this.a -= 10;
            this.b -= 10;
            this.c -= 10;
        }
    }
}
