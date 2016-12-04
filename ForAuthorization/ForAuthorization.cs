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

        public ForAuthorization()
        {
            InitializeComponent();
            //RemoveMenu(GetSystemMenu(Handle, IntPtr.Zero), 0, MF_BYPOSITION | MF_REMOVE);    
        }
        private void Single_Click(object sender, EventArgs e)
        {
            string goingToUseName = String.Empty;
            if (string.Equals(Name_TextBox.Text, ""))
            {
                Notice.Text = "请输入用户名,不超过20个字符,请勿使用中文";
                return;
            }
            else {
                int nameLength = Name_TextBox.Text.Length;
                TextBox_NewAuthorizedString.Text = this.authorizedKeysGenerator(nameLength, Name_TextBox.Text, 0);
                TextBox_NewAuthorizedKey.Text = this.calcMD5(TextBox_NewAuthorizedString.Text);
                Notice.Text = "已生成新的授权序列及授权码,请使用按钮复制";
            }
            /*
            try {
                if (File.Exists())
            }
            catch (IOException e) {
                //System.Console.WriteLine(e.ToString());
            }*/
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
            System.Random random = new Random();
            for (int i = 0; i < randomBits; i++)
            {
                number = random.Next();
                number = number % 62;
                if (number < 10)
                {
                    number += 48;
                }
                else if (number > 9 && number < 36)
                {
                    number += 55;
                }
                else
                {
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
            foreach (char c in calcedString)
            {
                calcCheckSum += (int)c;
            }
            checkCode = (char)((calcCheckSum % 26) + 65);
            return checkCode;
        }

        private void BTN_CopyNewString_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetDataObject(TextBox_NewAuthorizedString.Text);
        }

        private void BTN_CopyKey_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetDataObject(TextBox_NewAuthorizedKey.Text);
        }

        private void Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            string pat = @"[\u4e00-\u9fff]";
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(pat);
            System.Text.RegularExpressions.Match mch = rg.Match(Name_TextBox.Text);
            if (!mch.Success)
                return;
            Name_TextBox.Text = "";
            Notice.Text = "不能输入中文字符";
        }
    }
}
