using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldClass
{
    public string Name;
    public int Quantity;
    public int Amount;
    public float Rate;
    public SoldClass(string name, int qua, int amount, float rate)
    {
        Name = name;
        Quantity = qua;
        Amount = amount;
        Rate = rate;
    }
}

public class SoldManeger : MonoBehaviour
{
    private List<SoldClass> SoldList = new List<SoldClass>();
    private List<GameObject> _soldUI_ObjList = new List<GameObject>();
    private List<Dropdown> _dropdowns = new List<Dropdown>();
    private List<Text> _soldUI_TextList = new List<Text>();
    private List<Text> soldUI_Text2List = new List<Text>();
    private float time;
    private GameObject _soldUI;
 

    //void Awake()
    //{
        
    //    gameObject.SetActive(false);
    //}
    void Start()
    {
        _soldUI = Resources.Load<GameObject>("Prefabs/SoldUI");
        Transform _UI_Contents = transform.Find("SoldPanel/Scroll View/Viewport/Content").GetComponent<Transform>();       
        //SetSoldClass(string name, int qua, int amount, float rate)
        SoldList.Add(new SoldClass("スマホ", 0, 5, 1.2f));
        SoldList.Add(new SoldClass("TV", 0, 50, 2f));
        SoldList.Add(new SoldClass("PC", 0, 300, 2.5f));
        SoldList.Add(new SoldClass("ストーブ", 0, 1000, 3f));
        for (int i = 0; i < SoldList.Count  ; i++)
        {
            _soldUI_ObjList.Add(Instantiate(_soldUI, _UI_Contents.position,
                UnityEngine.Quaternion.identity, _UI_Contents));
            _soldUI_TextList.Add(_soldUI_ObjList[i].transform.Find("Label").GetComponent<Text>());
            soldUI_Text2List.Add(_soldUI_ObjList[i].transform.Find("Label/Text").GetComponent<Text>());
            _dropdowns.Add(_soldUI_ObjList[i].GetComponentInChildren<Dropdown>());
            _soldUI_TextList[i].text = SoldList[i].Name;
            soldUI_Text2List[i].text =$"{SoldList[i].Amount.ToString()} W/s 消費\n 1W→{SoldList[i].Rate.ToString()}￥";
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            for (int i = 0; i < SoldList.Count; i++)
            {
                SoldList[i].Quantity = _dropdowns[i].value ;
                SoldClass SL = SoldList[i];
                if (SL.Quantity > 0 && GAME_MAIN.EnableSoldEnergy(SL.Amount * SL.Quantity))
                {
                    
                    //SoldEnergy(int energy,int Getmoney)
                    GAME_MAIN.SoldEnergy(SL.Amount * SL.Quantity,
                        (int)(SL.Amount * SL.Quantity * SL.Rate));
                }
                time = 0.0f;
            }
        }

    }
}
