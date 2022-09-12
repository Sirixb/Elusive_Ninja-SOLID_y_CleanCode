namespace Vehicles
{
    public abstract class Vehiculo
    {
        public string Marca      { get; set; }
        public string Modelo     { get; set; }
        public int    Cilindrada { get; set; }

        //al hacer la ultima solucion en Impuestos podemos quitar esto:
        
        //public abstract bool TrabajaConLicencia { get;}
        //public abstract bool TrabajaConMatricula { get; }


        //public virtual string ObtenerMatricula() { throw new System.NotImplementedException(); }
        //public virtual string ObtenerNumLicencia() => throw new System.NotImplementedException(); 
    }
}
