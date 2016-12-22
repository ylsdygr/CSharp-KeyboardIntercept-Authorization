using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ForAuthorization
{
    class FunctionsIndex
    {
        /// <summary>
        /// 授权记录生成器
        /// </summary>
        /// <param name="authorizedUserName"></param>
        /// <param name="calcCount"></param>
        /// <returns></returns>
        public string authorizedKeysGenerator(string authorizedUserName, int calcCount)
        {
            int nameNumber = authorizedUserName.Length;
            string authorizedKey = String.Empty;
            authorizedKey = randomValuesGenerator(18);
            string nameCharacters = nameNumber.ToString("x2");
            authorizedKey += nameCharacters;
            authorizedKey += authorizedUserName;
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
            string countString = calcCount.ToString("x2");
            int zeroCount = 8 - countString.Length;
            string complementZero = "";
            for (int i = 0; i < zeroCount; i++) {
                complementZero += "0";
            }
            countString = complementZero + countString;
            authorizedKey += countString;
            authorizedKey += randomValuesGenerator(8);
            authorizedKey += this.calculateCheckCode(authorizedKey).ToString();
            return authorizedKey;
        }
        /// <summary>
        /// 计算给定字符串的MD5值
        /// </summary>
        /// <param name="goingCalculatedKey"></param>
        /// <returns></returns>
        public string calcMD5(string goingCalculatedKey)
        {
            MD5 thisMD5 = MD5.Create();
            byte[] thisByte = thisMD5.ComputeHash(Encoding.UTF8.GetBytes(goingCalculatedKey));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < thisByte.Length; i++) {
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
    }
}
