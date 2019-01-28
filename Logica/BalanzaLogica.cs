using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class BalanzaLogica
    {
        public long Folio { get; set; }
        public string Axo { get; set; }
        public string Mes { get; set; }
        public string Cancela { get; set; }
        public string Usuario { get; set; }

        public static int Guardar(BalanzaLogica bal)
        {
            string[] parametros = { "@Folio", "@Axo", "@Mes", "@Cancela", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_balanza", parametros, bal.Folio, bal.Axo, bal.Mes, bal.Cancela, bal.Usuario);
        }

        public static DataTable Consultar(BalanzaLogica bal)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_balanza WHERE folio = " + bal.Folio + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(BalanzaLogica bal)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_balanza WHERE axo = '" + bal.Axo + "' and mes = '"+bal.Mes+"'";
                DataTable datos = AccesoDatos.Consultar(sQuery);
                if (datos.Rows.Count == 0)
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

        
    }
}
