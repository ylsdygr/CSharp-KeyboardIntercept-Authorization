using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;


namespace ForAuthorization
{
    class ProcessManager
    {
        /// <summary>
        /// 从文件中读取多行数据返回ArrayList过程
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="readedArrayList"></param>
        /// <returns></returns>
        public int readedArrayListFromFileProcess(string filePath, ref ArrayList readedArrayList)
        {
            FilesOperator PMFO = new FilesOperator();
            int readResult = PMFO.readMultipleLineFromAFile(filePath, ref readedArrayList);
            if (readResult == 0) { return 0; }
            return 1;
        }
        /// <summary>
        /// 产生单一套授权序列及授权码过程
        /// </summary>
        /// <param name="authorizedUserName"></param>
        /// <param name="newKeySerial"></param>
        /// <param name="newKeyCode"></param>
        /// <returns></returns>
        public int generateANewKeySerialAndCodeProcess(string authorizedUserName, ref string newKeySerial, ref string newKeyCode)
        {
            FunctionsIndex PMFI = new FunctionsIndex();
            newKeySerial = PMFI.authorizedKeysGenerator(authorizedUserName, 0);
            newKeyCode = PMFI.calcMD5(newKeySerial);
            return 1;
        }
        /// <summary>
        /// 产生多个授权序列及授权码过程
        /// </summary>
        /// <param name="nameList"></param>
        /// <param name="multipleKeySerial"></param>
        /// <param name="multipleKeyCode"></param>
        /// <returns></returns>
        public int generateMultipleKeySerialCodeProcess(ArrayList nameList, ref ArrayList multipleKeySerial, ref ArrayList multipleKeyCode)
        {
            FunctionsIndex PMFI = new FunctionsIndex();
            try {
                for (int i = 0; i < nameList.Count; i++) {
                    string TEMP_new_Serial = PMFI.authorizedKeysGenerator(nameList[i].ToString(), 0);
                    multipleKeySerial.Add(TEMP_new_Serial);
                    string TEMP_new_Code = PMFI.calcMD5(TEMP_new_Serial);
                    multipleKeyCode.Add(TEMP_new_Code);
                    Thread.Sleep(35);
                }
            }
            catch (Exception e) { return 0; }
            return 1;
        }
        /// <summary>
        /// 将一套授权码写入文件过程
        /// </summary>
        /// <param name="storePath"></param>
        /// <param name="keySerialFilePath"></param>
        /// <param name="keyCodeFilePath"></param>
        /// <param name="oneKeySerial"></param>
        /// <param name="oneKeyCode"></param>
        /// <returns></returns>
        public int writeOneKeySerialAndCodeToFileProcess(string storePath, string keySerialFilePath, string keyCodeFilePath,
            string oneKeySerial, string oneKeyCode)
        {
            FilesOperator PMFO = new FilesOperator();
            PMFO.createDirectory(storePath);
            int writeResult = PMFO.writeOneStringToFile(keySerialFilePath, oneKeySerial);
            if (writeResult == 0) { return 0; }
            writeResult = PMFO.writeOneStringToFile(keyCodeFilePath, oneKeyCode);
            if (writeResult == 0) { return 0; }
            return 1;
        }
        /// <summary>
        /// 将多行数据写入数据库过程
        /// </summary>
        /// <param name="goingToWriteMultipleFilePath"></param>
        /// <param name="goningToWriteKeySerials"></param>
        /// <param name="goingToWriteKeyCodeDirectory"></param>
        /// <param name="goingToWriteKeyCodes"></param>
        /// <param name="nameList"></param>
        /// <returns></returns>
        public int writeMultipleKeysToFileProcess(string goingToWriteMultipleFilePath,ArrayList goningToWriteKeySerials,
            string goingToWriteKeyCodeDirectory,ArrayList goingToWriteKeyCodes,ArrayList nameList) {
            FilesOperator PMFO = new FilesOperator();
            int writeResult = PMFO.writeMultipleStringToFile(goingToWriteMultipleFilePath, goningToWriteKeySerials);
            if (writeResult == 0) { return 0; }
            PMFO.createDirectory(goingToWriteKeyCodeDirectory);
            string prioDataBase = goingToWriteKeyCodeDirectory;
            int subScript = 0;
            foreach (String item in nameList)
            {
                string fileName = prioDataBase + "\\" + item + "-PrioData.exe";
                PMFO.writeOneStringToFile(fileName, goingToWriteKeyCodes[subScript].ToString());
                subScript += 1;
            }
            return 1;
        }
        /// <summary>
        /// 将单条授权写入数据库
        /// </summary>
        /// <param name="DatabaseIP"></param>
        /// <param name="DatabaseUser"></param>
        /// <param name="DatabasePWD"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="DatabasePort"></param>
        /// <param name="authorizedUserName"></param>
        /// <param name="authorizedKeySerial"></param>
        /// <param name="authorizedKeyCode"></param>
        /// <returns></returns>
        public int writeCurrentKeyCodeToDBProcess(string DatabaseIP, string DatabaseUser, string DatabasePWD, string DatabaseName, string DatabasePort,
            string authorizedUserName, string authorizedKeySerial, string authorizedKeyCode)
        {
            DatabaseOperator PMDO = new DatabaseOperator(DatabaseIP, DatabaseUser, DatabasePWD, DatabaseName, DatabasePort);
            string insertString = @"insert into authorized_lists(user_name,key_serial,key_code,used_counts,update_time) values ('" +
            authorizedUserName + "','" + authorizedKeySerial + "','" + authorizedKeyCode + "',0,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            //Console.WriteLine(insertString);
            int writeResult = PMDO.insertAuthorizedKeyToMysqlDatabase(insertString);
            if (writeResult == 0) { return 0; }
            return 1;
        }
        /// <summary>
        /// 批量将授权码写入数据库中
        /// </summary>
        /// <param name="DatabaseIP"></param>
        /// <param name="DatabaseUser"></param>
        /// <param name="DatabasePWD"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="DatabasePort"></param>
        /// <param name="authorizedUserNames"></param>
        /// <param name="authorizedKeySerials"></param>
        /// <param name="authorizedKeyCodes"></param>
        /// <returns></returns>
        public int writeMultipleKeyCodeToDBProcess(string DatabaseIP, string DatabaseUser, string DatabasePWD, string DatabaseName, string DatabasePort,
            ArrayList authorizedUserNames, ArrayList authorizedKeySerials, ArrayList authorizedKeyCodes)
        {
            DatabaseOperator PMDO = new DatabaseOperator(DatabaseIP, DatabaseUser, DatabasePWD, DatabaseName, DatabasePort);
            string insertStringBase = @"insert into authorized_lists(user_name,key_serial,key_code,used_counts,update_time) values ";
            string leftString = "";  //SQL中剩下的部分
            for (int i = 0; i < authorizedUserNames.Count; i++) {
                string rightString = "('" + authorizedUserNames[i].ToString() + "','" + authorizedKeySerials[i].ToString() +
                    "','" + authorizedKeyCodes[i].ToString() + "',0,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),";
                leftString += rightString;
            }
            leftString = leftString.Substring(0, leftString.Length - 1);
            string insertString = insertStringBase + leftString + ";";
            //Console.WriteLine(insertString);
            int writeResult = PMDO.insertAuthorizedKeyToMysqlDatabase(insertString);
            if (writeResult == 0) { return 0; }
            return 1;
        }
    }
}
