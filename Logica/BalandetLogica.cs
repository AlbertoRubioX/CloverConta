using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class BalanDetLogica
    {
        public long Folio { get; set; }
        public int Consec { get; set; }
        public string Cuenta { get; set; }
        public string Nombre { get; set; }
        public double SaldoAnt { get; set; }
        public double Cargo { get; set; }
        public double Movi { get; set; }
        public double Saldo { get; set; }
        public string Usuario { get; set; }

        public static int Guardar(BalanDetLogica bal)
        {
            string[] parametros = { "@Folio", "@Consec", "@Cuenta", "@Nombre", "@SaldoAnt", "@Cargo", "@Movimiento", "@Saldo", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_balandet", parametros, bal.Folio, bal.Consec, bal.Cuenta, bal.Nombre, bal.SaldoAnt, bal.Cargo, bal.Movi, bal.Saldo, bal.Usuario);
        }

        public static DataTable Consultar(BalanzaLogica bal)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_balandet WHERE folio = " + bal.Folio + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        /*
        public static bool Verificar(BalanzaLogica bal)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_balanza WHERE axo = '" + bal.Axo + "' and mes = '"+bal.Mes+"'";
                DataTable datos = AccesoDatos.Consultar(sQuery);
                if (datos.Rows.Count != 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable ListarAxo(BalanzaLogica bal)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_balanza WHERE axo = '"+bal.Axo+"' ");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

     
        public static bool Eliminar(BalanzaLogica bal)
        {
            try
            {
                string sQuery = "DELETE FROM t_balanza WHERE folio = " + bal.Folio + "";
                if (AccesoDatos.Borrar(sQuery) != 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        */
    }
}
