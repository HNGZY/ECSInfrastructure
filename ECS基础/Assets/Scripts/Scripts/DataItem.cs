#region   数据模板
public class DataCfg
{
    public int id;
    public string name;
    public string icon;

    public int isUse;
    public int isSell;
}

public class DataItem
{
    public DataCfg cif;
    /// <summary>
    /// 根据传过来的id去对应的配置表找，返回对应的数据类型
    /// </summary>
    /// <param name="id"></param>
    public DataItem(int id)
    {
        cif = new DataCfg();
        cif.id = id;
        cif.name = id.ToString();
        cif.icon = id.ToString();
        switch (id)
        {
            case 1:
                cif.isUse = 0;
                cif.isSell = 1;
                break;
            case 2:
                cif.isUse = 1;
                cif.isSell = 0;
                break;
            case 3:
                cif.isUse = 1;
                cif.isSell = 1;
                break;
            default:
                break;
        }
    }

    public DataItem GetItemDataById(int id)
    {
        DataItem data = new DataItem(id);
        return data;
    }
}
#endregion   