using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealKit
{
    //유저의 정보 조회하는 곳
    public class UserDataManager
    {
        public static bool isAdmin = false;
        // 로그인 체크, 마이페이지 정보 불러오는 역할
        public static UserInformation loginUser = null;

        // 유저ID가 중복되는지 체크
        public static bool isUserDuplicated(string id, out string contents)
        {
            DBManagerClientInfor.SelectQuery(id);// DB에 같은 ID가 있는지 검사
            contents = "";
            if (DBManagerClientInfor.dt.Rows.Count == 0)
            {
                contents = $"해당 ID는 가입이 가능합니다.";
                return false;
            }
            else
            {
                contents = "해당 ID가 존재합니다.";
                return true;
            }
        }

        public static bool Save(string id, string pw, string current, out string contents)
        {
            DBManagerClientInfor.SelectQuery(id, pw);
            contents = "";
            if (DBManagerClientInfor.dt.Rows.Count != 0)
            {
                DBManagerClientInfor.updateQuery(id, pw, current);
                contents = $"USER ID : {id}님이 로그인하였습니다.";
                System.Windows.Forms.MessageBox.Show("로그인하였습니다.");
                //DBManagerClientInfor.dt.Rows[0]
                //isLogin = true;
                loginUser = new UserInformation();
                loginUser.ID = id;
                loginUser.Password = pw;
                loginUser.Name = DBManagerClientInfor.dt.Rows[0]["Name"].ToString();
                loginUser.ZipCode = DBManagerClientInfor.dt.Rows[0]["ZipCode"].ToString();
                loginUser.Address = DBManagerClientInfor.dt.Rows[0]["Address"].ToString();
                loginUser.DetailAddress = DBManagerClientInfor.dt.Rows[0]["DetailAddress"].ToString();
                loginUser.ReferenceAddress = DBManagerClientInfor.dt.Rows[0]["ReferenceAddress"].ToString();
                loginUser.PhoneNumber = DBManagerClientInfor.dt.Rows[0]["PhoneNumber"].ToString();
                if (loginUser.ID == "adminuser")
                {
                    isAdmin = true;
                    System.Windows.Forms.MessageBox.Show("잠시후 관리자 전용 화면이 열립니다.");
                }

                return false;
            }
            else
            {
                contents = "존재하지 않는 ID 또는 비밀번호 입니다.";
                loginUser = null;
                //isLogin = false;
                System.Windows.Forms.MessageBox.Show("존재하지 않는 ID 또는 비밀번호 입니다.");
                return true;
            }
        }

        public static void Save(string id, string pw, string currentState)
        {
            DBManagerClientInfor.updateQuery(id, pw, currentState);
            string contents = $"USER ID : {id}님이 로그아웃하였습니다.";
            Login form = new Login();
            form.writeLog(contents);
        }

        public static void Save(string id, string pw, string name, string zipCode, string adress,
            string detailAdress, string referenceAdress, string phoneNumber, string cmd, out string contents)
        {
            contents = "";
            DBInsert(id, pw, name, zipCode, adress, detailAdress, referenceAdress, phoneNumber, ref contents);
        }

        public static void WithdrowUser(string id)
        {
            Login form = new Login();
            string cmd = "delete";
            DBManagerClientInfor.deleteQurey(id, cmd);
            string contents = $"유저ID : {id}님이 회원탈퇴 했습니다.";
            form.writeLog(contents);
        }


        private static void DBInsert(string id, string pw, string name, string zipCode, string adress, string detailAdress, string referenceAdress,
            string phoneNumber, ref string contents)
        {
            DBManagerClientInfor.insertQuery(id, pw, name, zipCode, adress, detailAdress, referenceAdress, phoneNumber);
            contents = $"유저ID : {id}, {name}님이 회원가입을 하였습니다.";
        }

        // 유저가 가입할때마다 로그파일 생성
        public static void UserAccountLog(string contens)
        {
            DirectoryInfo id = new DirectoryInfo("LogFolder");
            if (id.Exists == false)
                id.Create();
            using (StreamWriter w = new StreamWriter
                (@"LogFolder\AccountHistory.txt", true))
            {
                w.WriteLine(contens);
            }
        }
        public static void CurrentStateLog(string contens)
        {
            using (StreamWriter w = new StreamWriter
                (@"LogFolder\CurrentState.txt", true))
            {
                w.WriteLine(contens);
            }
        }

    }
}
