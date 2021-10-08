using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuCheck7
{
    public class P02_AccountExpirationDate : Auto
    {
        /// <summary>
        /// 계정의 암호 최대 만료일 90일 체크
        /// </summary>
        ///

        public static string ChkName = "PC-02";

        public static string[] result = new string[3];

        public string[] Check()
        {
            try
            {
                RunCheck();
                return result;
            }
            catch (Exception ex)
            {
                result[1] = "ERROR";
                result[2] = ex.ToString();
                return result;
            }
        }

        public string[] Fix()
        {

            return result;
        }

        public void RunCheck()
        {
            string rawdata, data;
            int maxdate;

            try
            {
                rawdata = Command.Cmd("net accounts");

                List<string> DataToList = new List<string>(rawdata.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

                data = DataToList.Where(d => d.StartsWith("최대 암호 사용 기간 (일):")).Select(d => d.Replace("최대 암호 사용 기간 (일):", string.Empty)).ToArray()[0].Trim();

                maxdate = Convert.ToInt32(data);

                if (maxdate>90)
                {
                    result[1] = "N";
                    result[2] = "최대 암호 사용기간이 90일을 초과했습니다.";
                }

            }
            catch (Exception ex)
            {
                result[1] = "ERROR";
                result[2] = ex.ToString();
            }
        }


    }
}
