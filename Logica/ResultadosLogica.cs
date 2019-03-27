using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class ResultadosLogica
    {
        public long Folio { get; set; }
        public int Axo { get; set; }
        public string Mes { get; set; }
        public string Area { get; set; }
        public string Planta { get; set; }
        public string Clasifica { get; set; }

        public static DataTable TrialBalance(ResultadosLogica res)
        {
            DataTable datos = new DataTable();
            try
            {
                string[] parametros = { "@Axo", "@Area", "@Planta", "@Clasi" };
                datos = AccesoDatos.ConsultaSP("sp_mon_balanza_anual", parametros, res.Axo,res.Area,res.Planta,res.Clasifica);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datos;
        }

        public static DataTable TrialBalanceTotal(ResultadosLogica res)
        {
            DataTable datos = new DataTable();
            try
            {
                string[] parametros = { "@Axo", "@Area", "@Planta", "@Clasi" };
                datos = AccesoDatos.ConsultaSP("sp_mon_balanza_total", parametros, res.Axo, res.Area, res.Planta, res.Clasifica);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datos;
        }




        public static DataTable Consultar(ResultadosLogica bal)
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

        public static bool Verificar(ResultadosLogica bal)
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

        public static DataTable ListarAxo(ResultadosLogica bal)
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

     
        public static bool Eliminar(ResultadosLogica bal)
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
