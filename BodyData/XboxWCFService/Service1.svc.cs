using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XboxWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<BodyDataObject> GetData(int value)
        {
            List<BodyDataObject> temp = null;
            using (UTBodyDataEntitiesV3 db = new UTBodyDataEntitiesV3())
            {

                temp = db.BodyDatas.Select(x => new BodyDataObject() {UserName = x.UserName,SessionName = x.SessionName,Joints = x.Joints,JointPoints = x.JointPoints, TimeStamp = Convert.ToDateTime( x.timestamp) }).ToList(); 

               // List<BodyDataObject> temp = db.uspGetBodyData();
            }
            return temp;
        }
        public string SendData(string username,string sessionname, string joints, string jointPoints, DateTime dt)
        {
            using(UTBodyDataEntitiesV3 db = new UTBodyDataEntitiesV3())
            {
                db.uspInsertBodyData(username, sessionname, joints, jointPoints, dt);
            }
            return "hi";
        }

        public List<string> GetPatients()
        {
            List<string> temp = null;
            using (UTBodyDataEntitiesV3 db = new UTBodyDataEntitiesV3())
            {

                temp = db.uspGetPatients().ToList<string>();

                // List<BodyDataObject> temp = db.uspGetBodyData();
            }
            return temp;
        }

        public List<string> GetSessions(string username)
        {
            List<string> temp = null;
            using (UTBodyDataEntitiesV3 db = new UTBodyDataEntitiesV3())
            {

                temp = db.uspGetSessionsByUserName(username).ToList<string>();

                // List<BodyDataObject> temp = db.uspGetBodyData();
            }
            return temp;
        }

        public List<uspGetBodyDataByUserNameAndSessionName_Result> GetBodyData(string username, string sessionname)
        {
            List<uspGetBodyDataByUserNameAndSessionName_Result> temp = null;
           // List<uspGetBodyDataByUserNameAndSessionName_Result> temp = null;
            using (UTBodyDataEntitiesV3 db = new UTBodyDataEntitiesV3())
            {

                temp = db.uspGetBodyDataByUserNameAndSessionName(username, sessionname).ToList<uspGetBodyDataByUserNameAndSessionName_Result>();
                //var t = db.BodyDatas.Select(x => new BodyDataObject() { UserName = x.UserName, SessionName = x.SessionName, Joints = x.Joints, JointPoints = x.JointPoints, TimeStamp = DateTime.Now }).ToList();

                //foreach(BodyDataObject bd in t)
                //{
                //    if(bd.UserName == "Cadarrius Mcglown" & bd.SessionName == "testsession")
                //        Debug.WriteLine(bd.UserName + " " + bd.SessionName);
                //}

                //temp = db.BodyDatas.Where(x => x.UserName == username & x.SessionName == sessionname).Select(x => new BodyDataObject() { UserName = x.UserName, SessionName = x.SessionName, Joints = x.Joints, JointPoints = x.JointPoints, TimeStamp = DateTime.Now }).ToList();
                //temp = db.BodyDatas.Where(x => x.UserName == username & x.SessionName == sessionname).Select(x => new BodyDataObject() { UserName = x.UserName, SessionName = x.SessionName, Joints = x.Joints, JointPoints = x.JointPoints, TimeStamp = DateTime.Now }).ToList();
                //temp = db.uspGetBodyDataByUserNameAndSessionName(username, sessionname).ToList<uspGetBodyDataByUserNameAndSessionName_Result>();
            }
            return temp;
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
