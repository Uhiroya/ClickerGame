using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Numerics;
using UnityEngine;

static public class NUMBERFORMAT 
{
    public static string FormatNumberWithUnit(BigInteger value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        else if (value < 1000000)
        {
            return FormatNumberdot(value / 1000, value) + "K";
        }
        else if (value < 1000000000)
        {
            return FormatNumberdot(value / 1000000, value) + "M";
        }
        else if(value < 1000000000000)
        {
            return FormatNumberdot(value / 1000000000, value) + "G";
        }
        else { return value.ToString(); }
    }
    private static string FormatNumberdot(BigInteger num,BigInteger value)
    {
        if (num < 10) {
            return value.ToString("").Substring(0,1)+"."+ value.ToString("").Substring(1,3);
        }
        else if(num < 100)
        {
            return value.ToString("").Substring(0, 2) + "." + value.ToString("").Substring(2, 2);
        }
        else if(num < 1000)
        {
            return value.ToString("").Substring(0, 3) + "." + value.ToString("").Substring(3, 1);
        }
        return value.ToString();
    }
}
