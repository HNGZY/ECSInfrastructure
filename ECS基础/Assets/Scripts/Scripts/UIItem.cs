using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 控件
public class UIItem
{
    public Dictionary<ShowType, Action> dic;//显示层  对应的方法
    public Item item;//实例
    public Text text;//自己的Item的Text

    public UIItem(string name,Transform parent)//构造，传入生成的Item的名字，和他的父级
    {
        dic = new Dictionary<ShowType, Action>()
        {
            {ShowType.bag,()=>{Tips.Get().Show(item); } },//走背包的方法
            {ShowType.shop,()=>{; }}
        };
        GameObject game = GameObject.Instantiate(Resources.Load<GameObject>("ECS/"+name), parent, false);//生成Item的实例
        game.GetComponent<Button>().onClick.AddListener(() =>
        {
            dic[item.show].Invoke();//执行 对应的显示层的 委托
        });
        text = game.transform.GetComponentInChildren<Text>();//找到自己的Text组件
    }

    public void SetItem(DataItem data,ShowType type)//设置自己的显示层
    {
        SetItem(Item.CreateEntityByID(data.cif.id, type));//调用了Item的静态生成实例的方法
    }

    public void SetItem(Item item)//存储Item和更新自己的名字
    {
        this.item = item;//存储Item
        text.text = this.item.data.cif.name;//更新名字
    }
}


#endregion