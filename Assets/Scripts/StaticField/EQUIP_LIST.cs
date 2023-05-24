using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
//İ”õƒNƒ‰ƒX
public class GeneratorClass
{
    public string Name { get; private set; } = "";
    public int  DefCost { get; private set; } = 1 ;
    public BigInteger Cost { get; private set; } = 0;
    public float Span = -1;
    public int Efficiency = 1 ;
    public float Time = 0f ;
    public int Quantity = 0 ;
    private string _UItext = "";
    private string _UItext2 = "";
    public GeneratorClass(string name, float span, int eff,int def_cost)
    {
        Name = name;
        Span = span;
        Efficiency = eff;
        DefCost  = def_cost;
    }
    public void SetCost()
    {
        Cost = (int)(Mathf.Pow(1.5f, Quantity) * DefCost);
    }
    public bool IsTimeAboveSpan()
    {
        if(Time < Span) {  return false; }
        else 
        { 
            Time = 0f;
            return true; 
        }
    }
    public string DisplayCostText()
    {
        _UItext = $"{Name}{NUMBERFORMAT.FormatNumberWithUnit(Quantity)}ŒÂ\n”ï—p :{NUMBERFORMAT.FormatNumberWithUnit(Cost)}";
        return _UItext;
    }
    public string DisplayWattText()
    {
        if (Span > 0)
        {
            _UItext2 = $"{NUMBERFORMAT.FormatNumberWithUnit(Quantity * Efficiency)}W/\n {Span}/s";
            return _UItext2;
        }
        else
        {
            _UItext2 = $"{NUMBERFORMAT.FormatNumberWithUnit(Quantity * Efficiency)}W/r";
            return _UItext2;
        }
    }
    public int GenerateAmount()
    {
        return Quantity * Efficiency;
    }
}
//İ”õ‚Ì‰Šúİ’è
static public class EQUIP_LIST
    
{
    static public Dictionary<int,GeneratorClass> g_list = new Dictionary<int, GeneratorClass>()
    {
        //{key,"string name, float span, int eff, int def_cost}
        {0,new GeneratorClass("è‰ñ‚µ", -1f , 1 ,3 ) },
        {1,new GeneratorClass("‘¾—zŒõ" ,3f , 8 , 15 ) },
        {2,new GeneratorClass("•——Í",1.5f , 5 , 35 ) },
        {3,new GeneratorClass("…—Í",1.5f ,10 , 50 ) },
        {4,new GeneratorClass("‰Î—Í",1.5f , 50 , 75 )}
    };
    static public void UpdateCost()
    {
        for(int i=0;i < g_list.Count;i++)
        {
            g_list[i].SetCost();
        }
    }
    static public void EquipUpgrade(int index, int eff_magni)
    {
        g_list[index].Efficiency *= eff_magni;
    }
    static public int GetKey(string item)
    {
        int key = 0;
        foreach(var itemname in g_list)
        {
            if (item == itemname.Value.Name)
            {
                key=itemname.Key;
            }
        }
        return key;
    }

}
