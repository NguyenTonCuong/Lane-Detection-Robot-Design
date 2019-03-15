using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace HC06_Interface
{
    public partial class Form1 : Form
    {
        #region Quan ly bien
        SerialPort UART = new SerialPort();
        #endregion
        #region Quan ly ham 
        private void _Khoitao()
        {
            try
            {
                cbxTenCongCom.DataSource = SerialPort.GetPortNames();
                if(cbxTenCongCom.Items.Count>0)
                {
                    cbxTenCongCom.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

                
            }
        }
        #endregion
        #region Quan ly form 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _Khoitao();
            this.UART.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.UART_DataReceived);
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 120;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
            }
        }
        #endregion

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbxTenCongCom.Text.Trim().Length == 0)
                {
                    MessageBox.Show("VUI LONG CHON CONG COM");
                    return;
                }
                UART.PortName = cbxTenCongCom.Text;
                UART.Open();
                if(UART.IsOpen == true)
                {
                    btnNgatKetNoi.Enabled = true;
                    btnKetNoi.Enabled = false;
                }
                else
                {
                    btnNgatKetNoi.Enabled = false;
                    btnKetNoi.Enabled = true;
                }

            }
            catch (Exception)
            {

            }
        }

        private void btnNgatKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                UART.Close();
                if (UART.IsOpen == true)
                {
                    btnNgatKetNoi.Enabled = true;
                    btnKetNoi.Enabled = false;
                }
                else
                {
                    btnNgatKetNoi.Enabled = false;
                    btnKetNoi.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        string Tam = "";
        int Index = 0;
        int[] Data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void UART_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                double a;
                lbKhoangCach.Text = UART.ReadTo("\r");
                double.TryParse(lbKhoangCach.Text, out a);
                if(a > 10)
                {
                    lbMotor.Text = "RUN";
                }
                else
                {
                    lbMotor.Text = "STOP";
                }

                Tam = UART.ReadTo("\r");//nhan du lieu tu vdk gui len
                //Tam = Tam.Substring(4, 2);//tach so 
                Data[0] = Convert.ToInt32(Tam);
                //lbNhietDo.Text = "Nhiệt Độ: " + Data[0].ToString();

                if (Index <= 8)
                {
                    Index = Index + 1;
                }

                for (int i = Index; i >= 1; i--)
                {
                    Data[i] = Data[i - 1];
                }
 
                    chart1.Series["KhoangCach"].Points.DataBindY(Data);
                    chart1.Series["KhoangCach"].Points.ResumeUpdates();

                
            }
            catch (Exception)
            {

            }
        }
    }
}
