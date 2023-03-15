using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

public class NetworkLogicHandler : MonoBehaviour
{
    private static NetworkLogicHandler _instance;
    public static NetworkLogicHandler instance { get { return _instance; } }

    public string currentName;
    public IPEndPoint EPAddress;
    public NewDataBase dataBase;

    #region ClassesArray
    [System.Serializable]
    public class InitialJoin
    {
        public string ID;
        public string IP;
    }
    public List< InitialJoin> initialJoin = new List<InitialJoin>();

    [System.Serializable]
    public class RegisterUser
    {

        public string username;
        public string password;
        public RegisterUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    public List<RegisterUser> registerUser = new List<RegisterUser>();
    [System.Serializable]
    public class LoginUser
    {

        public string username;
        public string password;
        public LoginUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    public LoginUser loginUser = new LoginUser(null,null);

    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
      
    }


    int num;
    public void DataHandler() {

       
        num++;
        UDPServer.instance.sendMsg("Hii Back"+ num, "Hi", "Hi", EPAddress);

    }
   [SerializeField] bool isRegisterUserPresent;
   [SerializeField] bool isLoginUserPresent;
    public void ProcessingData(string responce)
    {
        if (string.IsNullOrEmpty(responce))
        {
            return;
        }
        Debug.Log("response" + responce);
        if (responce.Substring(0, 4) == "INIT")
        {

            string test = responce.Remove(0, 4);
            initialJoin.Add(JsonUtility.FromJson<InitialJoin>(test));

        }
        #region RegisterData
        //else if (responce.Substring(0, 4) == "Regi")
        //{
        //    // string test = responce.Remove(0, 4);
        //    var test2 = JsonUtility.FromJson<RegisterUser>(responce.Remove(0, 4));
        //    if (String.IsNullOrEmpty(test2.username) || String.IsNullOrEmpty(test2.password))
        //    {
        //        return;
        //    }
        //    foreach (var item in registerUser)
        //    {

        //        Debug.Log(item.username + " User not takennnnnnnnnnn");

        //        if (item.username.Equals(test2.username))
        //        {
        //            isRegisterUserPresent = true;

        //            return;
        //        }

        //         isRegisterUserPresent = false;


        //    }
        //    if (isRegisterUserPresent)
        //    {
        //        UDPServer.instance.sendToClient("USERTAKEN", EPAddress);

        //    }
        //    else
        //    {
        //          UDPServer.instance.sendToClient("USERNOTAKEN", EPAddress);

        //        registerUser.Add(new RegisterUser(test2.username, test2.password));
        //        dataBase.user.Add(new NewUser(test2.username, test2.password));
        //    }




        //    // dataBase.user = new List<User>(new User[registerUser.Count]); ---------------

        //}
        #endregion

        #region LogionData
        //if (responce.Substring(0, 5) == "Login")
        //{

        //    if(responce != null)
        //    {
        //        Debug.Log(responce.Remove(0, 5) + " LoginTest ");
        //        var test3 = JsonUtility.FromJson<LoginUser>(responce.Remove(0, 5));
        //     //  var test2 = JsonHelper.FromJson<RegisterUser>(test);
        //        foreach (var item in registerUser)
        //        {
        //          Debug.Log("0");

        //            if (item.username.Equals(test3.username) && item.password.Equals(test3.password))
        //            {
        //                Debug.Log("1");

        //                 isLoginUserPresent = true;

        //            }
        //            if (item.username != test3.username)
        //            {
        //                isLoginUserPresent = false ;

        //               Debug.Log("3");


        //            }



        //        }
        //        if (isLoginUserPresent)
        //        {
        //            UDPServer.instance.sendToClient("LOGINS" + test3.username, EPAddress);
        //            Debug.Log("USER  FOUND" + test3);
        //            Debug.Log("4");

        //        }
        //        else
        //        {
        //            Debug.Log("USER NOT FOUND" + test3);
        //            UDPServer.instance.sendToClient("USERNOTFOUND", EPAddress);
        //            Debug.Log("5");


        //        }

        //    }

        //}
        #endregion

        #region GettingDataAndSendingData
       else if (responce == "GetData")
        {

            var toJson = "SendData" +JsonHelper.ToJson<NewUser>(dataBase.user.ToArray());
           // Debug.Log(toJson + "llllllll" + dataBase.user[0].Name);

            UDPServer.instance.sendToClient(toJson, EPAddress);
          
        }
        else if (responce.Substring(0, 7) == "curUser")
        {
            string test = responce.Remove(0, 7);
            Debug.Log(test);
            var test3 = JsonUtility.FromJson<NewUser>(test);
            Debug.Log(test3.Name + " Current User name");
            for (int i = 0; i < NewDataBase.instance.user.Count; i++)
            {
                if (test3.Name == NewDataBase.instance.user[i].Name)
                {
                    NewDataBase.instance.user[i] = test3;
                }

            }

        }
        #endregion
    }
    public void SendCurrentName(string name)
    {
        UDPServer.instance.sendToClient("name" + name, EPAddress);

    }


}
