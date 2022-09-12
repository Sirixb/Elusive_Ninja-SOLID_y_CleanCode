namespace Vehicles
{
    public class Impuestos
    {
        //public void CalcularImpuesto(Vehiculo vehiculo)
        //{
        //    var identificador = string.Empty;
        //    //Incumplimos Liskov porque tenemos que preguntar por el tipo de la clase
        //    //if (vehiculo/*.GetType().Name == "Coche"*/ is Coche coche)//si lo almaceno en una variable aqui me ahorro el casting adentro
        //    //{
        //    //    identificador = /*((Coche)vehiculo)*/coche.ObtenerMatricula();
        //    //}
        //    //else if (vehiculo.GetType().Name == "Ciclomotor")
        //    //{
        //    //    identificador = ((Ciclomotor)vehiculo).ObtenerNumLicencia();
        //    //}

        //    if (vehiculo.TrabajaConLicencia)
        //    {
        //        identificador = vehiculo.ObtenerMatricula();
        //    }
        //    else if (vehiculo.TrabajaConMatricula)
        //    {
        //        identificador = vehiculo.ObtenerNumLicencia();
        //    }

        //    ServicioCalculoImpuestos(identificador, vehiculo.Cilindrada);
        //}

        //Otra posible solucion es que trabaje con vehiculos especificos
        public void CalcularImpuesto(Coche vehiculo)
        {
            var identificador = vehiculo.ObtenerMatricula();
            ServicioCalculoImpuestos(identificador, vehiculo.Cilindrada);
        }
        public void CalcularImpuesto(Ciclomotor vehiculo)
        {
            var identificador = vehiculo.ObtenerNumLicencia();
            ServicioCalculoImpuestos(identificador, vehiculo.Cilindrada);
        }


        private void ServicioCalculoImpuestos(string identificador, int cilindrada)
        {
            throw new System.NotImplementedException();
        }
    }
}


