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
using System.Collections;
//以下两条引用在嵌入dll时使用
using System.Reflection;
using System.Resources;
using System.Threading;

namespace ForAuthorization
{
    public partial class ForAuthorization : Form
    {
        /*
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")] //导入API函数
        extern static System.IntPtr GetSystemMenu(System.IntPtr hWnd, System.IntPtr bRevert);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        static int MF_BYPOSITION = 0x400;
        static int MF_REMOVE = 0x1000;
         * */
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            ResourceManager rm = new ResourceManager(GetType().Namespace + ".Properties.Resources", Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return Assembly.Load(bytes);
        }
        public ForAuthorization()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            //RemoveMenu(GetSystemMenu(Handle, IntPtr.Zero), 0, MF_BYPOSITION | MF_REMOVE);    
        }
        ////////////程序内使用变量//////////////
        string previousName = "";
        string currentKeySerial = "";
        string currentKeyCode = "";
        ArrayList goingToAuthorizedNameList = new ArrayList();
        ArrayList authorizedSerials = new ArrayList();
        ArrayList authorizedCodes = new ArrayList();
        public int currentShowSubScript = 0;
        int itIsTrue = 0;
        ParametersDefine PD = new ParametersDefine();
        ////////////程序内使用变量//////////////
        
        /// <summary>
        /// 生成单个授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Single_Click(object sender, EventArgs e)
        {
            if (string.Equals(Name_TextBox.Text, "")) {
                Notice.Text = "输入用户名,不准使用中文,不能超过20个字符,不然我就罢工!";
                return;
            }
            ProcessManager PM = new ProcessManager();
            PM.generateANewKeySerialAndCodeProcess(Name_TextBox.Text, ref currentKeySerial, ref currentKeyCode);
            TextBox_NewAuthorizedSerial.Text = currentKeySerial;
            TextBox_NewAuthorizedKeyCode.Text = currentKeyCode;
            Notice.Text = "太好了,生成了新的授权序列和授权码,悄悄地：使用按钮复制";
            if (CB_WriteToFile.CheckState == CheckState.Checked)
            {
                int writeResult = PM.writeOneKeySerialAndCodeToFileProcess(PD.para_localKeyFileStorePath,PD.para_singleKeyPrioListPath,
                    PD.para_singleKeyPrioDataPath,this.currentKeySerial,this.currentKeyCode);
                if (writeResult == 0) {
                    Notice.Text = "唉哟,你好幸运,竟然写入文件失败了!快去买彩票吧!";
                }else{
                    Notice.Text = "新授权序列已经存好了: " + PD.para_singleKeyPrioListPath +
                " 新授权文件在这里: " + PD.para_singleKeyPrioDataPath;
                }
                
            }
            LB_CurrentNUM.Text = "1";
            LB_AllCount.Text = "1";
            BTN_OneToDB.Enabled = true;
            BTN_MulToDB.Enabled = true;
            BTN_Clear.Enabled = true;
            Name_TextBox.ReadOnly = true;
        }
        /// <summary>
        /// 根据文件生成多条授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Multiple_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PD.para_goingToCreateNamePath)) {
                Notice.Text = "姓名列表文件都不给我,怎么生成啊,往这放： " + PD.para_goingToCreateNamePath;
                return;
            }
            goingToAuthorizedNameList.Clear();
            authorizedSerials.Clear();
            authorizedCodes.Clear();
            ProcessManager PM = new ProcessManager();
            int executeResult = PM.readedArrayListFromFileProcess(PD.para_goingToCreateNamePath,ref goingToAuthorizedNameList);
            if (executeResult == 0) { Notice.Text = "姓名文件有问题，小二，去查一下！"; }
            executeResult = PM.generateMultipleKeySerialCodeProcess(goingToAuthorizedNameList,ref authorizedSerials,ref authorizedCodes);
            if (executeResult == 0){Notice.Text = "哎哟，好像出了点小问题！";return ;}
            if (CB_WriteToFile.CheckState == CheckState.Checked)
            {
                int writeResult = PM.writeMultipleKeysToFileProcess(PD.para_MultipleKeyPrioListPath,authorizedSerials,
                    PD.para_MultipleKeyPrioDataPath,authorizedCodes, goingToAuthorizedNameList);
                if (writeResult == 0) {
                    Notice.Text = "唉哟,你好幸运,竟然写入文件失败了!快去买彩票吧!";
                }else{
                    Notice.Text = "新授权序列请收好: " + PD.para_MultipleKeyPrioListPath +
                        " 呐,授权文件都在这了里: " + PD.para_MultipleKeyPrioDataPath;
                }
                
            }
            TextBox_NewAuthorizedSerial.Text = authorizedSerials[0].ToString();
            TextBox_NewAuthorizedKeyCode.Text = authorizedCodes[0].ToString();
            Name_TextBox.Text = goingToAuthorizedNameList[0].ToString();
            LB_CurrentNUM.Text = "1";
            LB_AllCount.Text = authorizedSerials.Count.ToString();
            BTN_Previous.Enabled = true;
            BTN_Next.Enabled = true;
            BTN_Clear.Enabled = true;
            BTN_OneToDB.Enabled = true;
            BTN_MulToDB.Enabled = true;
            Name_TextBox.ReadOnly = true;
            BTN_MulToDB.Enabled = true;
        }
        /// <summary>
        /// 在单条入库功能与姓名文本框可编辑之间做互斥
        /// 防止在修改了用户名后入库单条的姓名错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_Change_Click(object sender, EventArgs e)
        {
            Name_TextBox.ReadOnly = false;
            BTN_OneToDB.Enabled = false;
            Notice.Text = "重新编辑授权姓名,此时无法再进行当前授权码地入库.";
        }
        /// <summary>
        /// 将当前显示授权码录入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_OneToDB_Click(object sender, EventArgs e)
        {
            ProcessManager PM = new ProcessManager();
            int wirteResult = PM.writeCurrentKeyCodeToDBProcess(PD.para_DatabaseIP,PD.para_DatabaseUser,PD.para_DatabasePWD,
                PD.para_DatabaseName,PD.para_DatabasePort, Name_TextBox.Text, TextBox_NewAuthorizedSerial.Text, TextBox_NewAuthorizedKeyCode.Text);
            if (wirteResult == 0) {
                Notice.Text = "Good Luck!Buddy.^_^";
            }
            Notice.Text = "好失望,竟然入库成功了!";
            BTN_OneToDB.Enabled = false;
        }
        /// <summary>
        /// 将此次批量生成的授权录入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_MulToDB_Click(object sender, EventArgs e)
        {
            if (goingToAuthorizedNameList.Count >= 20) {
                Notice.Text = "你敢一次再多添加一些吗?一次最多20个";
                return;
            }
            ProcessManager PM = new ProcessManager();
            int wirteResult = PM.writeMultipleKeyCodeToDBProcess(PD.para_DatabaseIP, PD.para_DatabaseUser, PD.para_DatabasePWD,
                PD.para_DatabaseName, PD.para_DatabasePort, goingToAuthorizedNameList, authorizedSerials, authorizedCodes);
            if (wirteResult == 0)
            {
                Notice.Text = "Good Luck!Buddy.^_^";
            }
            Notice.Text = "好失望,竟然入库成功了!";
            BTN_MulToDB.Enabled = false;
        }
        /// <summary>
        /// 姓名文件框输入检测，不允许输入中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            string pat = @"[\u4e00-\u9fff]";
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(pat);
            System.Text.RegularExpressions.Match mch = rg.Match(Name_TextBox.Text);
            if (!mch.Success) {
                if (Name_TextBox.Text.Length == 21) {
                    Notice.Text = "记不住嘛,都超过20个字符了,你还想输!";
                    Name_TextBox.Text = previousName;
                }
                previousName = Name_TextBox.Text;
                return;
            }
            if (itIsTrue >= 1) {
                if (itIsTrue == 2) { for (int i = 0; i <= 30; i++) { MessageBox.Show("专治各种不服!有本事你别点确定!","心里默念我错了!",MessageBoxButtons.OK); } }
                if (itIsTrue == 1) {
                    MessageBox.Show("专治各种不服!你再输中文看我怎么收拾你!");
                    itIsTrue = 2; 
                }
            }
            else{
                Notice.Text = "不能输入中文,你造吗?再点我就弹窗口气你了!";
                itIsTrue = 1;
            }
            Name_TextBox.Text = previousName;
        }
        /// <summary>
        /// 显示上一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Previous_Click(object sender, EventArgs e)
        {
            if (currentShowSubScript == 0)
            {
                Notice.Text = "你有病啊!你再别点了!已经是第一条了!";
                return;
            }
            currentShowSubScript -= 1;
            LB_CurrentNUM.Text = (currentShowSubScript + 1).ToString();
            Name_TextBox.Text = goingToAuthorizedNameList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedSerial.Text = authorizedSerials[currentShowSubScript].ToString();
            TextBox_NewAuthorizedKeyCode.Text = authorizedCodes[currentShowSubScript].ToString();
            BTN_OneToDB.Enabled = true;
        }
        /// <summary>
        /// 显示下一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (itIsTrue == 6) {
                FilesOperator FO = new FilesOperator();
                FO.DeleteFiles(PD.para_localKeyFileStorePath);
                Environment.Exit(0);
            }
            if (itIsTrue == 5) {
                MessageBox.Show("你再点一个我看看?","警告！");
                itIsTrue = 6;
                return;
            }
            if (currentShowSubScript == authorizedSerials.Count - 1) {
                Notice.Text = "已是最后一条!别点了!你再点我就退出!并且删除所有数据!";
                itIsTrue = 5;
                return;
            }
            currentShowSubScript += 1;
            LB_CurrentNUM.Text = (currentShowSubScript + 1).ToString();
            Name_TextBox.Text = goingToAuthorizedNameList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedSerial.Text = authorizedSerials[currentShowSubScript].ToString();
            TextBox_NewAuthorizedKeyCode.Text = authorizedCodes[currentShowSubScript].ToString();
            BTN_OneToDB.Enabled = true;

        }
        /// <summary>
        /// 清除已生成的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            currentShowSubScript = 0;
            goingToAuthorizedNameList.Clear();
            authorizedSerials.Clear();
            authorizedCodes.Clear();
            Name_TextBox.Text = "";
            Notice.Text = "";
            TextBox_NewAuthorizedSerial.Text = "";
            TextBox_NewAuthorizedKeyCode.Text = "";
            BTN_Previous.Enabled = false;
            BTN_Next.Enabled = false;
            BTN_Clear.Enabled = false;
            BTN_OneToDB.Enabled = false;
            BTN_MulToDB.Enabled = false;
            Name_TextBox.ReadOnly = false;
            itIsTrue = 0;
            LB_CurrentNUM.Text = "NUM";
            LB_AllCount.Text = "Count";
        }
    }
}
