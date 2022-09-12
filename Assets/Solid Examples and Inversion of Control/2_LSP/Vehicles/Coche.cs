namespace Vehicles
{
    public class Coche : Vehiculo
    {
        //al hacer la ultima solucion en Impuestos podemos quitar esto:
        //public override bool TrabajaConLicencia => false;
        //public override bool TrabajaConMatricula => true; 
        
        private string _matricula;

        public Coche(string matricula)
        {
            _matricula = matricula;
        }

      

        public /*override*/ string ObtenerMatricula()
        {
            return _matricula;
        }
    }
}
