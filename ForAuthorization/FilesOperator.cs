using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ForAuthorization
{
    class FilesOperator
    {
        /// <summary>
        /// 从文件中读取多行数据传递给ArrayList
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="readedArrayList"></param>
        /// <returns></returns>
        public int readMultipleLineFromAFile(string filePath, ref ArrayList readedArrayList)
        {
            if (!File.Exists(filePath)) {
                //System.Console.WriteLine("File is not exists!");
                return 0;
            }
            try {
                FileStream keysInFile = new FileStream(filePath, FileMode.Open);
                using (var stream = new StreamReader(keysInFile)) {
                    while (!stream.EndOfStream) {
                        readedArrayList.Add(stream.ReadLine());
                    }
                }
                keysInFile.Close();
            }
            catch (IOException e) { return 0; }
            return 1;
        }
        /// <summary>
        /// 写入一行字符串到指定文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="goingToWriteString"></param>
        /// <returns></returns>
        public int writeOneStringToFile(string filePath, string goingToWriteString) {
            try
            {
                FileStream writeString = new FileStream(filePath, FileMode.OpenOrCreate);
                using (var stream = new StreamWriter(writeString))
                {
                    //System.Console.WriteLine(goingToWriteString);
                    stream.Write(goingToWriteString);
                }
                writeString.Close();
            }
            catch (IOException ex)
            {
                //System.Console.WriteLine(ex.ToString());
                return 0;
            }
            return 1;
        }
        /// <summary>
        /// 写入多行字符串至指定文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="goingToWriteString"></param>
        /// <returns></returns>
        public int writeMultipleStringToFile(string filePath, ArrayList goingToWriteString)
        {
            try {
                FileStream writeArrayList = new FileStream(filePath, FileMode.OpenOrCreate);
                using (var stream = new StreamWriter(writeArrayList)) {
                    foreach (string item in goingToWriteString)
                    {
                        stream.Write(item);
                        stream.Write("\n");
                    }
                }
                writeArrayList.Close();
            }
            catch (Exception e) { return 0; }
            return 1;
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
            foreach (FileInfo file in files) {
                string fileName = file.Name;
                try {
                    File.Delete(file.FullName);
                }
                catch (Exception ex) {
                }
            }
            //递归删除子文件夹内文件
            foreach (DirectoryInfo childFolder in fatherFolder.GetDirectories())
            {
                DeleteFiles(childFolder.FullName);
            }
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="directoryPath"></param>
        public void createDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
