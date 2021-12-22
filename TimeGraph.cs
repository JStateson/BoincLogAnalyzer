using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BoincLogAnalyzer
{
    public partial class cTimeGraph : Form
    {
      
        //static Random rnd;
        double timeStamp = 0.0;
        int itimeStamp = 0;
        int jtimeStamp = 0;
        public TreeNode mainNode;
        private bool bAllowCallback = false;  // allow combo box to show data when changed

        cAdvFilter MyAdvFilter = new cAdvFilter();
        private cLogFileInfo OneRec; // this is the currently plotting display
        private int OneRecBits;      // also used by the plot three
        private int OneRecSelIndex;  // the index value (listbox) that selected the record

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

      
        // tag added so can use notepad to look
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
                b.Tag = j;
                a.Nodes.Add(b);
                b = new TreeNode();
                b.Name = "ut";
                b.Text = "CPU time";
                b.Checked = true;
                b.Tag = j;
                a.Nodes.Add(b);
                b = new TreeNode();
                b.Name = "et";
                b.Text = "Elapsed";
                b.Checked = true;
                b.Tag = j;
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

        // not needed any more I suspect
        private double NoNegLog(double val)
        {
            if (!cb_ylog.Checked) return val;
            if (val < 0.0) return 1.0;
            return val;
        }

        private bool bProcessFilter(string strName)
        {
            if (cbUseAdvFilter.Checked)
            {
                if (MyAdvFilter.bContains)
                {
                    return !(strName.Contains(MyAdvFilter.strPhrase));
                }
                else
                {
                    return (strName.Contains(MyAdvFilter.strPhrase));
                }
            }
            return false;
        }

        private void HideData(bool bUnhide)
        {
            int m;
            bool bHid;
            m = OneRec.RawData.Count;
            OneRec.NumHidden = 0;
            for(int i=0; i < m; i++)
            {
                if(bUnhide)
                {
                    OneRec.RawData[i].bUserHide = false;
                }
                else
                {
                    string strAppName = OneRec.RawData[i].strTaskName;
                    bHid = bProcessFilter(strAppName);
                    OneRec.RawData[i].bUserHide = bHid;
                    if (bHid)
                        OneRec.NumHidden++;
                }
            }
        }

        private void CreateThreeSeries(int n, int iBit)
        {
            OneRec = alr[n];
            OneRecBits = iBit;
            PLotTheThreeSeries();
        }

        double ExBits(ref double yMax, int id,  double dPoint)
        {
            if ((OneRecBits & id) > 0) yMax = Math.Max(yMax, dPoint);
            return dPoint;
        }

        // there is 1 x-axis and (up to)3 y-axis
        /// </summary>
        /// <param name="n"></param> is index into project table of data
        /// <param name="iBit"></param> a bit set to determine which yaxis point to plot
        private void PLotTheThreeSeries()
        {
            int m, iBit = OneRecBits;
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


            m = OneRec.RawData.Count;
            if (cbUseAdvFilter.Checked)
                HideData(false);
            SetUnity = OneRec.RawData[m - 1].dTimeCompleted;
            ThisSeriesData = new cGraphInfo();
            ThisSeriesData.STime = new List<double>();
            ThisSeriesData.secDCT = new List<double>();
            ThisSeriesData.secDET = new List<double>();
            ThisSeriesData.secDUE = new List<double>();

            // need to know the high points so the graph had a high point that is visible at THE TOP
            OneRec.dYElapsedCPU = 0;
            OneRec.dYElapsedTime = 0;
            OneRec.dYEstimateRT = 0;
            SetUnity = 0;
            for (int i = 0; i < m; i++)
            {
                if (OneRec.RawData[i].bUserHide) continue;
                ThisSeriesData.STime.Add(SetUnity / m);
                ThisSeriesData.secDCT.Add(ExBits(ref OneRec.dYElapsedCPU, ut, OneRec.RawData[i].dElapsedCPU));
                ThisSeriesData.secDET.Add(ExBits(ref OneRec.dYElapsedTime, et, OneRec.RawData[i].dElapsedTime));
                ThisSeriesData.secDUE.Add(ExBits(ref OneRec.dYEstimateRT, ue, OneRec.RawData[i].dEstimateRT));
                SetUnity++;
            }
            if((iBit & ut) > 0)
            {
                tgraph.Series.Add("CPU"); // CT
                tgraph.Series["CPU"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["CPU"].ChartType = SeriesChartType.Point;
                tgraph.Series["CPU"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDCT.ToArray());
                yMax = Math.Max(yMax,OneRec.dYElapsedCPU);
            }
            if((iBit & et) > 0)
            {
                tgraph.Series.Add("ET"); // ET
                tgraph.Series["ET"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["ET"].ChartType = SeriesChartType.Point;
                tgraph.Series["ET"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDET.ToArray());
                yMax = Math.Max(yMax, OneRec.dYElapsedTime);
            }

            if((iBit & ue)> 0)
            {
                tgraph.Series.Add("EST"); // UE
                tgraph.Series["EST"].EmptyPointStyle.Color = Color.Transparent; //?
                tgraph.Series["EST"].ChartType = SeriesChartType.Point;
                tgraph.Series["EST"].Points.DataBindXY(
                    ThisSeriesData.STime.ToArray(),
                    ThisSeriesData.secDUE.ToArray());
                yMax = Math.Max(yMax, OneRec.dYEstimateRT);
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
                    {
                        cb_SelData.SelectedIndex = 0;
                    }
                }

            }

            // may want to remove one of the y axis while scrolling if easy
            if (timer_ScrollData.Enabled) // we may be scrolling
            {
                /* 
                int new_index=0;
                int new_bits = 0;
                GetRecordIndex(ref new_index, ref new_bits);
                if(new_index == iScrolling)
                {
                    ScrollBits = new_bits;
                }
                */
            }
        }

        // the item selected in the combo drop down box:  need location in database
        // also need the index to the log file in the list box
        private int GetRecordIndex(ref int irec, ref int iBit)
        {
            int i = cb_SelData.SelectedIndex;
            if (i < 0) return -1;
            irec = iLocRecSelected[i];
            iBit = bLocRecSelected[i];
            return i;
        }

        private void btn_ShowData_Click(object sender, EventArgs e)
        {
            bAllowCallback = true;  // allow combo box to show data when changed
            PlotAtOnce();
        }

        // return the index to the list box as it might need to be restored
        public int PlotAtOnce()
        {
            int i = 0;
            int j = 0;
            int k = GetRecordIndex(ref i, ref j);
            CreateThreeSeries(i, j);
            return k;
        }


        private void btn_Pause_Click(object sender, EventArgs e)
        {
            timer_ScrollData.Enabled = !timer_ScrollData.Enabled;
            btn_Pause.Text = timer_ScrollData.Enabled ? "Pause" : "Un-Pause";
        }

        private void btn_ScrollData_Click(object sender, EventArgs e)
        {

            if (timer_ScrollData.Enabled) // but may be paused!
            {
                ClearScrolling(); // this disables timer
                return;
            }
            if(btn_Pause.Text == "Un-Pause")
            {
                btn_Pause.Text = "Pause";
                ClearScrolling();
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


        
        private void gtv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool bLast = bAllowCallback;
            bAllowCallback = false;
            CountGraphsWanted();
            cb_SelData.SelectedIndex = OneRecSelIndex;
            bAllowCallback = bLast;
        }



        private void cb_SelData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bAllowCallback)
            {
                PlotAtOnce();
                OneRecSelIndex = cb_SelData.SelectedIndex;
            }
        }

        private void nudScollCnt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdvFilter_Click(object sender, EventArgs e)
        {

            AdvFilter adfForm = new AdvFilter(ref MyAdvFilter);
            adfForm.ShowDialog();
            adfForm.Dispose();
            if (MyAdvFilter.strPhrase != "")
            {
                string strTemp = (MyAdvFilter.bContains ? "contains " : " does not contain") + MyAdvFilter.strPhrase;
                lblFilterString.Text = strTemp;
                cbUseAdvFilter.Enabled = true;
            }
            else
            {
                cbUseAdvFilter.Checked = false;
                cbUseAdvFilter.Enabled = false;
            }
            cbUseAdvFilter.Checked |= MyAdvFilter.bOKreturn;
        }

        private void btn_invertFilter_Click(object sender, EventArgs e)
        {
            if (OneRec == null) return;  // no file selected yet
            MyAdvFilter.bContains = !MyAdvFilter.bContains;
            HideData(false);
            PLotTheThreeSeries();
        }

        private void cbUseAdvFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (OneRec == null) return;  // no file selected yet
            if (cbUseAdvFilter.Checked)
                HideData(false);
            else HideData(true); // this unhides
            PLotTheThreeSeries();
        }

        // lookup the project name and get the path to the filename
        private string GetPathFromName(string strPN)
        {
            foreach (cLogFileInfo lfi in alr)
            {
                if (lfi.strName == strPN)
                {
                    return lfi.strPath;
                }
            }
            return "";
        }

        private void btn_NotepadFile_Click(object sender, EventArgs e)
        {
            string strPath = GetPathFromName(cb_SelData.SelectedItem.ToString());
            Process.Start("notepad.exe", strPath);
        }
    }
}
