using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

//1519063720 ue 2918.681295 ct 659.250000 fe 525000000000000
//nm LATeah0054L_1084.0_0_0.0_13540195_2 et 666.475706 es 0
/* 
	Datestamp		Unix timestamp at completion
[ue]	Estimated runtime	BOINC Client estimate (seconds)
[ct]	CPU time		Measured CPU runtime at completion (seconds)
[fe]	Estimated FLOPs count	From project (integer)
[nm]	Task name		From project
[et]	Elapsed time 		Wallclock runtime at completion (seconds)
*/


namespace BoincLogAnalyzer
{
    public partial class BoincLogAnalyzer : Form
    {
        private System.Windows.Forms.OpenFileDialog ofd_history;
        private ProjectTree MyPT;
        public System.DateTime dt_1970 = new System.DateTime(1970, 1, 1);

        public cProjectNames ProjectNameTable;
        public List<cLogFileInfo> AllLogRecords;
        private List<string> PathLogFiles;


        public enum eShowType
        {
            eShowAllcol = 0,    // only one shown as collapsed (default)
            eShowAllexp = 1,    // these must match the "tag" in radio button
            eShowHis = 2,
            eShowUnk = 3,
            eShowStats = 4
        }
        public static eShowType ShowType = eShowType.eShowAllcol;

        private string GetSimpleDate(string sDT)
        {
            //Sun 06/09/2019 23:33:53.18 
            int i = sDT.IndexOf(' ');
            i++;
            int j = sDT.LastIndexOf('.');
            return sDT.Substring(i, j - i);
        }

        private void GetDataPath()
        {
            ofd_history = new OpenFileDialog();
            try
            {
                RegistryKey baseRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey key = baseRegistryKey.OpenSubKey("SOFTWARE\\Space Sciences Laboratory, U.C. Berkeley\\BOINC Setup", RegistryKeyPermissionCheck.ReadSubTree);
                if (key != null)
                {
                    Object o = key.GetValue("DATADIR");
                    if (o != null)
                    {
                        tb_BoincDataPath.Text = o.ToString();
                        ofd_history.DefaultExt = ".txt";
                        ofd_history.Filter = "Log Files|job_log_*.txt";
                        ofd_history.Multiselect = true;
                        ofd_history.InitialDirectory = tb_BoincDataPath.Text;
                    }
                }
            }
            catch (Exception ex)   
            {
                //react appropriately
            }
        }

        public BoincLogAnalyzer()
        {
            InitializeComponent();
            
            this.Text += " Build:" + Properties.Resources.BuildDate.ToString();
            GetDataPath();
            MyPT = new ProjectTree();
            ProjectNameTable = new cProjectNames();
            ProjectNameTable.init();
            MyPT.ReadProjectList(tb_BoincDataPath.Text, ref  ProjectNameTable);
            MyPT.FormTreeFromNames(ref tv, ref ProjectNameTable);
            tv.Show();
        }

        private void btn_FetchLogs_Click(object sender, EventArgs e)
        {            
            clb_lognames.Items.Clear();
            PathLogFiles = new List<string>();
            btn_RunAnal.Enabled = false;
            if (DialogResult.OK != ofd_history.ShowDialog())return;
            btn_RunAnal.Enabled = true;
            foreach(string strName in ofd_history.FileNames)
            {
                PathLogFiles.Add(strName);
                clb_lognames.Items.Add(strName.Replace(tb_BoincDataPath.Text, ""), true);
            }
            BuildNameTable();
        }

        public void GetTreeLayout()
        {
            foreach (RadioButton rb in gb_Reveal.Controls)
            {
                if (rb.Checked)
                {
                    ShowType = (eShowType)Convert.ToInt32(rb.Tag.ToString());
                    break;
                }
            }
        }

