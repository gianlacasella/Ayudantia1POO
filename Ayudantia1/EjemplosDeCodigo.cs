using System;
using System.Collections.Generic;
using System.Text;

namespace Ayudantia1
{
    public class EjemplosDeCodigo
    {
        /* Cuando creamos una clase, normalmente se sigue la estructura:
         * 1. Atributos (primero los privados y luego los publicos, si es el caso)
         * 2. Getters+setters
         * 3. Constructores
         * 4. Metodos*/

        /*
        Atributos: es buena practica ponerlos todos privados, y agregar los setters y getters
        para acceder a ellos. Es posible que tenga un atributo que queremos que pueda ser obtenido
        (leido por otras clases) pero no seteado, por lo que agregariamos solo un getter pero no un setter.
        Por otro lado, podria darse el caso (menos comun) en el que queremos que un atributo pueda ser
        seteado por otras clases pero no leido, por lo que agregariamos solo el setter pero no el getter.
        Ademas, el agregar el getter y setter nos permite realizar un filtro (para evitar errores) antes de
        fijar o leer el valor del atributo... Si un atributo solo puede estar entre -1 y 1, el setter
        nos ayuda a filtrar valores equivocados fuera del rango, por ejemplo
        */
        private int numero1;
        private int numero2;
        private bool booleano1;

        /* Solo agregamos un atributo publico si no queremos cumplir ninguna de las condiciones anteriores*/
        public string palabra1;



        /* Getters y setters: No tiene sentido crear un get/set para un atributo publico porque
         puede ser accedido directamente sin el get/set. Para generar los getset de forma automatica,
        podemos usar visual studio: seleccionamos los atributos a encapsular y seleccionamos
        Encapsulate Fields (and use property). En el caso de numero2, solo nos interesa que pueda ser accedido
        pero no seteado. Normalmente se usan en public pero dependiendo de su uso puede variar*/

        // Suponiendo que queremos filtrar el set del atributo numero1
        public int Numero1 { get => this.numero1; set {
                if (value < 1 && value > -1)
                {
                    this.numero1 = value;
                }
            } 
        }

        // Suponiendo que solo queremos que tenga get
        public int Numero2 { get => this.numero2; }

        // Suponiendo que queremos que tenga get/set sin ningun filtro
        public bool Booleano1 { get => this.booleano1; set => this.booleano1 = value; }

        /* Constructores: son metodos especiales que son invocados cuando se crea UNA INSTANCIA de la clase.
         * Los constructores se diferencian por los parametros que reciben. Ademas, podemos sobrecargarlos
         * llamandolos entre si y asi tener diferentes constructores. Supongamos que solo queremos usar dos 
         constructores (depende del problema). Uno en el que recibamos todos los atributos
        (con uno por defecto, el booleano1 (si no se pasa como parametro se fija en false), y otro 
        en el que solo recibamos el numero1, dejando numero2 en 0, palabra1 en "Default" y el booleano
        en valor por defecto*/
        public EjemplosDeCodigo(int numero1, int numero2, string palabra1, bool booleano1=false)
        {
            this.Numero1 = numero1; // Cuando uso Numero1, implicitamente llamo al setter definido arriba (el this se puede obviar)
            this.numero2 = numero2; // Cuando uso this.numero2, modifico el atributo directamente sin llamar al setter
            this.palabra1 = palabra1; // El usar el this.atributo nos ayuda a diferenciar el parametro del atributo
            this.Booleano1 = booleano1; // Llamamos el setter

            // Podriamos querer ejecutar alguna rutina luego de setear los atributos
            mostrarAtributos();
        }

        public EjemplosDeCodigo(int numero1) : this(numero1, 0, "Default")
        { } // No necesitamos incluir codigo porque llamamos al constructor anterior pasandole los 3 valores obligatorios

        /* Metodos: si un metodo solo se usa dentro de la misma clase, debe ser private.
         * Si se usa en la misma clase y clases hijas, debe ser protected.
         * Si se usa fuera de la clase y sus hijas debe ser public*/

