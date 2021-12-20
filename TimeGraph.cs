using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BoincLogAnalyzer
{
    public partial class cTimeGraph : Form
    {

        static Random rnd;
        double timeStamp = 0.0;
        int itimeStamp = 0;
        int jtimeStamp = 0;
        public TreeNode mainNode;
        private bool bAllowCallback = false;  // allow combo box to show data when changed
        

        private cLogFileInfo ScrollOneRec;
        private int ScrollBits; // this is the 1,2,4 bit set to indicate what y axis to plot
        private int iScrolling; // we are scrolling this data record
        private int iScrollAdvance;

        public class cGraphInfo
        {
            public UInt64 NumSTimeSpan; // time span in seconds
            public Color rgb;
            public List<double> STime;  // this is x axis
            public List<double> secDUE; // following are y axis
            public List<double> secDCT;
            public List<double> secDET;
        }
        List<cLogFileInfo> alr;
        cGraphInfo ThisSeriesData;
        List<int> iLocData;
        List<int> iLocRecSelected; // index into the raw data from drop down combo box items
        List<int> bLocRecSelected; // bit pattern identifing which y series to plot
        // 001, 010, 100 identify estimated RT, cpu time and elapsed time = 1,2,4 decimal

        const int ue = 1;
        const int ut = 2;
        const int et = 4;

        private void BuildTree()
        {
            TreeNode a, b;
            int i=1;
            foreach(int j in iLocData)
            {
                a = new TreeNode();
                a.Name = i.ToString();
                a.Text = alr[j].strName;
                a.Checked = true;
                a.Tag = j;  // index into the database
                b = new TreeNode();
                b.Name = "ue";
                b.Text = "Est Time";
                b.Checked = true;
                a.Nodes.Add(b);
                b = new TreeNode();
                b.Name = "ut";
                b.Text = "CPU time";
                b.Checked = true;
                a.Nodes.Add(b);
                b = new TreeNode();
                b.Name = "et";
                b.Text = "Elapsed";
                b.Checked = true;
                a.Nodes.Add(b);
                mainNode.Nodes.Add(a);
            }
            mainNode.ExpandAll();
        }

        private bool CountDataSets()
        {
            if (alr.Count == 0) return false;
            iLocData = new List<int>();
            for (int i = 0; i < alr.Count; i++)
            {
                if (alr[i].bSelected)
                {
                    iLocData.Add(i); // index to data to display
                }
            }
            mainNode = new TreeNode();
            mainNode.Text = Environment.MachineName.ToString();
            gtv.Nodes.Add(mainNode);
            BuildTree();
            gtv.Show();
            gtv.Nodes[0].Expand();
            return true;
        }

        public void TimeGraph(ref List<cLogFileInfo> r_alr)
        {
            InitializeComponent();
            alr = r_alr;
            bool bReturn = CountDataSets();
            if (bReturn == false)
            {
                return;
            }
            iLocRecSelected = new List<int>();
            bLocRecSelected = new List<int>();
            CountGraphsWanted();
        }

        private double GetNiceScale(double dValue)
        {
            int iVal;
            if (dValue < 10.0) return 10.0;
            if (dValue < 100.0)
            {
                iVal = Convert.ToInt32(dValue / 10.0);
                iVal++;
                iVal *= 10;
            }
            else if (dValue < 1000.0)
            {
                iVal = Convert.ToInt32(dValue / 100.0);
                iVal++;
                iVal *= 100;
            }
            else if (dValue < 10000.0)
            {
                iVal = Convert.ToInt32(dValue / 1000.0);
                iVal++;
                iVal *= 1000;
            }
            else
            {
                iVal = Convert.ToInt32(dValue / 10000.0);
                iVal++;
                iVal *= 10000;
            }
            return Convert.ToDouble(iVal);
        }

        private double NoNegLog(double val)
        {
            if (!cb_ylog.Checked) return val;
            if (val < 0.0) return 1.0;
            return val;
        }

        // there is 1 x-axis and (up to)3 y-axis
        private void CreateThreeSeries(int n, int iBit)
        {
            int m;
            double SetUnity; // sets last value of x axis to 1.0
            double yMax = 0;    // maximum extent of y axis
            foreach (var series in tgraph.Series)
            {
                series.Points.Clear();
            }
            while(tgraph.Series.Count > 0)
            {
                tgraph.Series.RemoveAt(0);
            }
            
            tgraph.ChartAreas[0].AxisX.Minimum = 0;
            tgraph.ChartAreas[0].AxisX.Maximum = 1.0;
            tgraph.ChartAreas[0].AxisX.ScaleView.Size = 1.0 / (1.0 + Convert.ToDouble(nudScollCnt.Value));
            tgraph.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            tgraph.ChartAreas[0].AxisY.IsLogarithmic = cb_ylog.Checked;
            cLogFileInfo OneRec = alr[n];
            m = OneRec.RawData.Count;
            SetUnity = OneRec.RawData[m - 1].dTimeCompleted;
            ThisSeriesData = new cGraphInfo();
            ThisSeriesData.STime = new List<double>();
            ThisSeriesData.secDCT = new List<double>();
            ThisSeriesData.secDET = new List<double>();
            ThisSeriesData.secDUE = new List<double>();

            yMax = 0;
            if ((iBit & ut) > 0) yMax = Math.Max(yMax, OneRec.dYElapsedCPU);
            if ((iBit & et) > 0) yMax = Math.Max(yMax, OneRec.dYElapsedTime);
            if ((iBit & ue) > 0) yMax = Math.Max(yMax, OneRec.dYEstimateRT);

            for (int i = 0; i < m; i++)
            {
                SetUnity = i;
                // ThisSeriesData.STime.Add(OneRec.RawData[i].dTimeCompleted / SetUnity);
                ThisSeriesData.STime.Add(SetUnity / m);
                // todo remove NoNegLog when data tagged as error
                ThisSeriesData.secDCT.Add(NoNegLog(OneRec.RawData[i].dElapsedCPU));
                ThisSeriesData.secDET.Add(NoNegLog(OneRec.RawData[i].dElapsedTime));
                ThisSeriesData.secDUE.Add(NoNegLog(OneRec.RawData[i].dEstimateRT));
            }
            if((iBit & ut) > 0)
            {
                tgraph.Series.Add("CPU"); // CT
                tgraph.Series["CPU"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["CPU"].ChartType = SeriesChartType.Point;
                tgraph.Series["CPU"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDCT.ToArray());

            }
            if((iBit & et) > 0)
            {
                tgraph.Series.Add("ET"); // ET
                tgraph.Series["ET"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["ET"].ChartType = SeriesChartType.Point;
                tgraph.Series["ET"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDET.ToArray());
            }

            if((iBit & ue)> 0)
            {
                tgraph.Series.Add("EST"); // UE
                tgraph.Series["EST"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["EST"].ChartType = SeriesChartType.Point;
                tgraph.Series["EST"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDUE.ToArray());
            }
            tgraph.ChartAreas[0].AxisY.Maximum = GetNiceScale(yMax);
        }

        // called every time checkbox in tree is changed
        private void CountGraphsWanted()
        {
            cb_SelData.Items.Clear();
            iLocRecSelected.Clear();
            bLocRecSelected.Clear();
            int iBit;
            foreach (TreeNode tn in mainNode.Nodes)
            {
                if (tn.Checked)
                {
                    iBit = 0;
                    if (tn.Nodes["ut"].Checked) iBit |= ut;
                    if (tn.Nodes["et"].Checked) iBit |= et;
                    if (tn.Nodes["ue"].Checked) iBit |= ue;
                    bLocRecSelected.Add(iBit);
                    iLocRecSelected.Add(Convert.ToInt32(tn.Tag));
                    cb_SelData.Items.Add(tn.Text);
                    
                    if (cb_SelData.SelectedIndex < 0)
                        cb_SelData.SelectedIndex = 0;
                }

            }
            if (timer_ScrollData.Enabled) // we may be scrolling
            {
                int new_index=0;
                int new_bits = 0;
                GetRecordIndex(ref new_index, ref new_bits);
                if(new_index == iScrolling)
                {
                    //ScrollBits = new_bits;
                }
            }
        }

        // the item selected in the combo drop down box:  need location in database
        private void GetRecordIndex(ref int irec, ref int iBit)
        {
            int i = cb_SelData.SelectedIndex;
            if (i < 0) return;
            irec = iLocRecSelected[i];
            iBit = bLocRecSelected[i];
        }

        private void btn_ShowData_Click(object sender, EventArgs e)
        {
            bAllowCallback = true;  // allow combo box to show data when changed
            PlotAtOnce();
        }

        public void PlotAtOnce()
        {
            int i = 0;
            int j = 0;
            GetRecordIndex(ref i, ref j);
            CreateThreeSeries(i, j);
        }

        private void btn_ScrollData_Click(object sender, EventArgs e)
        {

            if (timer_ScrollData.Enabled)
            {
                ClearScrolling(); // this disables timer
                return;
            }
            ClearScrolling();
            iScrolling = 0;
            ScrollBits = 0;
            GetRecordIndex(ref iScrolling, ref ScrollBits);
            ScrollOneRec = alr[iScrolling];
            timer_ScrollData.Enabled = true;
            btn_ScrollData.Text = "Exit Scrolling";
            btn_Pause.Enabled = true;
            gtv.Enabled = false;
            iScrollAdvance = tgraph.Size.Width / 2;
            timeStamp = 0;
            itimeStamp = 0;
            jtimeStamp = 0;


            if ((ScrollBits & ut) > 0)
            {
                tgraph.Series.Add("CPU"); // CT
                tgraph.Series["CPU"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["CPU"].ChartType = SeriesChartType.Point;
            }
            if ((ScrollBits & et) > 0)
            {
                tgraph.Series.Add("ET"); // ET
                tgraph.Series["ET"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["ET"].ChartType = SeriesChartType.Point;
            }
            if ((ScrollBits & ue) > 0)
            {
                tgraph.Series.Add("EST"); // UE
                tgraph.Series["EST"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["EST"].ChartType = SeriesChartType.Point;
            }

            tgraph.ChartAreas[0].AxisX.Maximum = ScrollOneRec.RawData.Count;
            tgraph.ChartAreas[0].AxisX.Minimum = 0;
            tgraph.ChartAreas[0].AxisX.ScaleView.Size = tgraph.Size.Width;
            tgraph.ChartAreas[0].AxisY.IsLogarithmic = cb_ylog.Checked;
            tgraph.ChartAreas[0].AxisX.ScrollBar.Size = 10;
        }

        private void ClearScrolling()
        {
            timer_ScrollData.Enabled = false;
            gtv.Enabled = true;
            btn_ScrollData.Text = "Scroll Data";
            btn_Pause.Enabled = false;
            while (tgraph.Series.Count > 0)
            {
                tgraph.Series.RemoveAt(0);
            }
            return;
        }

        private void timer_ScrollData_Tick(object sender, EventArgs e)
        {

            if (jtimeStamp > tgraph.Size.Width) 
            {
                jtimeStamp = 0;
                tgraph.ChartAreas[0].AxisX.ScaleView.Scroll(timeStamp - iScrollAdvance); 
            }      

            if ((ScrollBits & ut) > 0)
            {
                // ct 
                tgraph.Series["CPU"].Points.AddXY(timeStamp, 
                    ScrollOneRec.RawData[itimeStamp].dElapsedCPU);
            }

            if ((ScrollBits & et) > 0)
            {
                 // ET
                tgraph.Series["ET"].Points.AddXY(timeStamp,
                    ScrollOneRec.RawData[itimeStamp].dElapsedTime);

            }

            if ((ScrollBits & ue) > 0)
            {
                 // UE
                tgraph.Series["EST"].Points.AddXY(timeStamp,
                    ScrollOneRec.RawData[itimeStamp].dEstimateRT);

            }


            timeStamp += 1;
            itimeStamp += 1;
            jtimeStamp += 1;
            if(itimeStamp >= ScrollOneRec.RawData.Count)
            {
                timer_ScrollData.Enabled = false;
                ShowScrollFinished();
            }
        }

        private void ShowScrollFinished()
        {
            PauseExit pe = new PauseExit();
            pe.ShowDialog();
            ClearScrolling();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            timer_ScrollData.Enabled = !timer_ScrollData.Enabled;
            btn_Pause.Text = timer_ScrollData.Enabled ? "Pause" : "Un-Pause";
        }

        private void gtv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CountGraphsWanted();
        }

        private void gtv_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cb_SelData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bAllowCallback)
                PlotAtOnce();
        }

        private void nudScollCnt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