        public void RevealApps()
        {
            int i, j;
            GetTreeLayout();
            if(eShowType.eShowHis == ShowType)
            {
                MyPT.FormTreeFromNames(ref tv, ref ProjectNameTable);
                tv.Show();
            }
            foreach (TreeNode node in tv.Nodes)
            {
                if (ShowType == eShowType.eShowAllcol)
                    node.Collapse();
                if (ShowType == eShowType.eShowAllexp)
                    node.Expand();
            }
            if(ShowType == eShowType.eShowUnk)
            {
                //foreach(TreeNode tn in tv.Nodes)
                j = tv.Nodes.Count-1;
                for(i = j; i>= 0; i--)
                {
                    if (tv.Nodes[i].Tag.ToString() != "unk")
                    {
                        tv.Nodes[i].Remove();
                    }
                }
                tv.Show();
            }
            
        }

        private void rbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            RevealApps();
        }

        private void rbShowHis_CheckedChanged(object sender, EventArgs e)
        {
            RevealApps();
        }

        private void rbShowUnk_CheckedChanged(object sender, EventArgs e)
        {
            RevealApps();
        }

        private void rbShowStats_CheckedChanged(object sender, EventArgs e)
        {
            RevealApps();
        }

        private void rbExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            RevealApps();
        }

        private string GetProjectName(string sName, ref int iFound)
        {
            string strName;
            int i, j;
            iFound = -1;
            i = sName.IndexOf("job_log_");
            strName = sName.Substring(i + 8).Replace(".txt", "");
            i = strName.LastIndexOf('.');
            strName = strName.Substring(0, i);
            j = 0;
            foreach(TreeNode Tnode in tv.Nodes)
            {
                if(Tnode.FirstNode.Text.Contains(strName) ||
                    Tnode.FirstNode.NextNode.Text.Contains(strName))
                {
                    iFound = j;
                    return Tnode.Text;
                }
                j++;
            }
            return strName;
        }

        // convert data string to double precison but treat 0 or negative as error
        private double StrToDouble(string strIN, ref bool bError)
        {
            double dData = Convert.ToDouble(strIN);
            if(dData < 1.0 )
            {
                bError = true;
                dData = 1.0;    // so y log scale does not fail
            }
            return dData;
        }

        // this is basically a symbol table lookup
        // name is found and returned (not used here)
        // if not found then inserted NOT CHECKING FOR DUPS todo
        public void BuildNameTable()
        {
            bool bAnyUnknown = false;
            string strTemp;
            foreach (string strFN in ofd_history.FileNames)
            {
                int iFound = -1;
                GetProjectName(strFN, ref iFound);
                if(iFound < 0)
                {
                    int i = strFN.IndexOf("job_log_");
                    strTemp = strFN.Substring(i + 8).Replace(".txt", "");
                    ProjectNameTable.AddUnknownNames(strFN, strTemp);
                    bAnyUnknown = true;
                }
            }
            if(bAnyUnknown)
            {
                MyPT.FormTreeFromNames(ref tv, ref ProjectNameTable);
                tv.Show();
            }
        }


        /*1519063720 ue 2918.681295 ct 659.250000 fe 525000000000000
          nm LATeah0054L_1084.0_0_0.0_13540195_2 et 666.475706 es 0
        !!!NOTE THAT THE FILENAME HAS A SPACE WHICH MEANS I CANNOT USE SPLIT TO GET THE DATA!!!
        !!! also, es can be missing !!!
        1304720994 ue 938.591169 ct 347.570200 fe 24000000000000 nm 4020992 md5_loweralpha-numeric-symbol32-space#1-8_0_60000x500000 - 39747000000_0 et 360.131598
        */


