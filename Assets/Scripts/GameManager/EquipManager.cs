using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipManager : MonoBehaviour
{
    //Component 受け取り用
    private List<GameObject> _equipUI_ObjList = new();
    private List<Text> _equipUI_TextList = new();
    private List<Text> _equipUI_Text2List = new();
    private List<Image> _equipUI_ImageList = new();
    private GameObject _equipUI;
    // Start is called before the first frame update
    //void Awake()
    //{
        
    //    gameObject.SetActive(false);
    //}
    void Start()
    {
        _equipUI = Resources.Load<GameObject>("Prefabs/EquipUI");
        //Crankを一つ持った状態で始める
        EQUIP_LIST.g_list[0].Quantity += 1;
        EQUIP_LIST.UpdateCost();

        Transform _UI_Contents = transform.Find("EquipPanel/Scroll View/Viewport/Content").GetComponent<Transform>();
        for (int i = 0; i < EQUIP_LIST.g_list.Count; i++)
        {
            _equipUI_ObjList.Add(Instantiate(_equipUI, _UI_Contents.position,
                UnityEngine.Quaternion.identity, _UI_Contents));
            //インスタンス化した設備オブジェクトの名前の変更
            _equipUI_ObjList[i].name = EQUIP_LIST.g_list[i].Name;
            //一度変数に入れないとボタンに渡す関数の引数for文のiの最後の値となる
            string nametmp = EQUIP_LIST.g_list[i].Name;
            _equipUI_ObjList[i].GetComponent<Button>().onClick.AddListener(() => GAME_MAIN.PayEquipCost(nametmp));
            //Componentの受け取り
            _equipUI_TextList.Add(_equipUI_ObjList[i].transform.Find("Text").GetComponent<Text>());
            _equipUI_Text2List.Add(_equipUI_ObjList[i].transform.Find("Text/Text2").GetComponent<Text>());
            _equipUI_ImageList.Add(_equipUI_ObjList[i].transform.Find("circle/circle2").GetComponent<Image>());
            _equipUI_TextList[i].text = EQUIP_LIST.g_list[i].DisplayCostText();
        }

    }

    // Update is called once per frame
    void Update()
    {

        ExpressUI();
        for (int i = 0; i < EQUIP_LIST.g_list.Count; i++)
        {
            //time= Time.deltaTime;
            EQUIP_LIST.g_list[i].Time += Time.deltaTime;
            if (EQUIP_LIST.g_list[i].IsTimeAboveSpan() && i != 0)
            {
                GAME_MAIN.capa += (EQUIP_LIST.g_list[i].GenerateAmount());
            }
        }
    }
        //設備UI表示
    public void ExpressUI()
    {
        for (int i = 0; i < EQUIP_LIST.g_list.Count; i++)
        {
            _equipUI_TextList[i].text = EQUIP_LIST.g_list[i].DisplayCostText();
            _equipUI_Text2List[i].text = EQUIP_LIST.g_list[i].DisplayWattText();
            if (EQUIP_LIST.g_list[i].Quantity > 0)
            {
                //print(total_rotate / 360f);
                if (i == 0)
                {
                    _equipUI_ImageList[i].fillAmount = CrankRotateManager.Total_Rotate / 360f;
                }
                else
                {
                    _equipUI_ImageList[i].fillAmount = EQUIP_LIST.g_list[i].Time / EQUIP_LIST.g_list[i].Span;
                }
            }

        }
    }

}
