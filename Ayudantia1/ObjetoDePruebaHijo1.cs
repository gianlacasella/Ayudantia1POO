using System;
using System.Collections.Generic;
using System.Text;

namespace Ayudantia1
{
    public class ObjetoDePruebaHijo1 : ObjetoDePrueba
    {

        /*
        Esta clase hereda los atributos del padre, junto con los getters y setters. Pero ademas, 
        podemos definir atributos propios, como por ejemplo un bool
        */
        private bool d;
        public bool D { get => this.d; set => this.d = value; }


        /*
        Como heredamos de objeto de prueba, debemos llamar al constructor del padre cuando creamos
        una instancia de esta clase. Por alguna razon, podriamos querer que el atributo 'a' se pase
        como parametro del constructor del hijo, y el resto se fija en 0 
        */
        public ObjetoDePruebaHijo1(int a, bool d) : base(a,0,0) 
        {
            Console.WriteLine($"{this.A}, {this.B}, {this.C}");
            this.D = d;
        }

    }
}
