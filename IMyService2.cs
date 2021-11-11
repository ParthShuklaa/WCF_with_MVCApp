using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService2" in both code and config file together.
    [ServiceContract]
    public interface IMyService2
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<UserDetail> GetAllUser();
        [OperationContract]
        UserDetail GetAllUserById(int id);
        [OperationContract]
        int AddUser(string Name, string Email);
        [OperationContract]
        int DeleteUserById(int Id);

    }
    [DataContract]
    public class UserDetails
    {
        [DataMember]
        public int Id { get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
