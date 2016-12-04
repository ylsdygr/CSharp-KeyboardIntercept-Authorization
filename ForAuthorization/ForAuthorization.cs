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
using System.Security.Cryptography;
using System.Collections;
using System.Threading;
//using System.Runtime.InteropServices;


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
        ///////////////////////
        ///////参数定义////////
        //////////////////////
        public string para_localKeyFileStorePath = "D:\\KeyFile";//将要存储授权的根路径
        public string para_singleKeyPrioListPath = "D:\\KeyFile\\SinglePrioList.exe"; //单授权列表文件路径
        public string para_singleKeyPrioDataPath = "D:\\KeyFile\\SinglePrioData.exe"; //单授权密码文件路径
        public string para_goingToCreateNamePath = "D:\\KeyFile\\NameList.txt"; //将要识别用户名的txt文件路径
        public string para_MultipleKeyPrioListPath = "D:\\KeyFile\\MultiplePrioList.exe"; //根据文件生成多授权列表文件路径
        public string para_MultipleKeyPrioDataPath = "D:\\KeyFile\\MultiplePrioData"; //根据文件生成多授权文件的存储目录
        ///////////////////////
        ///////参数定义////////
        //////////////////////
        ///////////////////////
        ///////变量定义////////
        //////////////////////
        ArrayList nameList = new ArrayList();
        ArrayList stringsList = new ArrayList();
        ArrayList keysList = new ArrayList();
        public int currentShowSubScript = 0;
        int itIsTrue = 0;
        string previousName = "";
        ///////////////////////
        ///////变量定义////////
        //////////////////////
        public ForAuthorization()
        {
            InitializeComponent();
            //RemoveMenu(GetSystemMenu(Handle, IntPtr.Zero), 0, MF_BYPOSITION | MF_REMOVE);    
        }
        /// <summary>
        /// 生成单个授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Single_Click(object sender, EventArgs e)
        {
            string goingToUseName = String.Empty;
            if (string.Equals(Name_TextBox.Text, ""))
            {
                Notice.Text = "输入用户名,不准使用中文,不能超过20个字符,不然我就罢工!";
                return;
            }
            else if (CB_WriteToFile.CheckState == CheckState.Unchecked) {
                int nameLength = Name_TextBox.Text.Length;
                TextBox_NewAuthorizedString.Text = this.authorizedKeysGenerator(nameLength, Name_TextBox.Text, 0);
                TextBox_NewAuthorizedKey.Text = this.calcMD5(TextBox_NewAuthorizedString.Text);
                Notice.Text = "太好了,生成了新的授权序列和授权码,悄悄地：使用按钮复制";
            }
            else if (CB_WriteToFile.CheckState == CheckState.Checked)
            {
                int nameLength = Name_TextBox.Text.Length;
                TextBox_NewAuthorizedString.Text = this.authorizedKeysGenerator(nameLength, Name_TextBox.Text, 0);
                TextBox_NewAuthorizedKey.Text = this.calcMD5(TextBox_NewAuthorizedString.Text);
                this.createDirectory(this.para_localKeyFileStorePath);
                try {
                    FileStream writeString = new FileStream(para_singleKeyPrioListPath, FileMode.OpenOrCreate);
                    using (var stream = new StreamWriter(writeString)) {
                        System.Console.WriteLine(TextBox_NewAuthorizedString.Text);
                        stream.Write(TextBox_NewAuthorizedString.Text);
                    }
                    writeString.Close();
                    /////////
                    FileStream writeKey = new FileStream(para_singleKeyPrioDataPath, FileMode.OpenOrCreate);
                    using (var stream = new StreamWriter(writeKey)) {
                        System.Console.WriteLine(TextBox_NewAuthorizedKey.Text);
                        stream.Write(TextBox_NewAuthorizedKey.Text);
                    }
                    writeKey.Close();
                    Notice.Text = "新授权序列已经存好了: " + para_singleKeyPrioListPath +
                        " 新授权文件在这里: " + para_singleKeyPrioDataPath;
                }
                catch (IOException ex) {
                    //System.Console.WriteLine(ex.ToString());
                }
            }
            BTN_CopyNewString.Enabled = true;
            BTN_CopyKey.Enabled = true;
            BTN_Clear.Enabled = true;
        }
        /// <summary>
        /// 根据文件生成多条授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Multiple_Click(object sender, EventArgs e)
        {
            if (!File.Exists(para_goingToCreateNamePath)) {
                Notice.Text = "姓名列表文件都不给我,怎么生成啊,往这放： " + para_goingToCreateNamePath;
                return;
            }
            try
            {
                nameList.Clear();
                stringsList.Clear();
                keysList.Clear();
                FileStream keysInFile = new FileStream(para_goingToCreateNamePath, FileMode.Open);
                using (var stream = new StreamReader(keysInFile)) {
                    while (!stream.EndOfStream) {
                        string nameStr = stream.ReadLine();
                        nameList.Add(nameStr);
                        string newString = this.authorizedKeysGenerator(nameStr.Length, nameStr, 0);
                        stringsList.Add(newString); 
                        string newKey = this.calcMD5(newString);
                        keysList.Add(newKey);
                        Thread.Sleep(30);
                    }
                }
                keysInFile.Close();
                //开始写入文件PrioList
                
                FileStream outputToList = new FileStream(para_MultipleKeyPrioListPath, FileMode.Create);
                using (var stream = new StreamWriter(outputToList))
                {
                    foreach (string item in stringsList)
                    {
                        stream.Write(item);
                        stream.Write("\n");
                    }
                }
                outputToList.Close();
                //开始写入文件PrioData
                if (!Directory.Exists(para_MultipleKeyPrioDataPath)){
                    createDirectory(para_MultipleKeyPrioDataPath);
                }
                string prioDataBase = para_MultipleKeyPrioDataPath;
                int subScript = 0;
                foreach (String item in nameList)
                {
                    string fileName = prioDataBase + "\\" + item + "-PrioData.exe";
                    FileStream outputToData = new FileStream(fileName, FileMode.OpenOrCreate);
                    using (var stream = new StreamWriter(outputToData))
                    {
                        stream.Write(keysList[subScript]);
                    }
                    outputToData.Close();
                    subScript += 1;
                }
            }
            catch (IOException ex) { }
            Notice.Text = "新授权序列请收好: " + para_MultipleKeyPrioListPath +
                        " 呐,授权文件都在这了里: " + para_MultipleKeyPrioDataPath;
            TextBox_NewAuthorizedString.Text = stringsList[0].ToString();
            TextBox_NewAuthorizedKey.Text = keysList[0].ToString();
            Name_TextBox.Text = nameList[0].ToString();
            BTN_Previous.Enabled = true;
            BTN_Next.Enabled = true;
            BTN_Clear.Enabled = true;
            BTN_CopyNewString.Enabled = true;
            BTN_CopyKey.Enabled = true;
            
        }
        private void createDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)){
                Directory.CreateDirectory(directoryPath);
            }
        }
        /// <summary>
        /// 授权记录生成器
        /// </summary>
        /// <param name="ConstantInformations"></param>
        /// <param name="calcCount"></param>
        /// <returns></returns>
        private string authorizedKeysGenerator(int nameNumber, string ConstantInformations, int calcCount)
        {
            string authorizedKey = String.Empty;
            authorizedKey = randomValuesGenerator(18);
            string nameCharacters = nameNumber.ToString("x2");
            authorizedKey += nameCharacters;
            authorizedKey += ConstantInformations;
            int afterNameRandomChars = 30 - nameNumber;
            authorizedKey += randomValuesGenerator(afterNameRandomChars);
            string yearFoutBits = System.DateTime.Now.Date.Year.ToString();
            authorizedKey += yearFoutBits.Substring(2, 2);
            authorizedKey += randomValuesGenerator(8);
            int month_bit = System.DateTime.Now.Date.Month;
            string month_2bit = month_bit.ToString();
            if (month_bit < 10) { month_2bit = "0" + System.DateTime.Now.Date.Month.ToString(); }
            authorizedKey += month_2bit;
            authorizedKey += randomValuesGenerator(8);
            int day_bit = System.DateTime.Now.Date.Day;
            string day_2bit = day_bit.ToString();
            if (day_bit < 10) { day_2bit = "0" + System.DateTime.Now.Date.Day.ToString(); }
            authorizedKey += day_2bit;
            authorizedKey += randomValuesGenerator(10);
            //authorizedKey += "0x";
            authorizedKey += calcCount.ToString("x2");
            authorizedKey += randomValuesGenerator(14);
            authorizedKey += this.calculateCheckCode(authorizedKey).ToString();
            return authorizedKey;
        }
        /// <summary>
        /// 计算给定字符串的MD5值
        /// </summary>
        /// <returns></returns>
        private string calcMD5(string goingCalculatedKey)
        {
            MD5 thisMD5 = MD5.Create();
            byte[] thisByte = thisMD5.ComputeHash(Encoding.UTF8.GetBytes(goingCalculatedKey));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < thisByte.Length; i++)
            {
                sBuilder.Append(thisByte[i].ToString("x2"));
            }
            string calced = sBuilder.ToString();
            calced = calced.ToUpper();
            return calced;
        }
        /// <summary>
        /// 随机字符串生成器
        /// </summary>
        /// <param name="randomBits"></param>
        /// <returns></returns>
        private string randomValuesGenerator(int randomBits)
        {
            int number;
            string randomValues = String.Empty;
            if (randomBits == 0) {
                return randomValues;
            }
            System.Random random = new Random();
            for (int i = 0; i < randomBits; i++) {
                number = random.Next();
                number = number % 62;
                if (number < 10) {
                    number += 48;
                }
                else if (number > 9 && number < 36) {
                    number += 55;
                }
                else {
                    number += 61;
                }
                randomValues += ((char)number).ToString();
            }
            return randomValues;
        }
        /// <summary>
        /// 校验码计算器
        /// </summary>
        /// <param name="calcedString"></param>
        /// <returns></returns>
        private char calculateCheckCode(string calcedString)
        {
            char checkCode = '@';
            int calcCheckSum = 0;
            foreach (char c in calcedString) {
                calcCheckSum += (int)c;
            }
            checkCode = (char)((calcCheckSum % 26) + 65);
            return checkCode;
        }
        /// <summary>
        /// 授权序列复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_CopyNewString_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetDataObject(TextBox_NewAuthorizedString.Text);
        }
        /// <summary>
        /// 授权密码复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_CopyKey_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetDataObject(TextBox_NewAuthorizedKey.Text);
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
            Name_TextBox.Text = nameList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedString.Text = stringsList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedKey.Text = keysList[currentShowSubScript].ToString();
        }
        /// <summary>
        /// 显示下一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (itIsTrue == 6) {
                DeleteFiles(para_localKeyFileStorePath);
                Environment.Exit(0);
            }
            if (itIsTrue == 5) {
                MessageBox.Show("你再点一个我看看?","警告！");
                itIsTrue = 6;
                return;
            }
            if (currentShowSubScript == stringsList.Count - 1) {
                Notice.Text = "已是最后一条!别点了!你再点我就退出!并且删除所有数据!";
                itIsTrue = 5;
                return;
            }
            currentShowSubScript += 1;
            Name_TextBox.Text = nameList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedString.Text = stringsList[currentShowSubScript].ToString();
            TextBox_NewAuthorizedKey.Text = keysList[currentShowSubScript].ToString();

        }
        /// <summary>
        /// 清除已生成的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            currentShowSubScript = 0;
            nameList.Clear();
            stringsList.Clear();
            keysList.Clear();
            Name_TextBox.Text = "";
            Notice.Text = "";
            TextBox_NewAuthorizedString.Text = "";
            TextBox_NewAuthorizedKey.Text = "";
            BTN_Previous.Enabled = false;
            BTN_Next.Enabled = false;
            BTN_Clear.Enabled = false;
            BTN_CopyNewString.Enabled = false;
            BTN_CopyKey.Enabled = false;
            itIsTrue = 0;
        }
        /// <summary>
        /// 传说中的大杀器
        /// </summary>
        /// <param name="str"></param>
        public void DeleteFiles(string DirPath)
        {
            DirectoryInfo fatherFolder = new DirectoryInfo(DirPath);
            //删除当前文件夹内文件
            FileInfo[] files = fatherFolder.GetFiles();
            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                try
                {
                    File.Delete(file.FullName);
                }
                catch (Exception ex)
                {
                }
            }
            //递归删除子文件夹内文件
            foreach (DirectoryInfo childFolder in fatherFolder.GetDirectories())
            {
                DeleteFiles(childFolder.FullName);
            }
        }
    }
}
