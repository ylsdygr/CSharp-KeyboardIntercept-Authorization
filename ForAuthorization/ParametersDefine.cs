using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ForAuthorization
{
    public class ParametersDefine
    {
        //////////////////////////////
        ////////参数定义区域///////////
        //////////////////////////////

        //////////数据库配置//////////
        public string para_DatabaseIP = "192.168.6.89";  //数据库连接IP
        public string para_DatabaseUser = "keyboard";  //数据库连接用户名
        public string para_DatabasePWD = "keyboard";  //数据库连接密码
        public string para_DatabaseName = "keyboardAuth";  //数据库名称
        public string para_DatabasePort = "3306";  //数据库端口
        //////////数据库配置//////////

        //////////本地文件输出//////////
        //注意，文件保存，只支持根目录下一级，未做递归检测，不然会出错
        public string para_localKeyFileStorePath = "D:\\KeyFile";//将要存储授权的根路径
        public string para_singleKeyPrioListPath = "D:\\KeyFile\\SinglePrioList.exe"; //单授权列表文件路径
        public string para_singleKeyPrioDataPath = "D:\\KeyFile\\SinglePrioData.exe"; //单授权密码文件路径
        public string para_goingToCreateNamePath = "D:\\KeyFile\\NameList.txt"; //将要识别用户名的txt文件路径
        public string para_MultipleKeyPrioListPath = "D:\\KeyFile\\MultiplePrioList.exe"; //根据文件生成多授权列表文件路径
        public string para_MultipleKeyPrioDataPath = "D:\\KeyFile\\MultiplePrioData"; //根据文件生成多授权文件的存储目录
        //////////本地文件输出//////////

        //////////////////////////////
        ////////参数定义区域///////////
        //////////////////////////////

        public ParametersDefine()
        {
        }
    }
}
