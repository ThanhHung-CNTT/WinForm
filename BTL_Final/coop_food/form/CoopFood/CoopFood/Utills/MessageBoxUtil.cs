using CoopFood.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood.Utills
{
    public static class MessageBoxUtil
    {
        public static void ShowMessageBox(string mesBody, MessageBoxType type)
        {
            var mesIcon = new MessageBoxIcon();
            var mesTitle = "Information";

            switch (type)
            {
                case MessageBoxType.Information: // Thông báo
                    mesIcon = MessageBoxIcon.Information;
                    break;
                case MessageBoxType.Warning: // cảnh báo
                    mesTitle = "Warning";
                    mesIcon = MessageBoxIcon.Warning;
                    break;
                case MessageBoxType.Error: // Lỗi
                    mesTitle = "Error";
                    mesIcon = MessageBoxIcon.Error;
                    break;
                default:
                    mesIcon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(mesBody, mesTitle, MessageBoxButtons.OK, mesIcon);
        }
    }
}
