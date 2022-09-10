namespace Figures
{
    public class Consumer
    {
        public void Example1()
        {
            var rectangle = new Rectangle();

            rectangle.SetHeight(2);
            rectangle.SetWidth(5);

            rectangle.GetArea();
        }
        
        public void Example2()
        {
            Square/*Rectangle*/ square = new Square();

            //square.SetHeight(2);
            //square.SetWidth(5);

            //nuevo
            square.SetSide(2);

            //Example3(square);

            
        }

        public void Example3(Rectangle rectangle)
        {
            //sintoma de incumplimiento de Liskov: es usar metodos de instanceoff o en C# es Is o As, no podemos preguntar que tipo es para hacer una cosa u otra porque
            //mañana añadiremos otro tipo y olvidaremos actualizar estas cosas y el programa dejara de funcionar o tendra un comportamiento inesperado
            //ademas que incumple abierto y cerrado.
            if (rectangle is Square)
            {

            }
            else if (rectangle is Rectangle)
            {

            }
            // un triangulo podria ser figura pero en codigo no tiene sentido no queremos que sus padres puedan desvirtuar a sus hijos 
            rectangle.SetHeight(10);
            
        }
    }
}