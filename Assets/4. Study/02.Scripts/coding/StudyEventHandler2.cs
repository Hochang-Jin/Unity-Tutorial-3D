using System;
using UnityEngine;

public class StudyEventHandler2 : MonoBehaviour
{
    public class DataClass : EventArgs
    {
        public string name;

        public DataClass(string name)
        {
            this.name = name;
        }
    }
    
    private event EventHandler<DataClass> handler;

    private void Start()
    {
        handler += MethodB;

        DataClass dataClass = new DataClass("data");
        handler?.Invoke(this, dataClass);
    }

    private void MethodB(object o, DataClass e)
    {
        // DataClass dataClass = (DataClass)e;
        // EventHandler<DataClass> 를 사용해서 형변환이 따로 필요 없어짐
        DataClass dataClass = e;
        
        
    }
}
