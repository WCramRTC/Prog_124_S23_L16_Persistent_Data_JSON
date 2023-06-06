using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_S23_L16_Persistent_Data_JSON
{
    internal static class Data
    {
        static string membersFileName = "members";
        static string jsonExtension = ".json";

        public static string MemberFilePath
        {
            get => membersFileName + jsonExtension;
        }


    }
}
