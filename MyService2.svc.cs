using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace MyWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService2.svc or MyService2.svc.cs at the Solution Explorer and start debugging.
    public class MyService2 : IMyService2
    {
        public void DoWork()
        {
        }

        public List<UserDetail> GetAllUser()
        {
            List<UserDetail> userlst = new List<UserDetail>();
            MyDBEntities tstDb = new MyDBEntities();
                var lstUsr = from K in tstDb.UserDetails select K;
            foreach ( var item in lstUsr)
            {
                UserDetail usr = new UserDetail();
                usr.ID = item.ID;
                usr.Name = item.Name;
                usr.Email = item.Email;
                userlst.Add(usr);

            }

            return userlst;
        }
        public UserDetail GetAllUserById(int id)
        {
            MyDBEntities tstDb = new MyDBEntities();
            var lstUsr = from k in tstDb.UserDetails where k.ID == id select k;
            UserDetail usr = new UserDetail();
            foreach (var item in lstUsr)
            {
                usr.ID = item.ID;
                usr.Name = item.Name;
                usr.Email = item.Email;
            }
            return usr;
        }

        public int DeleteUserById(int id)
        {
            MyDBEntities tstDb = new MyDBEntities();
            UserDetail usrdtl = new UserDetail();
            usrdtl.ID = id;
            tstDb.Entry(usrdtl).State = EntityState.Deleted;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddUser(string Name , string Email)
        {
            MyDBEntities tstDb = new MyDBEntities();
            UserDetail usrdtl = new UserDetail();
            usrdtl.Name = Name;
            usrdtl.Email = Email;
            tstDb.UserDetails.Add(usrdtl);
            int retval = tstDb.SaveChanges();
            return retval;
        }
    }
}
