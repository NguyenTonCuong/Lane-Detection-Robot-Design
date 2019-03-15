using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace HC06_Interface
{
    public partial class Form2 : Form
    {
        #region Quan ly bien
        SerialPort UART = new SerialPort();

        long tickStart = 0;
        public enum _enCheDo { Compact = 0, Scroll };
        _enCheDo CheDo = _enCheDo.Compact;

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

        public void draw(double setpoint1)
        {
            //make sure that curvelist has at least one curve
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return; // Kiểm tra việc khởi tạo các đường curve

            LineItem curve1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            //LineItem curve2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            if (curve1 == null)
                return;
            //if (curve2 == null)
            //    return;

            IPointListEdit list1 = curve1.Points as IPointListEdit;
            //IPointListEdit list2 = curve2.Points as IPointListEdit;
            if (list1 == null)
                return;
            //if (list2 == null)
            //    return;

            tickStart = tickStart + 1;
            double time = tickStart;
            //time = (Environment.TickCount - tickStart) / 500.0;

            list1.Add(time, setpoint1);// Đây chính là hàm hiển thị dữ liệu của mình lên đồ thị
            //list2.Add(time, setpoint1 + 20);

            //keep the X scale at a rolling 30 seconed interval, with one major step
            //between the max X value and the end of the axis
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (CheDo == _enCheDo.Compact)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }
                else
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }

            //make sure the y axis is rescaled to accommodate actual data
            zedGraphControl1.AxisChange();
            // Force a redraw
            zedGraphControl1.Invalidate();
        }
        #endregion
        #region Quan ly form 
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _Khoitao();
            this.UART.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.UART_DataReceived);
            //chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisX.Maximum = 10;
            //chart1.ChartAreas[0].AxisY.Maximum = 120;
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "ĐỒ THỊ KHOẢNG CÁCH SRF05";
            myPane.XAxis.Title.Text = "Thời Gian";
            myPane.YAxis.Title.Text = "Khoảng Cách";
            RollingPointPairList list1 = new RollingPointPairList(2000);
            RollingPointPairList list2 = new RollingPointPairList(2000);
            LineItem curve1 = myPane.AddCurve("Khoảng Cách 1", list1, Color.Red, SymbolType.None);
            //LineItem curve2 = myPane.AddCurve("Current", list2, Color.Blue, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;  // Min = 0;
            myPane.XAxis.Scale.Max = 30; // Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;  // Đơn vị chia nhỏ nhất 1
            myPane.XAxis.Scale.MajorStep = 5; // Đơn vị chia lớn 5

            //scale the axes
            zedGraphControl1.AxisChange();

            //save the beginning time for reference
            //tickStart = Environment.TickCount;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
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
                if(a > 20)
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

                //if (Index <= 8)
                //{
                //    Index = Index + 1;
                //}

                //for (int i = Index; i >= 1; i--)
                //{
                //    Data[i] = Data[i - 1];
                //}

                //chart1.Series["KhoangCach"].Points.DataBindY(Data);
                //chart1.Series["KhoangCach"].Points.ResumeUpdates();

                BeginInvoke(new Action(() =>
                {
                    //chart1.Series["Series1"].Points.DataBindY(Data);
                    //chart1.Series["Series1"].Points.ResumeUpdates();
                    //chart1.Series["Series1"].LegendText = "Nhiet Do: " + Data[0].ToString();

                    //chart1.Series["Series2"].Points.DataBindY(Data_2);
                    //chart1.Series["Series2"].Points.ResumeUpdates();

                    draw(Convert.ToInt32(Tam));

                }));
            }
            catch (Exception)
            {

            }
        }

        private void btnCheDo_Click(object sender, EventArgs e)
        {
            if (btnCheDo.Text == "Scroll")
            {
                CheDo = _enCheDo.Scroll;
                btnCheDo.Text = "Compact";
            }
            else
            {
                CheDo = _enCheDo.Compact;
                btnCheDo.Text = "Scroll";
            }
        }
    }
}
