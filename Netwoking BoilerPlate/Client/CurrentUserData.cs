using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUserData : MonoBehaviour
{
    private static CurrentUserData _instance;
    public static CurrentUserData instance { get { return _instance; } }
    public CurrentClientUser currentUser = new CurrentClientUser();
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
    private void Update()
    {
       
    }


}

[System.Serializable]
public class CurrentClientUser
{
    public string Name;
    public string Passowrd;
    public CurrentDatas datas;

    public static implicit operator CurrentClientUser(ClientUser v)
    {
        return JsonConvert.DeserializeObject<CurrentClientUser>(JsonConvert.SerializeObject(v));
    }
}

[System.Serializable]
public class CurrentDatas
{

    public CurrentLevelOne levelOne = new CurrentLevelOne();
    public CurrentLevelTwo levelTwo = new CurrentLevelTwo();
    public CurrentLevelThree levelThree = new CurrentLevelThree();

}



#region  LevelesData

[System.Serializable]
public class CurrentLevelOne
{

    public CurrentLevelOneTraneeProfile LevelOnetraneeProfiles = new CurrentLevelOneTraneeProfile();

}
[System.Serializable]
public class CurrentLevelTwo
{
    public CurrentLevelTwoTraneeProfile LevelTwotraneeProfiles = new CurrentLevelTwoTraneeProfile();

}
[System.Serializable]
public class CurrentLevelThree
{
    public CurrentLevelThreeTraneeProfile LevelThreetraneeProfiles = new CurrentLevelThreeTraneeProfile();

}

#endregion

#region TraneeProfile

[System.Serializable]
public class CurrentLevelOneTraneeProfile
{
    public CurrentLevelOneTraneeCard LevelOneTraneeCards = new CurrentLevelOneTraneeCard();

}
[System.Serializable]
public class CurrentLevelTwoTraneeProfile
{
    public CurrentLevelTwoTraneeCard LevelTwoTraneeCards;

}
[System.Serializable]
public class CurrentLevelThreeTraneeProfile
{
    public CurrentLevelThreeTraneeCard LevelThreeTraneeCards;

}

#endregion

#region TrabneeCard

[System.Serializable]
public class CurrentLevelOneTraneeCard
{


    public List<CurrentAssigneSystemLevelOne> assigneSystemsl = new List<CurrentAssigneSystemLevelOne>();


}
[System.Serializable]
public class CurrentLevelTwoTraneeCard
{


    public List<CurrentAssigneSystemLevelTwo> assigneSystemsl;


}
[System.Serializable]
public class CurrentLevelThreeTraneeCard
{



    public List<CurrentAssigneSystemLevelThree> assigneSystemsl;


}

#endregion

[System.Serializable]
public class CurrentAssigneSystemLevelOne
{
    public string SystemName;
    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();
    public DateTime StartDate;
    public DateTime EndDateDate;

}
[System.Serializable]
public class CurrentAssigneSystemLevelTwo
{
    public string SystemName;
    public DateTime StartDate;
    public DateTime EndDateDate;
    public List<CurrentSystemProcess> Process = new List<CurrentSystemProcess>();

    public enum ProcessState
    {
        Todo,
        Doing,
        Done
    }
    public ProcessState state = new ProcessState();

}
[System.Serializable]
public class CurrentAssigneSystemLevelThree
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
public class CurrentSystemProcess
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

