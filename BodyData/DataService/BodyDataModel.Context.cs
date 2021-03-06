﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UTBodyDataEntities : DbContext
    {
        public UTBodyDataEntities()
            : base("name=UTBodyDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BodyData> BodyDatas { get; set; }
    
        public virtual ObjectResult<uspGetBodyData_Result> uspGetBodyData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetBodyData_Result>("uspGetBodyData");
        }
    
        public virtual ObjectResult<uspGetBodyDataByUserNameAndSessionName_Result> uspGetBodyDataByUserNameAndSessionName(string username, string sessionname)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var sessionnameParameter = sessionname != null ?
                new ObjectParameter("sessionname", sessionname) :
                new ObjectParameter("sessionname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetBodyDataByUserNameAndSessionName_Result>("uspGetBodyDataByUserNameAndSessionName", usernameParameter, sessionnameParameter);
        }
    
        public virtual ObjectResult<string> uspGetPatients()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetPatients");
        }
    
        public virtual ObjectResult<string> uspGetSessionsByUserName(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetSessionsByUserName", usernameParameter);
        }
    
        public virtual int uspInsertBodyData(string username, string sessionName, string joints, string jointPoints, Nullable<System.DateTime> timestamp)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var sessionNameParameter = sessionName != null ?
                new ObjectParameter("SessionName", sessionName) :
                new ObjectParameter("SessionName", typeof(string));
    
            var jointsParameter = joints != null ?
                new ObjectParameter("Joints", joints) :
                new ObjectParameter("Joints", typeof(string));
    
            var jointPointsParameter = jointPoints != null ?
                new ObjectParameter("JointPoints", jointPoints) :
                new ObjectParameter("JointPoints", typeof(string));
    
            var timestampParameter = timestamp.HasValue ?
                new ObjectParameter("timestamp", timestamp) :
                new ObjectParameter("timestamp", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspInsertBodyData", usernameParameter, sessionNameParameter, jointsParameter, jointPointsParameter, timestampParameter);
        }
    }
}
