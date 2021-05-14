#region   数据实体
using System.Collections.Generic;

public enum ShowType//显示的位置
{
    bag,
    shop
}
public enum ComponentType//组件的类型
{
    use,
    sell
}

public class Item//Item的数据的实例
{
    public ShowType show = ShowType.bag;//默认是背包层显示
    public Dictionary<ComponentType, ComponentBase> dic = new Dictionary<ComponentType, ComponentBase>();
    public DataItem data;//数据


    static public Item CreateEntityByID(int id, ShowType type = ShowType.bag)//根据ID生成一个实例数据
    {
        Item item = new Item();
        item.CreateByID(id, type);
        return item;//返回数据实例
    }
    /// <summary>
    /// 根据ID生成数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    public void CreateByID(int id, ShowType type = ShowType.bag)
    {
        data = new DataItem(id);//创建一个数据实例
        InjectAction(type);//注入方法
    }

    public void InjectAction(ShowType type)
    {
        show = type;//更新显示层

        if (data.cif.isUse == 1)//判断是否显示使用
        {
            Use use = new Use();//实例使用组件
            dic.Add(ComponentType.use, use);//加入字典，后面一致
        }
        if (data.cif.isSell == 1)
        {
            Sell sell = new Sell();
            dic.Add(ComponentType.sell, sell);
        }
    }

    
}

#endregion