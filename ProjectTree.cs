using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace BoincLogAnalyzer
{

    class ProjectTree
    {
        XmlNode xmlnode;
        TreeView tv;

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }



    public bool ReadProjectList(string str_DataDir, ref cProjectNames pNames)
        {
            int j=0;

            //           FileStream fs = new FileStream(str_DataDir + "\\acct_mgr_request.xml", FileMode.Open, FileAccess.Read);
            FileStream fs = new FileStream(str_DataDir + "\\all_projects_list.xml", FileMode.Open, FileAccess.Read);

            XmlDocument dom = new XmlDocument();
            dom.Load(fs);
            tv = new TreeView();
            tv.Nodes.Clear();
            xmlnode = dom.ChildNodes[1];
            tv.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
            TreeNode tNode;
            tNode = tv.Nodes[0];
            AddNode(xmlnode, tNode);
            for(int i = 0; i < tNode.Nodes.Count;i++)
            {
                if(tNode.Nodes[i].Text == "project")
                {

                    string strVal = tNode.Nodes[i].Nodes[0].FirstNode.Text;
                    string strUrl = tNode.Nodes[i].Nodes[2].FirstNode.Text;
                    string strWeb = tNode.Nodes[i].Nodes[3].FirstNode.Text;

                    /*
                                        m = new TreeNode();
                                        n = new TreeNode();
                                        j++;
                                        m.Name = j.ToString();
                                        m.Text = strVal;
                                        n.Text = strUrl;
                                        m.Nodes.Add(n);
                                        tv1.Nodes.Add(m);
                    */
                    pNames.AddKnownNames(strUrl, strVal, strWeb);
                }
            }

            return true;
        }

        public void FormTreeFromNames(ref TreeView tv1,ref cProjectNames pNames)
        {
            TreeNode m, n;
            int j = 1;
            tv1.Nodes.Clear();
            foreach(cProjectNameRec pnr in pNames.pnr)
            {
                m = new TreeNode();
                n = new TreeNode();
                j++;
                m.Name = j.ToString();
                m.Text = pnr.StrName;
                m.Tag = pnr.bUnknown ? "unk" : "known";
                n.Text = pnr.StrUrl;
                //n.Tag = pnr.bUnknown ? "unk" : "known";
                m.Nodes.Add(n);
                n = new TreeNode();
                n.Text = pnr.StrWebName;
                m.Nodes.Add(n);
                tv1.Nodes.Add(m);
            }
        }

    }
}
