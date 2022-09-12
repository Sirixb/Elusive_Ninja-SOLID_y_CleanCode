namespace Vehicles
{
    public class Ciclomotor : Vehiculo
    {
        //al hacer la ultima solucion en Impuestos podemos quitar esto:
        //public override bool TrabajaConLicencia => true;
        //public override bool TrabajaConMatricula => false;

        private string _numeroDeLicencia;

        public Ciclomotor(string numeroDeLicencia)
        {
            _numeroDeLicencia = numeroDeLicencia;
        }
    
        public /*override*/ string ObtenerNumLicencia()
        {
            return _numeroDeLicencia;
        }
    }
}
