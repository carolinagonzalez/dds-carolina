namespace TPDDSGrupo44.Models
{
    public class FuncionalidadUsuario
    {
        string nombre { get; set; }

        public FuncionalidadUsuario ()
        {
        }

        public virtual void cargarPOI() { }

        public virtual void realizarTramite() { }

        public virtual void loguearse() { }
    }
}