using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common {
    
    public enum CardColor { BLACK, BLUE, GREEN, RED, WHITE, COLORLESS };
    public enum CardRarity { COMMON, UNCOMMON, RARE, MYTHICRARE }


    public static string GetBorderColor(CardColor color) {
        string toRet = "";

        switch (color)
        {
            case CardColor.BLACK:
                toRet = "Textures/border_b";
                break;
            case CardColor.BLUE:
                toRet = "Textures/border_u";
                break;
            case CardColor.COLORLESS:
                toRet = "Textures/border_artifact";
                break;
            case CardColor.GREEN:
                toRet = "Textures/border_g";
                break;
            case CardColor.RED:
                toRet = "Textures/border_r";
                break;
            case CardColor.WHITE:
                toRet = "Textuers/border_w";
                break;
        }


        return toRet;
    }
}
