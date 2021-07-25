using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
{
    short attributes;

    public CardData(int colorShift, int shapeShift, int amountShift, int fillShift)
    {
        //Check if the argument passed to the constructor are valid.
        if (colorShift > 2 || shapeShift > 2 || amountShift > 2 || fillShift > 2)
        {
            Debug.Log($"Wrong parameters for creating CardData instance: {colorShift}, {shapeShift}, {amountShift}, {fillShift}");
        }
        //Bitshift values into the following pattern **** AAA BBB CCC DDD, where AAA=Color, BBB=Shape, CCC=Amount, DDD=Fill and **** is unused bits
        attributes = (short)((1 << (colorShift + 9)) | (1 << (shapeShift + 6)) | (1 << (amountShift + 3)) | (1 << fillShift));
    }

    //Debugging method to check card bits
    public void PrintCardBits()
    {
        string bitString = string.Empty;

        for (int i = (sizeof(short) * 8) - 1; i >= 0; i--)
        {
            if ((attributes & (1 << i)) == (1 << i))
                bitString += "1";
            else
                bitString += "0";
        }

        Debug.Log($"CardData: {bitString}");
    }
}