        // void-> "Nada". Usado para metodos que no retornan nada. En este caso, solo suma 10 al atributo numero1
        public void sumar10()
        {
            Numero1 += 10;
        }

        // Metodo privado porque solo es llamado desde adentro de la clase (constructor)
        private void mostrarAtributos()
        {
            Console.WriteLine($"numero1: {this.numero1}, numero2: {this.numero2}, booleano1: {this.booleano1}," +
                $" palabra1: {this.palabra1}");
        }

        // Metodo que hace un poco de todo
        public void mostrarEjemplos()
        {
            mostrarAtributos(); //  Ejecutamos el metodo privado
            List<int> lista_auxiliar; // DECLARAMOS una lista de int
            lista_auxiliar = new List<int>(); // INICIALIZAMOS una lista de int
            List<int> lista_auxiliar2 = new List<int>(); // DECLARAMOS e INICIALIZAMOS una lista de int
            List<int> lista_auxiliar3 = new List<int>() { 1,2,3 }; // DECLARAMOS, INICIALIZAMOS y AGREGAMOS VALORES

            // Equivalente a for numero in lista_auxiliar3 en Python
            foreach (int numero in lista_auxiliar3) 
            {
                // Mostramos el numero
                Console.WriteLine(numero);
            }

            // Equivalente a for numero in range(10) en Python
            for (int numero = 0; numero <= 9; numero++)
            {
                lista_auxiliar2.Add(numero); // Agregamos el numero a la lista_auxiliar2
                Console.WriteLine($"Numero agregado: {numero}. Longitud de la lista: {lista_auxiliar2.Count}");
            }

            // Creamos un nuevo diccionario cuyos keys son int y values son objetos de prueba
            Dictionary<int, ObjetoDePrueba> auxDict = new Dictionary<int, ObjetoDePrueba>();
            // Rellenamos el diccionario con objetos diferentes
            for (int numero = 0; numero <= 49; numero++)
            {
                ObjetoDePrueba objeto_prueba = new ObjetoDePrueba(numero+1, numero+2, numero+3); // Creamos una instancia del objeto
                auxDict.Add(numero, objeto_prueba);
                Console.WriteLine($"Numero agregado: {numero}. a: {objeto_prueba.A}, b: {objeto_prueba.B}, c:{objeto_prueba.C}");
            }

            // Podemos acceder a los values con auxDict.Values y a los keys con auxDict.Keys
            // Evidentemente, tambien podriamos crear una lista de objetos

            // Podemos usar polimorfismo para guardar en una sola lista elementos de clases diferentes
            // Por ejemplo, ObjetoDePruebaHijo1 y ObjetoDePruebaHijo2 heredan de ObjetoDePrueba
            List<ObjetoDePrueba> lista_objetosPrueba = new List<ObjetoDePrueba>();
            for (int i = 1; i <= 20; i++)
            {
                // Por polimorfismo, los objetos pueden ser tratados como si fueran de su clase padre, 
                // por lo cual, podemos mezclarlos en una lista de elementos de la clase padre y abuelo
                if (i % 3 == 0)
                {
                    lista_objetosPrueba.Add(new ObjetoDePruebaHijo1(1, false));
                }
                else if (i % 2 == 0)
                {
                    lista_objetosPrueba.Add(new ObjetoDePruebaHijo2(2, true));
                }
                else 
                {
                    lista_objetosPrueba.Add(new ObjetoDePruebaNieto11(3, true));
                }
            }

            // Notar los atributos y metodos que hereda ObjetoDePruebaNieto11 vienen de ObjetoDePrueba...
            // hereda los atributos a, b y c, y los getters/setters por ser publicos. No hereda
            // el atributo d de la clase padre porque es privado, pero si a su get/set (instancia.D)
            ObjetoDePruebaNieto11 instancia = new ObjetoDePruebaNieto11(3, true);
            Console.WriteLine($"\n\n{instancia.A}, {instancia.B}, {instancia.C}, {instancia.D}");

        }
    }
}
