using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData
{
    public ProductInfo[] productInfos;
}

[System.Serializable]
public class ProductInfo
{
    public int id;
    public string name;
    public Position pos;
}

[System.Serializable]
public class Position
{
    public float pos_x;
    public float pos_y;
    public float pos_z;
}

public class JsonReader : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        string loadjson = Resources.Load<TextAsset>("json/jsonsample").ToString();

        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadjson, jsonData);

        foreach (var item in jsonData.productInfos)
        {
            Debug.Log("ID: " + item.id);
            Debug.Log("製品名: " + item.name);
            Debug.Log("x座標: " + item.pos.pos_x);
            Debug.Log("y座標: " + item.pos.pos_y);
            Debug.Log("z座標: " + item.pos.pos_z);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}