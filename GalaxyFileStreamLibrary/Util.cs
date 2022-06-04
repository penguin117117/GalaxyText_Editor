using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyFileStreamLibrary
{
    public class EncodingName
    {
        public const string UTF16_Bigendian = "utf-16BE"; 
    }

    public class ReadString 
    {
        public static string FromBinaryRead(BinaryReader br , int readChers) 
        {
            string str = string.Empty;

            try
            {
                str = Encoding.GetEncoding("unicodeFFFE").GetString(br.ReadBytes(readChers));
            }
            catch (Exception e) 
            {
                br.Close();
                string[] errorJP01 = { "深刻なエラーが発生しました\n\r[" + e.Message + "]\n\r" + "ErrorNo 1", "エラー" };
                string[] errorJP02 = { "「以前に他のMSBTエディタで編集していませんか？」\n\r", "ファイルフォーマット規則が一部破損しているので\n\r", "このエディタでは開くことが出来ません", "このエラーの原因で考えられること" };
                string[] errorJP03 = { "ゲームから吸い出した壊れていないデータを使用してください\n\r", "または、正しい方法でバイナリを修正する必要があります。\n\r", "このメッセージの後アプリケーションを強制終了します", "この問題への提案" };
                string[] errorEN01 = { "A serious error has occurred.\n\r[" + e.Message + "]\n\r" + "ErrorNo 1", "Error" };
                string[] errorEN02 = { "「Have you edited with a different 'MSBT editor' before?」\n\r", "The file formatting rules are partially broken,\n\r", "so this editor cannot open the file.", "Possible causes for this error." };
                string[] errorEN03 = { "Use the uncorrupted data sucked out of the game.\n\r", "Or you need to modify the binary in the right way.\n\r", "After this message, the application will be killed.", "Suggestions for this problem" };

                string[] error01;
                string[] error02;
                string[] error03;

                //if (Properties.Settings.Default.言語 == "EN")
                //{
                //    error01 = errorEN01;
                //    error02 = errorEN02;
                //    error03 = errorEN03;
                //}
                //else
                //{
                //    error01 = errorJP01;
                //    error02 = errorJP02;
                //    error03 = errorJP03;
                //}

                error01 = errorJP01;
                error02 = errorJP02;
                error03 = errorJP03;

                MessageBox.Show(error01[0], error01[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(error02[0] + error02[1] + error02[2], error02[3], MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(error03[0] + error03[1] + error03[2], error03[3], MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            return str;
        }
    }
}
