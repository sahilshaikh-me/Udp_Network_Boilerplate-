using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class NewDataBase : MonoBehaviour
{
    private static NewDataBase _instance;
    public static NewDataBase instance { get { return _instance; } }

    public List<NewUser> user = new List<NewUser>();

    public string Name;
    public string Passowrd;
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
   

    private void Start()
    {
        
    }

}
  [System.Serializable]
    public class NewUser
    {
        public string Name;
        public string Passowrd;
        public List<NewSystem> system = new List<NewSystem>();
        public NewUser(string name, string passowrd)
        {
            this.Name = name;
            this.Passowrd = passowrd;
        }
       
        public NewUser()
        {

        }
   
    }
    [System.Serializable]
    public class NewSystem
    {
        public List<NewProcess> Process = new List<NewProcess>();

        public string SystemName;
        public int LruCompleted;
        public int TotalLru;
        public NewSystem(string Name,int totallru)
        {
            SystemName = Name;
            TotalLru = totallru;    
        }
        public enum ProcessState
        {
            Todo,
            Doing,
            Done
        }
        public ProcessState state = new ProcessState();



}
    [System.Serializable]
    public class NewProcess
    {
        public string ProcessName;
        public int SystemCompleted;
        public int TotalSystem;
    public NewProcess(string processNames)
        {
            ProcessName = processNames;
        }

        public enum ProcessState
        {
            Todo,
            Doing,
            Done
        }
        public ProcessState state = new ProcessState();
    }