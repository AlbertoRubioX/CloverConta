using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Logica;

namespace CloverConta
{
    public partial class Balanza : Form
    {
        FormWindowState _WindowStateAnt;
        private int _iWidthAnt;
        private int _iHeightAnt;
        public Balanza()
        {
            InitializeComponent();
            _iWidthAnt = Width;
            _iHeightAnt = Height;
            _WindowStateAnt = WindowState;
        }

        private void Balanza_Load(object sender, EventArgs e)
        {
            Inicio();

            WindowState = FormWindowState.Maximized;
        }

        private void Inicio()
        {
            dgwData.DataSource = null;
        }
        
        #region regRezise
        private int ColumnWith(DataGridView _dtGrid, double _dColWith)
        {

            double dW = _dtGrid.Width - 10;
            double dTam = _dColWith;
            double dPor = dTam / 100;
            dTam = dW * dPor;
            dTam = Math.Truncate(dTam);

            return Convert.ToInt32(dTam);
        }

        private void Balanza_Resize(object sender, EventArgs e)
        {
            if (WindowState != _WindowStateAnt && WindowState != FormWindowState.Minimized)
            {
                _WindowStateAnt = WindowState;
                ResizeControl(panel1, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwData, 3, ref _iWidthAnt, ref _iHeightAnt, 1);
            }
        }
        public void ResizeControl(Control ac_Control, int ai_Hor, ref int ai_WidthAnt, ref int ai_HegihtAnt, int ai_Retorna)
        {
            if (ai_WidthAnt == 0)
                ai_WidthAnt = ac_Control.Width;
            if (ai_WidthAnt == ac_Control.Width)
                return;

            int _dif = ai_WidthAnt - ac_Control.Width;
            int _difh = ai_HegihtAnt - ac_Control.Height;

            if (ai_Hor == 1)
                ac_Control.Height = this.Height - _difh;
            if (ai_Hor == 2)
                ac_Control.Width = this.Width - _dif;
            if (ai_Hor == 3)
            {
                ac_Control.Width = this.Width - _dif;
                ac_Control.Height = this.Height - _difh;
            }
            if (ai_Retorna == 1)
            {
                ai_WidthAnt = this.Width;
                ai_HegihtAnt = this.Height;
            }
        }
        #endregion

