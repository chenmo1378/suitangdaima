using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Windows;

namespace HRMSys.UI
{
    class CommonHelper
    {
        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        //把一些可能会变的值写入app.config
        //读取密码盐
        public static string GetPasswordSalt()
        {
            string salt = ConfigurationManager.AppSettings["passwordSalt"];
            return salt;
        }

        public static void ShowError(string errorMsg)
        {
            MessageBox.Show(errorMsg, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool ShowYesNo(string msg)
        {
            return MessageBox.Show(msg, "询问", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        /// <summary>
        /// 获得登录用户的Id
        /// </summary>
        /// <returns></returns>
        public static Guid GetOperatorId()
        {
            Guid operatorId = (Guid)Application.Current.Properties["OperatorId"];
            return operatorId;
        }
    }

}
