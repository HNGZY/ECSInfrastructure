using UnityEngine;
using UnityEngine.UI;
#region 控件
public class Tips
{
    static Tips T;
    static Transform tips;//自己的实体
    static Transform content;//自己Item的父级
    static Button close;//关闭的按钮
    public static Tips Get()
    {
        if (T == null)
        {
            T = new Tips();
            //生成弹窗
            tips = GameObject.Instantiate(Resources.Load<Transform>("ECS/Hint"), GameObject.Find("Canvas").transform, false);
            //找到父级
            content = tips.Find("Scroll View/Viewport/Content");
            //找到关闭按钮
            close = tips.Find("Close").GetComponent<Button>();
            //关闭执行对应的方法
            close.onClick.AddListener(() =>
            {
                foreach (Transform item in content)
                {
                    GameObject.Destroy(item.gameObject);
                }
                tips.gameObject.SetActive(false);
            });
        }
        return T;
    }

    public void Show(Item item)
    {
        tips.gameObject.SetActive(true);//打开面板
        foreach (var value in item.dic)
        {
            //生成按钮，更改名字
            GameObject button = GameObject.Instantiate(Resources.Load<GameObject>("ECS/Item"), content, false);
            string text = value.Value.GetButName();
            button.transform.GetComponentInChildren<Text>().text = text;
            //对应的按钮执行对应的方法
            button.GetComponent<Button>().onClick.AddListener(() => {
                value.Value.Do();
            });
        }
    }
}
#endregion