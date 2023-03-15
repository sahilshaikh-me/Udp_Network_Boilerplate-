using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkLogicHandler : MonoBehaviour
{

    private static NetworkLogicHandler _instance;
    public static NetworkLogicHandler instance { get { return _instance; } }
    public IPEndPoint EPAddress;
    public string CurrentUserName;
    int num;

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
        CurrentUserName = "";
    }
    private void Start()
    {
      //  GetAllDataFromServer();
    }
  
    public void DataHandler()
    {
        num++;
      //  UdpClientTest.instance.sendMsg("Hii Sahil" + num, "Hii Back", "Hii Back");
       
    }
    private void Update()
    {
        //textdEBUG.text = UdpClientTest.instance.GetResponce();
        if (Authentication.instance.userTaken)
        {
            Authentication.instance.ErrorText.color = Color.red;
            Authentication.instance.ErrorText.text = "This username is already taken.Try Another";
        }
        else
        {
            Authentication.instance.ErrorText.text = "";
        }
        // TO GET ALL DATA FROM SERVER USER "GetData" Key Word

    }
    public void ProcessingData(string responce)
    {
        if (string.IsNullOrEmpty(responce))
        {
            return;
        }

        Debug.Log(responce + " " + responce.Substring(0, 6));

        #region RegisterApiDatas
        //if (responce == "USERTAKEN") /// REGISTER LOGIC
        //{

        //    Authentication.instance.userTaken = true;
        //    // Authentication.instance.isRegister = false;


        //    Debug.Log("USERTAKEN");

        //}
        //if (responce == "USERNOTAKEN") /// REGISTER LOGIC
        //{
        //    Authentication.instance.isRegister = true;

        //    Authentication.instance.userTaken = false;
        //    Debug.Log("REGISTER SUCESSFULLY");

        //}
        #endregion

        #region LoginApiData
        //if (responce.Substring(0, 6) == "LOGINS") /// Login LOGIC
        //{
           
        //    var test = responce.Remove(0, 6);
        //    CurrentUserName = test;
        //    Authentication.instance.islogin = true;
        //    // UpdateCurrentUserData();// to Update current Logion User
        //    Debug.Log("ILOGINSUCCESS : " + " THIS");
        //}
        //if (responce == "USERNOTFOUND")
        //{
        //    Debug.Log("UserNot REGISTER");
        //}

        #endregion

        #region GettingAndSendingData

        if (responce.Substring(0, 8) == "SendData") /// REGISTER LOGIC
        {
            var test = responce.Remove(0, 8);
            ClientDataBase.instance.user = JsonHelper.FromJson<ClientUser>(test).ToList();
            Debug.Log(test);
           

        }
        if (responce.Substring(0, 4) == "name") /// REGISTER LOGIC
        {
            string test = responce.Remove(0, 4);

            CurrentUserName = test;

            Debug.Log(test + "lllllll");

        }

        #endregion
    }

    public void GetAllDataFromServer()
    {
        UdpClientTest.instance.sendToServer("GetData");
    } 
    public void UpdateCurrentUserData()
    {
        for (int i = 0; i < ClientDataBase.instance.user.Count; i++)
        {
            if (CurrentUserName == ClientDataBase.instance.user[i].Name)
            {
                CurrentUserData.instance.currentUser = ClientDataBase.instance.user[i];

                var SendCurrentUserData = JsonUtility.ToJson(CurrentUserData.instance.currentUser);
               UdpClientTest.instance.sendToServer(SendCurrentUserData);
               
            }
        }
       

    }
    public void sendCurrentUserData()
    {
        var storeData = JsonUtility.ToJson(CurrentUserData.instance.currentUser);
       UdpClientTest.instance.sendToServer("curUser"+ storeData);
        Debug.Log("SENDDDDDD");

    }


}




