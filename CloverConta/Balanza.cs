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
using Datos;

namespace CloverConta
{
    public partial class Balanza : Form
    {
        FormWindowState _WindowStateAnt;
        private int _iWidthAnt;
        private int _iHeightAnt;
        private string _lsProceso = "BAL";
        private string _lsAxo;
        private string _lsMes;
        public Balanza()
        {
            InitializeComponent();
            _iWidthAnt = Width;
            _iHeightAnt = Height;
            _WindowStateAnt = WindowState;
        }

        private void Balanza_Load(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Maximized;

            Inicio();

        }

        private void Inicio()
        {
            try
            {
                
                var res = new ResultadosLogica();
                res.Axo = DateTime.Today.Year;
                DataTable dt = new DataTable();

                ////////////////////////////////////
                //////////// TOTAL ///////////
                res.Clasifica = "TOTAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwTotal.DataSource = dt;
                if (dgwTotal.Rows.Count > 0)
                    dgwTotal.ClearSelection();
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwTotalSum.DataSource = dt;
                if (dgwTotalSum.Rows.Count > 0)
                    dgwTotalSum.ClearSelection();

                //////////// DIRECT ///////////
                res.Clasifica = "DIRECT";
                dt = ResultadosLogica.TrialBalance(res);
                dgwDirect.DataSource = dt;
                if (dgwDirect.Rows.Count > 0)
                    dgwDirect.ClearSelection();
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwDirectSum.DataSource = dt;
                if (dgwDirectSum.Rows.Count > 0)
                    dgwDirectSum.ClearSelection();
                
                //////////////////////////////
                
                dgwIndirect.DataSource = null;
                res.Clasifica = "INDIRECT";
                dt = ResultadosLogica.TrialBalance(res);
                dgwIndirect.DataSource = dt;
                if (dgwIndirect.Rows.Count > 0)
                    dgwIndirect.ClearSelection();
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwIndirectSum.DataSource = dt;
                if (dgwIndirectSum.Rows.Count > 0)
                    dgwIndirectSum.ClearSelection();
                /////////////////////////////////////////
                dgwTCore.DataSource = null;
                res.Area = "";
                res.Planta = "";
                res.Clasifica = "TOTCORE";
                dt = ResultadosLogica.TrialBalance(res);
                dgwTCore.DataSource = dt;
                if (dgwTCore.Rows.Count > 0)
                    dgwTCore.ClearSelection();

                dgwGAdmin.DataSource = null;
                res.Area = "GPRO";
                res.Planta = "GLO";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwGAdmin.DataSource = dt;
                if (dgwGAdmin.Rows.Count > 0)
                    dgwGAdmin.ClearSelection();
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwGAdminSum.DataSource = dt;
                if (dgwGAdminSum.Rows.Count > 0)
                    dgwGAdminSum.ClearSelection();
                ///////////////////////////////////////
                dgwDCore.DataSource = null;
                res.Clasifica = "DirectCORE";
                dt = ResultadosLogica.TrialBalance(res);
                dgwDCore.DataSource = dt;
                if (dgwDCore.Rows.Count > 0)
                    dgwDCore.ClearSelection();
                /////////////////////
                res.Area = "PROD";
                res.Planta = "COR";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwCCore.DataSource = dt;
                if (dgwCCore.Rows.Count > 0)
                    dgwCCore.ClearSelection();
                /////////////////////
                res.Planta = "MTO";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgw870.DataSource = dt;
                if (dgw870.Rows.Count > 0)
                    dgw870.ClearSelection();
                /////////////////////
                res.Planta = "EFG";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwEnvio.DataSource = dt;
                if (dgwEnvio.Rows.Count > 0)
                    dgwEnvio.ClearSelection();
                /////////////////////
                res.Planta = "DBC";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwDistrib.DataSource = dt;
                if (dgwDistrib.Rows.Count > 0)
                    dgwDistrib.ClearSelection();
                /////////////////////
                res.Planta = "RHC";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwRecup.DataSource = dt;
                if (dgwRecup.Rows.Count > 0)
                    dgwRecup.ClearSelection();
                /////////////////////
                res.Planta = "LND";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwInk.DataSource = dt;
                if (dgwInk.Rows.Count > 0)
                    dgwInk.ClearSelection();
                /////////////////////
                res.Planta = "EMP";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwPInk.DataSource = dt;
                if (dgwPInk.Rows.Count > 0)
                    dgwPInk.ClearSelection();
                /////////////////////
                res.Planta = "PKG";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwPkg.DataSource = dt;
                if (dgwPkg.Rows.Count > 0)
                    dgwPkg.ClearSelection();
                /////////////////////
                res.Planta = "FUS";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwFuser.DataSource = dt;
                if (dgwFuser.Rows.Count > 0)
                    dgwFuser.ClearSelection();
                /////////////////////
                res.Planta = "COL";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwColor.DataSource = dt;
                if (dgwColor.Rows.Count > 0)
                    dgwColor.ClearSelection();
                /////////////////////
                res.Planta = "LTT";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwDensi.DataSource = dt;
                if (dgwDensi.Rows.Count > 0)
                    dgwDensi.ClearSelection();
                /////////////////////
                res.Planta = "MON";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwMono.DataSource = dt;
                if (dgwMono.Rows.Count > 0)
                    dgwMono.ClearSelection();
               
                res.Planta = "CIK";
                dt = ResultadosLogica.TrialBalance(res);
                dgwCInkjet.DataSource = dt;
                if (dgwCInkjet.Rows.Count > 0)
                    dgwCInkjet.ClearSelection();

                res.Planta = "CWT";
                dt = ResultadosLogica.TrialBalance(res);
                dgwWHopper.DataSource = dt;
                if (dgwWHopper.Rows.Count > 0)
                    dgwWHopper.ClearSelection();

                res.Area = "GIND";
                res.Planta = "COR";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwICore.DataSource = dt;
                if (dgwICore.Rows.Count > 0)
                    dgwICore.ClearSelection();

                dgwIPack.DataSource = null;
                res.Area = "GIND";
                res.Planta = "EMP";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwIPack.DataSource = dt;
                if (dgwIPack.Rows.Count > 0)
                    dgwIPack.ClearSelection();

                res.Planta = "EMPK";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                gdwIKPKG.DataSource = dt;
                if (gdwIKPKG.Rows.Count > 0)
                    gdwIKPKG.ClearSelection();

                dgwIColor.DataSource = null;
                res.Planta = "COL";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwIColor.DataSource = dt;
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwIColorSum.DataSource = dt;
                if (dgwIColorSum.Rows.Count > 0)
                    dgwIColorSum.ClearSelection();

                dgwIToner.DataSource = null;
                res.Planta = "MON";
                res.Clasifica = "TRIAL";
                dt = ResultadosLogica.TrialBalance(res);
                dgwIToner.DataSource = dt;
                dt = ResultadosLogica.TrialBalanceTotal(res);
                dgwITonerSum.DataSource = dt;
                if (dgwITonerSum.Rows.Count > 0)
                    dgwITonerSum.ClearSelection();

                AjustaColumnas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                ResizeControl(tabControl1, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIndirect, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIndirectSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwGAdmin, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwGAdminSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwICore, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwWHopper, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwCInkjet, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwCCore, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwDCore, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwTCore, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIPack, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(gdwIKPKG, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIColor, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIColorSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwIToner, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwITonerSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwMono, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwDensi, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwColor, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwFuser, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwPInk, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwPkg, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwPInk, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwInk, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwRecup, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwDistrib, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwEnvio, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgw870, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwDirect, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwDirectSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwTotal, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwTotalSum, 2, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(dgwData, 3, ref _iWidthAnt, ref _iHeightAnt, 1);

                dgwIndirectSum.Location = new Point(dgwIndirectSum.Location.X, dgwIndirect.Location.Y + dgwIndirect.Height + 10);
                dgwGAdminSum.Location = new Point(dgwGAdminSum.Location.X, dgwGAdmin.Location.Y + dgwGAdmin.Height + 10);
                dgwITonerSum.Location = new Point(dgwITonerSum.Location.X, dgwIToner.Location.Y + dgwIToner.Height + 10);
                dgwIColorSum.Location = new Point(dgwIColorSum.Location.X, dgwIColor.Location.Y + dgwIColor.Height + 10);
                dgwDirectSum.Location = new Point(dgwDirectSum.Location.X, dgwDirect.Location.Y + dgwDirect.Height + 10);
                dgwTotalSum.Location = new Point(dgwTotalSum.Location.X, dgwTotal.Location.Y + dgwTotal.Height + 10);

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
            _lsMes = wfMes._sMes;
            _lsAxo = wfMes._sAxo;

            if (string.IsNullOrEmpty(_lsMes))
                return;

            bool bValidaMes = false;

            BalanzaLogica bal = new BalanzaLogica();
            bal.Axo = _lsAxo;
            bal.Mes = _lsMes;
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

                Inicio();
                
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
            try
            {
                if (dgwTotal.Rows.Count > 0)
                {
                    dgwTotal.Columns[0].Width = ColumnWith(dgwTotal, 2);//GT
                    dgwTotal.Columns[1].Width = ColumnWith(dgwTotal, 17);//Descrip
                    for (int i = 2; i < dgwTotal.Columns.Count; i++)
                    {
                        dgwTotal.Columns[i].DefaultCellStyle.Format = "n";
                        dgwTotal.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwTotal.Columns[i].Width = ColumnWith(dgwTotal, 6);//Descrip
                    }
                    dgwTotalSum.Columns[0].Width = ColumnWith(dgwTotalSum, 5);//GT
                    dgwTotalSum.Columns[1].Width = ColumnWith(dgwTotalSum, 17);//Descrip
                    for (int i = 2; i < dgwTotalSum.Columns.Count; i++)
                    {
                        dgwTotalSum.Columns[i].DefaultCellStyle.Format = "c";
                        dgwTotalSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwTotalSum.Columns[i].Width = ColumnWith(dgwTotalSum, 6);//Descrip
                    }
                }
                if (dgwDirect.Rows.Count > 0)
                {
                    dgwDirect.Columns[0].Width = ColumnWith(dgwDirect, 2);//GT
                    dgwDirect.Columns[1].Width = ColumnWith(dgwDirect, 17);//Descrip
                    for (int i = 2; i < dgwDirect.Columns.Count; i++)
                    {
                        dgwDirect.Columns[i].DefaultCellStyle.Format = "n";
                        dgwDirect.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwDirect.Columns[i].Width = ColumnWith(dgwDirect, 6);//Descrip
                    }
                    dgwDirectSum.Columns[0].Width = ColumnWith(dgwDirectSum, 5);//GT
                    dgwDirectSum.Columns[1].Width = ColumnWith(dgwDirectSum, 17);//Descrip
                    for (int i = 2; i < dgwDirectSum.Columns.Count; i++)
                    {
                        dgwDirectSum.Columns[i].DefaultCellStyle.Format = "c";
                        dgwDirectSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwDirectSum.Columns[i].Width = ColumnWith(dgwDirectSum, 6);//Descrip
                    }
                }

                #region regDirect
                //DIRECT - 870
                if (dgwMono.Rows.Count > 0)
                {
                    dgwMono.Columns[0].Width = ColumnWith(dgwMono, 2);//GT
                    dgwMono.Columns[1].Width = ColumnWith(dgwMono, 17);//Descrip
                    for (int i = 2; i < dgwMono.Columns.Count; i++)
                    {
                        dgwMono.Columns[i].DefaultCellStyle.Format = "n";
                        dgwMono.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwMono.Columns[i].Width = ColumnWith(dgwMono, 6);//Descrip
                    }
                }

                if (dgwFuser.Rows.Count > 0)
                {
                    dgwFuser.Columns[0].Width = ColumnWith(dgwFuser, 2);//GT
                    dgwFuser.Columns[1].Width = ColumnWith(dgwFuser, 17);//Descrip
                    for (int i = 2; i < dgwFuser.Columns.Count; i++)
                    {
                        dgwFuser.Columns[i].DefaultCellStyle.Format = "n";
                        dgwFuser.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwFuser.Columns[i].Width = ColumnWith(dgwFuser, 6);//Descrip
                    }
                }

                if (dgwDensi.Rows.Count > 0)
                {
                    dgwDensi.Columns[0].Width = ColumnWith(dgwDensi, 2);//GT
                    dgwDensi.Columns[1].Width = ColumnWith(dgwDensi, 17);//Descrip
                    for (int i = 2; i < dgwDensi.Columns.Count; i++)
                    {
                        dgwDensi.Columns[i].DefaultCellStyle.Format = "n";
                        dgwDensi.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwDensi.Columns[i].Width = ColumnWith(dgwDensi, 6);//Descrip
                    }
                }
                if (dgwColor.Rows.Count > 0)
                {
                    dgwColor.Columns[0].Width = ColumnWith(dgwColor, 2);//GT
                    dgwColor.Columns[1].Width = ColumnWith(dgwColor, 17);//Descrip
                    for (int i = 2; i < dgwColor.Columns.Count; i++)
                    {
                        dgwColor.Columns[i].DefaultCellStyle.Format = "n";
                        dgwColor.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwColor.Columns[i].Width = ColumnWith(dgwColor, 6);//Descrip
                    }
                }
                if (dgwPkg.Rows.Count > 0)
                {
                    dgwPkg.Columns[0].Width = ColumnWith(dgwPkg, 2);//GT
                    dgwPkg.Columns[1].Width = ColumnWith(dgwPkg, 17);//Descrip
                    for (int i = 2; i < dgwPkg.Columns.Count; i++)
                    {
                        dgwPkg.Columns[i].DefaultCellStyle.Format = "n";
                        dgwPkg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwPkg.Columns[i].Width = ColumnWith(dgwPkg, 6);//Descrip
                    }
                }
                if (dgwPInk.Rows.Count > 0)
                {
                    dgwPInk.Columns[0].Width = ColumnWith(dgwPInk, 2);//GT
                    dgwPInk.Columns[1].Width = ColumnWith(dgwPInk, 17);//Descrip
                    for (int i = 2; i < dgwPInk.Columns.Count; i++)
                    {
                        dgwPInk.Columns[i].DefaultCellStyle.Format = "n";
                        dgwPInk.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwPInk.Columns[i].Width = ColumnWith(dgwPInk, 6);//Descrip
                    }
                }
                if (dgwInk.Rows.Count > 0)
                {
                    dgwInk.Columns[0].Width = ColumnWith(dgwInk, 2);//GT
                    dgwInk.Columns[1].Width = ColumnWith(dgwInk, 17);//Descrip
                    for (int i = 2; i < dgwInk.Columns.Count; i++)
                    {
                        dgwInk.Columns[i].DefaultCellStyle.Format = "n";
                        dgwInk.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwInk.Columns[i].Width = ColumnWith(dgwInk, 6);//Descrip
                    }
                }
                if (dgwRecup.Rows.Count > 0)
                {
                    dgwRecup.Columns[0].Width = ColumnWith(dgwRecup, 2);//GT
                    dgwRecup.Columns[1].Width = ColumnWith(dgwRecup, 17);//Descrip
                    for (int i = 2; i < dgwRecup.Columns.Count; i++)
                    {
                        dgwRecup.Columns[i].DefaultCellStyle.Format = "n";
                        dgwRecup.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwRecup.Columns[i].Width = ColumnWith(dgwRecup, 6);//Descrip
                    }
                }
                if (dgwDistrib.Rows.Count > 0)
                {
                    dgwDistrib.Columns[0].Width = ColumnWith(dgwDistrib, 2);//GT
                    dgwDistrib.Columns[1].Width = ColumnWith(dgwDistrib, 17);//Descrip
                    for (int i = 2; i < dgwDistrib.Columns.Count; i++)
                    {
                        dgwDistrib.Columns[i].DefaultCellStyle.Format = "n";
                        dgwDistrib.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwDistrib.Columns[i].Width = ColumnWith(dgwDistrib, 6);//Descrip
                    }
                }
                if (dgwEnvio.Rows.Count > 0)
                {
                    dgwEnvio.Columns[0].Width = ColumnWith(dgwEnvio, 2);//GT
                    dgwEnvio.Columns[1].Width = ColumnWith(dgwEnvio, 17);//Descrip
                    for (int i = 2; i < dgwEnvio.Columns.Count; i++)
                    {
                        dgwEnvio.Columns[i].DefaultCellStyle.Format = "n";
                        dgwEnvio.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwEnvio.Columns[i].Width = ColumnWith(dgwEnvio, 6);//Descrip
                    }
                }
                if (dgw870.Rows.Count > 0)
                {
                    dgw870.Columns[0].Width = ColumnWith(dgw870, 2);//GT
                    dgw870.Columns[1].Width = ColumnWith(dgw870, 17);//Descrip
                    for (int i = 2; i < dgw870.Columns.Count; i++)
                    {
                        dgw870.Columns[i].DefaultCellStyle.Format = "n";
                        dgw870.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgw870.Columns[i].Width = ColumnWith(dgw870, 6);//Descrip
                    }
                }

                #endregion

                //if (dgwGAdmin.Rows.Count > 0)
                //{
                //    dgwGAdmin.Columns[0].Width = ColumnWith(dgwGAdmin, 2);//GT
                //    dgwGAdmin.Columns[1].Width = ColumnWith(dgwGAdmin, 17);//Descrip
                //    for (int i = 2; i < dgwGAdmin.Columns.Count; i++)
                //    {
                //        dgwGAdmin.Columns[i].DefaultCellStyle.Format = "n";
                //        dgwGAdmin.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //        dgwGAdmin.Columns[i].Width = ColumnWith(dgwGAdmin, 6);//Descrip
                //    }
                //    dgwGAdminSum.Columns[0].Width = ColumnWith(dgwGAdminSum, 5);//GT
                //    dgwGAdminSum.Columns[1].Width = ColumnWith(dgwGAdminSum, 17);//Descrip
                //    for (int i = 2; i < dgwGAdminSum.Columns.Count; i++)
                //    {
                //        dgwGAdminSum.Columns[i].DefaultCellStyle.Format = "c";
                //        dgwGAdminSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //        dgwGAdminSum.Columns[i].Width = ColumnWith(dgwGAdminSum, 6);//Descrip
                //    }
                //}

                #region regIndirect
                if (dgwIndirect.Rows.Count > 0)
                {
                    dgwIndirect.Columns[0].Width = ColumnWith(dgwIndirect, 2);//GT
                    dgwIndirect.Columns[1].Width = ColumnWith(dgwIndirect, 17);//Descrip
                    for (int i = 2; i < dgwIndirect.Columns.Count; i++)
                    {
                        dgwIndirect.Columns[i].DefaultCellStyle.Format = "n";
                        dgwIndirect.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIndirect.Columns[i].Width = ColumnWith(dgwIndirect, 6);//Descrip
                    }
                    dgwIndirectSum.Columns[0].Width = ColumnWith(dgwIndirectSum, 5);//GT
                    dgwIndirectSum.Columns[1].Width = ColumnWith(dgwIndirectSum, 17);//Descrip
                    for (int i = 2; i < dgwIndirectSum.Columns.Count; i++)
                    {
                        dgwIndirectSum.Columns[i].DefaultCellStyle.Format = "c";
                        dgwIndirectSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIndirectSum.Columns[i].Width = ColumnWith(dgwIndirectSum, 6);//Descrip
                    }
                }
                
                if (dgwIPack.Rows.Count > 0)
                {
                    dgwIPack.Columns[0].Width = ColumnWith(dgwIPack, 2);//GT
                    dgwIPack.Columns[1].Width = ColumnWith(dgwIPack, 17);//Descrip
                    for (int i = 2; i < dgwIPack.Columns.Count; i++)
                    {
                        dgwIPack.Columns[i].DefaultCellStyle.Format = "n";
                        dgwIPack.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIPack.Columns[i].Width = ColumnWith(dgwIPack, 6);//Descrip
                    }
                }
                
                if (gdwIKPKG.Rows.Count > 0)
                {
                    gdwIKPKG.Columns[0].Width = ColumnWith(gdwIKPKG, 2);//GT
                    gdwIKPKG.Columns[1].Width = ColumnWith(gdwIKPKG, 17);//Descrip
                    for (int i = 2; i < gdwIKPKG.Columns.Count; i++)
                    {
                        gdwIKPKG.Columns[i].DefaultCellStyle.Format = "n";
                        gdwIKPKG.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        gdwIKPKG.Columns[i].Width = ColumnWith(gdwIKPKG, 6);//Descrip
                    }
                }

                if (dgwIColor.Rows.Count > 0)
                {
                    dgwIColor.Columns[0].Width = ColumnWith(dgwIColor, 2);//GT
                    dgwIColor.Columns[1].Width = ColumnWith(dgwIColor, 17);//Descrip
                    for (int i = 2; i < dgwIColor.Columns.Count; i++)
                    {
                        dgwIColor.Columns[i].DefaultCellStyle.Format = "n";
                        dgwIColor.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIColor.Columns[i].Width = ColumnWith(dgwIColor, 6);//Descrip
                    }
                    dgwIColorSum.Columns[0].Width = ColumnWith(dgwIColorSum, 5);//GT
                    dgwIColorSum.Columns[1].Width = ColumnWith(dgwIColorSum, 17);//Descrip
                    for (int i = 2; i < dgwIColorSum.Columns.Count; i++)
                    {
                        dgwIColorSum.Columns[i].DefaultCellStyle.Format = "c";
                        dgwIColorSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIColorSum.Columns[i].Width = ColumnWith(dgwIColorSum, 6);//Descrip
                    }
                }

                if (dgwIToner.Rows.Count > 0)
                {
                    dgwIToner.Columns[0].Width = ColumnWith(dgwIToner, 2);//GT
                    dgwIToner.Columns[1].Width = ColumnWith(dgwIToner, 17);//Descrip
                    for (int i = 2; i < dgwIToner.Columns.Count; i++)
                    {
                        dgwIToner.Columns[i].DefaultCellStyle.Format = "n";
                        dgwIToner.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwIToner.Columns[i].Width = ColumnWith(dgwIToner, 6);//Descrip
                    }
                    dgwITonerSum.Columns[0].Width = ColumnWith(dgwITonerSum, 5);//GT
                    dgwITonerSum.Columns[1].Width = ColumnWith(dgwITonerSum, 17);//Descrip
                    for (int i = 2; i < dgwITonerSum.Columns.Count; i++)
                    {
                        dgwITonerSum.Columns[i].DefaultCellStyle.Format = "c";
                        dgwITonerSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwITonerSum.Columns[i].Width = ColumnWith(dgwITonerSum, 6);//Descrip
                    }
                }
                #endregion

                #region regDirectCORE
               
                if (dgwWHopper.Rows.Count > 0)
                {
                    dgwWHopper.Columns[0].Width = ColumnWith(dgwWHopper, 2);//GT
                    dgwWHopper.Columns[1].Width = ColumnWith(dgwWHopper, 17);//Descrip
                    for (int i = 2; i < dgwWHopper.Columns.Count; i++)
                    {
                        dgwWHopper.Columns[i].DefaultCellStyle.Format = "n";
                        dgwWHopper.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwWHopper.Columns[i].Width = ColumnWith(dgwWHopper, 6);//Descrip
                    }
                }
                if (dgwCInkjet.Rows.Count > 0)
                {
                    dgwCInkjet.Columns[0].Width = ColumnWith(dgwCInkjet, 2);//GT
                    dgwCInkjet.Columns[1].Width = ColumnWith(dgwCInkjet, 17);//Descrip
                    for (int i = 2; i < dgwCInkjet.Columns.Count; i++)
                    {
                        dgwCInkjet.Columns[i].DefaultCellStyle.Format = "n";
                        dgwCInkjet.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwCInkjet.Columns[i].Width = ColumnWith(dgwCInkjet, 6);//Descrip
                    }
                }
                if (dgwCCore.Rows.Count > 0)
                {
                    dgwCCore.Columns[0].Width = ColumnWith(dgwCCore, 2);//GT
                    dgwCCore.Columns[1].Width = ColumnWith(dgwCCore, 17);//Descrip
                    for (int i = 2; i < dgwCCore.Columns.Count; i++)
                    {
                        dgwCCore.Columns[i].DefaultCellStyle.Format = "n";
                        dgwCCore.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwCCore.Columns[i].Width = ColumnWith(dgwCCore, 6);//Descrip
                    }
                }
                #endregion
                
                if (dgwTCore.Rows.Count > 0)
                {
                    dgwTCore.Columns[0].Width = ColumnWith(dgwTCore, 2);//GT
                    dgwTCore.Columns[1].Width = ColumnWith(dgwTCore, 17);//Descrip

                    for (int i = 2; i < dgwTCore.Columns.Count; i++)
                    {
                        dgwTCore.Columns[i].DefaultCellStyle.Format = "n";
                        dgwTCore.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwTCore.Columns[i].Width = ColumnWith(dgwTCore, 6);//Descrip
                    }
                }
                if (dgwDCore.Rows.Count > 0)
                {
                    dgwDCore.Columns[0].Width = ColumnWith(dgwDCore, 2);//GT
                    dgwDCore.Columns[1].Width = ColumnWith(dgwDCore, 17);//Descrip
                    for (int i = 2; i < dgwDCore.Columns.Count; i++)
                    {
                        dgwDCore.Columns[i].DefaultCellStyle.Format = "n";
                        dgwDCore.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwDCore.Columns[i].Width = ColumnWith(dgwDCore, 6);//Descrip
                    }
                }
                
               

                if (dgwICore.Rows.Count > 0)
                {
                    dgwICore.Columns[0].Width = ColumnWith(dgwICore, 2);//GT
                    dgwICore.Columns[1].Width = ColumnWith(dgwICore, 17);//Descrip
                    for (int i = 2; i < dgwICore.Columns.Count; i++)
                    {
                        dgwICore.Columns[i].DefaultCellStyle.Format = "n";
                        dgwICore.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgwICore.Columns[i].Width = ColumnWith(dgwICore, 6);//Descrip
                    }
                }

                if (dgwData.Rows.Count > 0)
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                lFolio = AccesoDatos.Consec(_lsProceso);
                
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
                    bald.Movi = dMovs;
                    bald.SaldoAnt = dSaldoAnt;
                    bald.Usuario = "";
                    if (BalanDetLogica.Guardar(bald) >0 )
                        continue;
                    
                    AgregaDato(sTipoCta,sCta,sDescrip,dSaldoAnt,dCargos,dMovs,dSaldoAct);
                }
                xlApp.DisplayAlerts = false;
                xlWorkbook.Close();
                xlApp.DisplayAlerts = true;
                xlApp.Quit();

                if(rowCount > 0)
                {
                    BalanzaLogica bal = new BalanzaLogica();
                    bal.Folio = lFolio;
                    bal.Axo = _lsAxo;
                    bal.Mes = _lsMes;
                    if(BalanzaLogica.Guardar(bal) <= 0)
                        MessageBox.Show("Error, No se puedo guardar la balanza.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgwData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //int iRow = e.RowIndex;
            //string sValue = e.Value.ToString();

            //if (e.ColumnIndex >= 1)
            //{
            //    sValue = dgwData[0, e.RowIndex].Value.ToString();
                
            //    if (!string.IsNullOrEmpty(sValue) && sValue == "1")
            //    {
            //        e.CellStyle.BackColor = Color.DodgerBlue;
            //        e.CellStyle.ForeColor = Color.White;
            //    }
            //}

            //if (e.ColumnIndex >= 3)
            //{
            //    double d = double.Parse(e.Value.ToString());
            //    e.Value = d.ToString("N2");
            //}
        }

        private void dgwTCore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