/*
1272759891 ue 39812.500926 ct 29498.120000 fe 1821052114462310 nm ap_09oc06aa_B0_P0_00042_20100501_11249.wu_3 et 33044.911001
0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
          1         2         3         4         5         6         7         8         9         0         1    
*/

        private bool ParseLogLine(ref string[] RecOut, string strIn)
        {
            int iStart=0, iRecOut=0, iSize;
            List<int> StartLocs = new List<int>(6){
                strIn.IndexOf(" ue "),
                strIn.IndexOf(" ct "),
                strIn.IndexOf(" fe "),
                strIn.IndexOf(" nm "),
                strIn.IndexOf(" et "),
                strIn.IndexOf(" es ")
            };
            for(int i = 0; i < 5; i++)
            {
                iSize = StartLocs[i] - iStart;
                RecOut[iRecOut] = strIn.Substring(iStart, iSize);
                iStart += (4 + iSize);
                iRecOut += 2;
            }

            if (StartLocs[5] > 0)
            {
                iSize = StartLocs[5] - iStart;
                RecOut[iRecOut] = strIn.Substring(iStart, iSize);
                iStart += (4 + iSize);
                iRecOut += 2;
                RecOut[iRecOut] = strIn.Substring(iStart);
            }
            else
            {
                RecOut[iRecOut] = strIn.Substring(iStart);
                RecOut[12] = "0";
                return false;
            }
            return true;
        }

        private bool ParseLogs()
        {
            string[] LinesHistory;
            bool bError = false;
            bool bFound;
            int iFound ;
            string strProjNameShort; // name as best as we can find out
            string[] Record = "0 ue 2 ct 4 fe 6 nm WTF-OMG et 10 es 12".Split();
            foreach (string strFN in ofd_history.FileNames)
            {
                int iLineCnt = 0;
                cLogFileInfo lfi = new cLogFileInfo();
                LinesHistory = File.ReadAllLines(strFN);
                iFound = -1;
                strProjNameShort = GetProjectName(strFN, ref iFound);
                //Debug.Assert(iFound < 0);
                bFound = "unk" != tv.Nodes[iFound].Tag.ToString();
                lfi.init(strProjNameShort, strFN, true, bFound, iFound);

                bool bFirst = true;
                foreach (string strRecord in LinesHistory)
                {
                    bError = false;
                    string strTemp = strRecord.Trim();
                    //string[] Record = strTemp.Split(' '); crap - cannot do this due to WTF filename
                    ParseLogLine(ref Record, strTemp);
                    cLogFileData lfd = new cLogFileData();
                    UInt64 time_t_Completed;
                    try
                    {
                        if(bFirst)
                        {
                            bFirst = false;
                            lfi.TimeZero = Convert.ToUInt64(Record[0]);
                        }
                        time_t_Completed = Convert.ToUInt64(Record[0]) - lfi.TimeZero;
                        lfd.dTimeCompleted = Convert.ToDouble(time_t_Completed);
                        lfd.dEstimateRT = StrToDouble(Record[2],ref bError);
                        //lfi.dYEstimateRT = Math.Max(lfd.dEstimateRT, lfi.dYEstimateRT);
                        lfd.dElapsedCPU = StrToDouble(Record[4], ref bError);
                        //lfi.dYElapsedCPU = Math.Max(lfd.dElapsedCPU, lfi.dYElapsedCPU);
                        // no need for flops yet
                        lfd.strTaskName = Record[8];
                        lfd.dElapsedTime = StrToDouble(Record[10],ref bError);
                        //lfi.dYElapsedTime = Math.Max(lfd.dElapsedTime, lfi.dYElapsedTime);
                        lfd.bBadPoint = bError;

                        lfi.RawData.Add(lfd);
                        if (bError)
                            lfi.iNumErrors++;
                    }
                    catch
                    {
                        break;
                    }
                    iLineCnt++;
                }
                AllLogRecords.Add(lfi);
            }
            return true;
        }

        private void btn_RunAnal_Click(object sender, EventArgs e)
        {
            AllLogRecords = new List<cLogFileInfo>();
            bool bResult = ParseLogs();
            btn_PlotEVA.Enabled = bResult;
        }

        private void btn_PlotEVA_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < AllLogRecords.Count; i++)
                AllLogRecords[i].bSelected = false; // assume all not selected
            for (i = 0; i < clb_lognames.CheckedIndices.Count; i++)
            {
                int j = clb_lognames.CheckedIndices[i];
                AllLogRecords[j].bSelected = true;
            }
           cTimeGraph tg = new cTimeGraph();
           tg.TimeGraph(ref AllLogRecords);
           tg.ShowDialog();
           tg.Dispose();
        }

        private void clb_lognames_DoubleClick(object sender, EventArgs e)
        {
            string strSelected =PathLogFiles[clb_lognames.SelectedIndex];
            Process.Start("notepad.exe", strSelected);
        }



        private void btnAbout_Click(object sender, EventArgs e)
        {
            MyAbout myAbout = new MyAbout();
            myAbout.ShowDialog();
        }
    }
}