        private void btLoad_Click(object sender, EventArgs e)
        {

            wfMesSelect wfMes = new wfMesSelect();
            wfMes.ShowDialog();
            string sMes = wfMes._sMes;
            string sAxo = wfMes._sAxo;

            if (string.IsNullOrEmpty(sMes))
                return;

            bool bValidaMes = false;

            BalanzaLogica bal = new BalanzaLogica();
            bal.Axo = sAxo;
            bal.Mes = sMes;
            bValidaMes = BalanzaLogica.Verificar(bal);

            if (!bValidaMes)
            {
                DialogResult Result = MessageBox.Show("Ya existe una Balanza para el Mes seleccionado. Desea reemplazarlo?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                    bValidaMes = true;
            }

            if (!bValidaMes)
                return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx;*.csv";
            //dialog.Filter = "All Files (*.*)|*.*";

            dialog.Title = "Seleccione el archivo de Excel";

            dialog.FileName = string.Empty;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                string sFile = dialog.FileName;

                LlenarGrid(sFile);
                //AjustaColumnas();

                Cursor = Cursors.Arrow;
            }
        }
        private void AgregaDato(string _asTipo, string _asCuenta, string _asDesc, double _adSaldoAnt, double _adCargo, double _adMovs, double _adSaldo)
        {
            DataTable dt = dgwData.DataSource as DataTable;
            dt.Rows.Add(_asTipo, _asCuenta, _asDesc, _adSaldoAnt, _adCargo, _adMovs, _adSaldo);
        }
        private void CargarColFile()
        {
            if (dgwData.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Balanza");
                dtNew.Columns.Add("tipo_cta", typeof(string));
                dtNew.Columns.Add("Cuenta", typeof(string));
                dtNew.Columns.Add("Descripcón", typeof(string));
                dtNew.Columns.Add("Saldo Anterior", typeof(double));
                dtNew.Columns.Add("Cargos", typeof(double));
                dtNew.Columns.Add("Movimientos", typeof(double));
                dtNew.Columns.Add("Saldo Actual", typeof(double));
                dgwData.DataSource = dtNew;
            }
            dgwData.Columns[0].Visible = false;

            dgwData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwData.Columns[3].DefaultCellStyle.Format = "N2";
            dgwData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwData.Columns[4].DefaultCellStyle.Format = "N2";
            dgwData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwData.Columns[5].DefaultCellStyle.Format = "N2";
            dgwData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwData.Columns[6].DefaultCellStyle.Format = "N2";
        }
        private void AjustaColumnas()
        {
            
            //dgwData.Columns[4].Width = ColumnWith(dgwEstaciones, 3);//TURNO
            dgwData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgwData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgwData.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgwData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void LlenarGrid(string _asArchivo)
        {
            try
            {
                dgwData.DataSource = null;
                CargarColFile();

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbooks xlWorkbookS = xlApp.Workbooks;
                Excel.Workbook xlWorkbook = xlWorkbookS.Open(_asArchivo);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                Excel.Range xlRange = xlWorksheet.UsedRange;
                               int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                string sUsuario = string.Empty;
                double dReal = 0;

                long lFolio = 0;//get max folio
                for (int i = 6; i < rowCount; i++)
                {
                    if (xlRange.Cells[i, 1] == null)
                        continue;

                    if (xlRange.Cells[i, 2].Value2 == null)
                        continue;

                    string sTipoCta = "0";
                    if (xlRange.Cells[i, 3].Value2 == null)
                    {
                        //inicia Cuenta maestra
                        sTipoCta = "1";
                    }

                    string sCta = xlRange.Cells[i, 1].Value2.ToString();
                    if (sCta.ToUpper() == "CUENTA")
                        continue;

                    string sDescrip = xlRange.Cells[i, 2].Value2.ToString();
                    double dSaldoAnt = 0;
                    double dSaldoAct = 0;
                    double dCargos = 0;
                    double dMovs = 0;
                     
                    if (sTipoCta == "0")
                    {
                        if (!double.TryParse(xlRange.Cells[i, 3].Value2.ToString(), out dSaldoAnt))
                            dSaldoAnt = 0;
                        if (!double.TryParse(xlRange.Cells[i, 4].Value2.ToString(), out dCargos))
                            dCargos = 0;
                        if (!double.TryParse(xlRange.Cells[i, 5].Value2.ToString(), out dMovs))
                            dMovs = 0;
                        if (!double.TryParse(xlRange.Cells[i, 6].Value2.ToString(), out dSaldoAct))
                            dSaldoAct = 0;
                    }

                    BalanDetLogica bald = new BalanDetLogica();
                    bald.Folio = lFolio;
                    bald.Consec = 0;
                    bald.Cuenta = sCta;
                    bald.Nombre = sDescrip;
                    bald.Saldo = dSaldoAnt;
                    bald.Cargo = dCargos;
                    bald.SaldoAnt = dSaldoAnt;
                    bald.Usuario = "";
                    if (BalanDetLogica.Guardar(bald) >0 )
                        continue;
                    
                    //AgregaDato(sTipoCta,sCta,sDescrip,dSaldoAnt,dCargos,dMovs,dSaldoAct);
                }
                xlApp.DisplayAlerts = false;
                xlWorkbook.Close();
                xlApp.DisplayAlerts = true;
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgwData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int iRow = e.RowIndex;
            string sValue = e.Value.ToString();

            if (e.ColumnIndex >= 1)
            {
                sValue = dgwData[0, e.RowIndex].Value.ToString();
                
                if (!string.IsNullOrEmpty(sValue) && sValue == "1")
                {
                    e.CellStyle.BackColor = Color.DodgerBlue;
                    e.CellStyle.ForeColor = Color.White;
                }
            }

            //if (e.ColumnIndex >= 3)
            //{
            //    double d = double.Parse(e.Value.ToString());
            //    e.Value = d.ToString("N2");
            //}
        }
    }
}
