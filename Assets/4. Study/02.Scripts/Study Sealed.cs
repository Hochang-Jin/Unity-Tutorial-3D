using UnityEngine;

public class ParentClass : MonoBehaviour
{
    public virtual void Method()
    {
        Debug.Log("Method");
    }
}

public class StudySealed : ParentClass
{
    public sealed override void Method()
    {
        base.Method();
        
        Debug.Log("Override Method");
    }
}

public class ChildClass : StudySealed
{
    public void Ms()
    {
        Method();
    }
}
