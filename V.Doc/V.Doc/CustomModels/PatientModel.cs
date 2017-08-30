using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Utilities;

namespace V.Doc.CustomModels
{
    public class PatientModel:GenericUserModel
    {
        public Enum_UserAvailableStatus isAvailable { get; set; }
    }
}