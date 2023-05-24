using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeClass
{
    public string Type;
    public int DefCost;
    public int Upgrade_Number;
    public int Efficiency;
    public BigInteger Cost = 0 ;
    public UpgradeClass(string type, int def_cost, int eff,int upgrade_number)
    {
        Type = type;
        DefCost = def_cost;
        Efficiency = eff;
        Upgrade_Number = upgrade_number;
        Cost = (int)(Mathf.Pow(15f, (upgrade_number + 1)) * def_cost);
    }
    public void setCost()
    {
        this.Cost = (int)(Mathf.Pow(15f, (Upgrade_Number + 1 )) * DefCost);
    }
}

public class UpgradeManeger : MonoBehaviour
{
    private List<GameObject> _upgradeObjList = new();
    private List<UpgradeClass> _upgradeClassList = new();
    private int[] _upgradeEffList = { 2 , 2 , 2 , 5 , 5 , 5, 10 , 10 ,10 , 20 };

    GameObject _upgradeUI;
    //void Awake()
    //{
        
    //    gameObject.SetActive(false);
    //}
    void Start()
    {
        _upgradeUI = Resources.Load<GameObject>("Prefabs/UpgradeUI");
        for (int i = 0; i < EQUIP_LIST.g_list.Count; i++)
        {
            Transform _UI_Contents = transform.Find("UpgradePanel/Scroll View/Viewport/Content").GetComponent<Transform>();
            _upgradeObjList.Add(Instantiate(_upgradeUI, _UI_Contents.position, UnityEngine.Quaternion.identity, _UI_Contents));

            _upgradeClassList.Add(new UpgradeClass(EQUIP_LIST.g_list[i].Name,
                    EQUIP_LIST.g_list[i].DefCost, _upgradeEffList[0], 0));
            _upgradeObjList[i].SetActive(true);
            int button_num = i;
            _upgradeObjList[i].GetComponent<Button>().onClick.AddListener(() => Upgrade_PayCost(button_num));

            Text _text = _upgradeObjList[i].transform.Find("Text").GetComponent<Text>();
            Text _text2 = _upgradeObjList[i].transform.Find("Text2").GetComponent<Text>();

            _text.text = EQUIP_LIST.g_list[i].Name;
            _text2.text = "費用: " + NUMBERFORMAT.FormatNumberWithUnit(_upgradeClassList[i].Cost)
                + "\n効率: " + NUMBERFORMAT.FormatNumberWithUnit(_upgradeEffList[_upgradeClassList[i].Upgrade_Number]) + "倍";

        }
    }
    //ボタンが押されたら次のアップグレードに更新する
    private void Upgrade_PayCost(int button_num)
    {
        if (GAME_MAIN.EnablePayCost(_upgradeClassList[button_num].Cost))
        {
            GAME_MAIN.PayCost(_upgradeClassList[button_num].Cost);
            EQUIP_LIST.EquipUpgrade(button_num,
            _upgradeClassList[button_num].Efficiency);
            _upgradeClassList[button_num].setCost();
            MakeNewUpgrade(button_num);
        }
    }
    
    public void MakeNewUpgrade(int button_num)
    {
        _upgradeClassList[button_num] = new UpgradeClass(EQUIP_LIST.g_list[button_num].Name,
                    EQUIP_LIST.g_list[button_num].DefCost, 
                    _upgradeEffList[_upgradeClassList[button_num].Upgrade_Number],
                    _upgradeClassList[button_num].Upgrade_Number + 1 );
        Text text = _upgradeObjList[button_num].transform.Find("Text").GetComponent<Text>();
        Text text2 = _upgradeObjList[button_num].transform.Find("Text2").GetComponent<Text>();
        text.text = EQUIP_LIST.g_list[button_num].Name;
        text2.text = "費用: " + NUMBERFORMAT.FormatNumberWithUnit(_upgradeClassList[button_num].Cost)
            + "\n効率: " + NUMBERFORMAT.FormatNumberWithUnit(_upgradeEffList[_upgradeClassList[button_num].Upgrade_Number]) + "倍";

    }
}
