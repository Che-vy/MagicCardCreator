using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Creator/New card Asset")] 
public class Card : ScriptableObject
{
    public new string name;
    public int manaCost;
    public Common.CardColor cardColor;
    public Texture sprite;
    public string textBox;
    public Common.CardRarity cardRarity;

    public Card() {
        name = "New Card";
        manaCost = 0;
        cardColor = Common.CardColor.COLORLESS;
        textBox = "Effect Goes here";
        cardRarity = Common.CardRarity.COMMON;
    }
}
