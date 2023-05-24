using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
static public class GAME_MAIN
{

    static public BigInteger money = 100;
    static public BigInteger capa=0;


    //充電売却用
    static public void SoldEnergy(int energy,int Getmoney)
    {
        capa -= energy;
        money += Getmoney;
    }
    //コスト支払い
    static public void PayCost(BigInteger cost)
    {
         money -=cost ;
    }
    //設備購入　コストのアプデ
    static public void PayEquipCost(string name)
    {
        for (int i = 0; i <  EQUIP_LIST.g_list.Count; i++)
        {
            if ( EQUIP_LIST.g_list[i].Name == name)
            {
                if (money >=  EQUIP_LIST.g_list[i].Cost)
                {
                    money -=  EQUIP_LIST.g_list[i].Cost;
                    EQUIP_LIST.g_list[i].Quantity += 1;
                    EQUIP_LIST.UpdateCost();
                }
            }

        }

    }
    static public bool EnableSoldEnergy(int energy)
    {
        if (capa >= energy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static public bool EnablePayCost(BigInteger cost)
    {
        if (money >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
