using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoincLogAnalyzer
{
    public class cLogFileData
    {
        public double dTimeCompleted; // unix timestamp
        public double dEstimateRT;    // estimated runtime
        public double dElapsedCPU;    //ct
        public double dElapsedTime;   //et
        public string strTaskName;
        public bool bUserHide;          // point hidden as user used a filter
        public bool bBadPoint;          // anytime 0 is found for wall clock time
    }

    public class cLogFileInfo
    {
        public string strName;
        public bool bFoundInAFL;   //  if in the original table in boinc folder
        public int iFoundInAFL;    //  index into treeview where project is located
        public UInt64 TimeZero;    // start here rest of time is relative
        public bool bSelected;
        public int iNumErrors;  // any time that is 0 or less is an error
        public double dYElapsedTime;   //et largest value and used for y axis
        public double dYEstimateRT;    // estimated runtime
        public double dYElapsedCPU;    //ct
        public List<cLogFileData> RawData;
        public void init(string sName, bool bSel, bool bFound, int iFound)
        {
            strName = sName;
            bSelected = bSel;
            bFoundInAFL = bFound;
            iFoundInAFL = iFound;
            iNumErrors = 0;
            dYElapsedTime = 0;
            dYEstimateRT = 0;
            dYElapsedCPU = 0;
            RawData = new List<cLogFileData>();
        }
    }
    public class cProjectNameRec
    {
        public string StrUrl;
        public string StrName;
        public string StrWebName;
        public bool bUnknown;
    }

    public class cProjectNames
    {
        public int NumUnknown;
        public List<cProjectNameRec>pnr;
        public void init()
        {
            pnr = new List<cProjectNameRec>();
            NumUnknown = 0;
        }
        public void AddKnownNames(string sUrl, string sName, string sWebName)
        {
            cProjectNameRec newPNR = new cProjectNameRec();
            newPNR.StrUrl = sUrl;
            newPNR.StrName = sName;
            newPNR.StrWebName = sWebName;
            newPNR.bUnknown = false;
            pnr.Add(newPNR);
        }
        public void AddUnknownNames(string sUrl, string sName)
        {
            cProjectNameRec newPNR = new cProjectNameRec();
            newPNR.StrUrl = sUrl;
            newPNR.StrName = sName;
            newPNR.StrWebName = sName;
            newPNR.bUnknown = true;
            pnr.Add(newPNR);
            NumUnknown++;
        }
    }

}
