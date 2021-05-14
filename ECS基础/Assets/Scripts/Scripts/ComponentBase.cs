#region  组件
using UnityEngine;

public abstract class ComponentBase
{
    public virtual void Do()//执行的方法
    {

    }

    public abstract string GetButName();//返回对应的名字
}

public class Use : ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("使用物品");
    }
    public override string GetButName()
    {
        return "使用物品";
    }
}

public class Sell : ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("出售物品");
    }

    public override string GetButName()
    {
        return "出售物品";
    }
}
#endregion