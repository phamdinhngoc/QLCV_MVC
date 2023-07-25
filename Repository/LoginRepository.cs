using LibWebNetConn;
using QLCV_MVC.ViewModels;
using System.Data;

namespace QLCV_MVC.Repository
{
    public class LoginRepository
    {
        LibWebNetConn.AccessData lib = new AccessData();

        public DataSet CheckUserLogin(string username, string pass)
        {
            string _password = lib.encode(pass);
            //using (EntityLibContext entities = new EntityLibContext(DatabaseAccessNonEntity.connectionStringEntity))
            //{
            //    var a = entities.Users.FirstOrDefault(User => User.Active == 1
            //                                        && User.Username == "an.dd"
            //                                        && User.Password == "C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B");
            //    //var a = entities.Users.FirstOrDefault(User => User.Active == 1
            //    //                                   && User.Username == username
            //    //                                   && User.Password == pass);
            //    return a;
            //}
            string sql="select * from " + lib.user + ".dlogin where userid='" + username + "' and password_='" + _password + "'";
            DataSet ds = lib.get_data(sql);
            return ds;
        }
        
    }
}
