using System;
using System.Collections.Generic;
using System.Text;

namespace Ayudantia1
{
    public class ObjetoDePruebaHijo2 : ObjetoDePrueba
    {

        /*
        Esta clase hereda los atributos del padre, junto con los getters y setters. Pero ademas, 
        podemos definir atributos propios, como por ejemplo un bool
        */
        private bool e;

        /*
        Como heredamos de objeto de prueba, debemos llamar al constructor del padre cuando creamos
        una instancia de esta clase. Por alguna razon, podriamos querer que el atributo 'a' se pase
        como parametro del constructor del hijo, y el resto se fija en 0 
        */
        public ObjetoDePruebaHijo2(int a, bool e) : base(a, 0, 0)
        {
            Console.WriteLine($"{this.A}, {this.B}, {this.C}");
            this.e = e;
        }
    }
}
