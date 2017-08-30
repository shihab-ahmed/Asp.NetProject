using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Utilities
{
    public class ListOFComplainStatus
    {
        public List<String> getComplainList()
        {
            List<String> complains = new List<string>();
            complains.Add("Always Disturbing");
            complains.Add("Never Respond");
            complains.Add("Harresment");
            complains.Add("Share wrong information");
            return complains;
        }
    }
}
