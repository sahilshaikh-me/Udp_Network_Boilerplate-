using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ClientDataBase : MonoBehaviour
{
    private static ClientDataBase _instance;
    public static ClientDataBase instance { get { return _instance; } }

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
    public string Name;
    public string Passowrd;


    public List<ClientUser> user = new List<ClientUser>();

}

[System.Serializable]
public class ClientUser
{
    public string Name;
    public string Passowrd;
    public Datas datas = new Datas();

}

[System.Serializable]
public class Datas
{

    public LevelOne levelOne = new LevelOne();
    public LevelTwo levelTwo;
    public LevelThree levelThree;

}



#region  LevlesData

[System.Serializable]
public class LevelOne
{

    public LevelOneTraneeProfile LevelOnetraneeProfiles = new LevelOneTraneeProfile();

}
[System.Serializable]
public class LevelTwo
{
    public LevelTwoTraneeProfile LevelTwotraneeProfiles;

}
[System.Serializable]
public class LevelThree
{
    public LevelThreeTraneeProfile LevelThreetraneeProfiles;

}

#endregion

#region TraneeProfile

[System.Serializable]
public class LevelOneTraneeProfile
{
    public LevelOneTraneeCard LevelOneTraneeCards;

}
[System.Serializable]
public class LevelTwoTraneeProfile
{
    public LevelTwoTraneeCard LevelTwoTraneeCards;

}
[System.Serializable]
public class LevelThreeTraneeProfile
{
    public LevelThreeTraneeCard LevelThreeTraneeCards;

}

#endregion

#region TrabneeCard

[System.Serializable]
public class LevelOneTraneeCard
{

    public LevelOneTraneeCard(string name, string password)
    {

    }


    public List<AssigneSystemLevelOne> assigneSystemsl = new List<AssigneSystemLevelOne>();


}
[System.Serializable]
public class LevelTwoTraneeCard
{


    public List<AssigneSystemLevelTwo> assigneSystemsl;


}
[System.Serializable]
public class LevelThreeTraneeCard
{



    public List<AssigneSystemLevelThree> assigneSystemsl;


}

#endregion

[System.Serializable]
public class AssigneSystemLevelOne
{
    public string SystemName;
    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();


}
[System.Serializable]
public class AssigneSystemLevelTwo
{
    public string SystemName;
    public List<SystemProcess> Process = new List<SystemProcess>();
    public DateTime StartDate;
    public DateTime EndDateDate;

    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();

}
[System.Serializable]
public class AssigneSystemLevelThree
{
    public string SystemName;
    public DateTime StartDate;
    public DateTime EndDateDate;

    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();

}
[System.Serializable]
public class SystemProcess
{
    public string ProcessName;

    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();
}


