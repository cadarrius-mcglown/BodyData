using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataService
{
    [DataContract]
    public class BodyDataObject
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public string Joints { get; set; }
        [DataMember]
        public string JointPoints { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }

        public BodyDataObject()
        {

        }
        public BodyDataObject(string u, string sn, string j, string jp, DateTime ts)
        {
            UserName = u;
            SessionName = sn;
            Joints = j;
            JointPoints = jp;
            TimeStamp = ts;
        }
    }

}