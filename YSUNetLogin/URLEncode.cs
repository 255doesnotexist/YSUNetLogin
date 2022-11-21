﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSUNetLogin
{
    public static class URLEncode
    {/// <summary>
     /// Url编码
     /// </summary>
     /// <param name="str">原字符串</param>
     /// <param name="encoding">编码格式</param>
     /// <param name="upper">特殊字符编码为大写</param>
     /// <returns></returns>
        public static string UrlEncode(string str, Encoding encoding)
        {

            if (encoding == null)
            {
                encoding = UTF8Encoding.UTF8;
            }
            byte[] bytes = encoding.GetBytes(str);
            int num = 0;
            int num2 = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                char ch = (char)bytes[i];
                if (ch == ' ')
                {
                    num++;
                }
                else if (!IsUrlSafeChar(ch))
                {
                    num2++;  //非url安全字符
                }
            }

            if (num == 0 && num2 == 0)
            {
                return str;  //不包含空格和特殊字符
            }

            byte[] buffer = new byte[bytes.Length + (num2 * 2)];  //包含特殊字符，每个特殊字符转为3个字符，所以长度+2x
            int num3 = 0;
            for (int j = 0; j < bytes.Length; j++)
            {
                byte num6 = bytes[j];
                char ch2 = (char)num6;
                if (IsUrlSafeChar(ch2))
                {
                    buffer[num3++] = num6;
                }
                else if (ch2 == ' ')
                {
                    buffer[num3++] = 0x2B;  //0x2B代表 ascii码中的+，url编码时候会把空格编写为+
                }
                else
                {
                    //特殊符号转换
                    buffer[num3++] = 0x25;  //代表  %
                    buffer[num3++] = (byte)IntToHex((num6 >> 4) & 15);   //8位向右移动四位后  与 1111按位与 ，即保留高前四位 ，比如  /为  2f，则结果保留了2
                    buffer[num3++] = (byte)IntToHex(num6 & 15);   //8位  ，与00001111按位与，即保留 后四位  ，比如 /为2f，则结果保留了 f

                }
            }

            return encoding.GetString(buffer);



        }

        static bool IsUrlSafeChar(char ch)
        {
            if ((((ch < 'a') || (ch > 'z')) && ((ch < 'A') || (ch > 'Z'))) && ((ch < '0') || (ch > '9')))
            {

                switch (ch)
                {
                    case '(':
                    case ')':
                    case '*':
                    case '-':
                    case '.':
                    case '!':
                        break;  //安全字符

                    case '+':
                    case ',':
                        return false;  //非安全字符
                    default:   //非安全字符
                        if (ch != '_')
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        static char IntToHex(int n)   //n为0-f 
        {
            if (n <= 9)
            {
                return (char)(n + 0x30);  //0x30  十进制是48 对应ASCII码是0  
            }
            return (char)((n - 10) + 0x41);   //0x41 十进制是 65 对应ASCII码是A 
        }
    }
}
