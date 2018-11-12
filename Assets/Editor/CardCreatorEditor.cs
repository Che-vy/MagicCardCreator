using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CardCreatorEditor : EditorWindow
{
    public static List<Card> cardList;
    public static int currentIndex;
    public static bool IsCardSaved;
    public static float btnWidth = 25f;
    public static float cardWidth = 225f;
    public readonly float pct10 = cardWidth * .1f, pct20 = cardWidth * .2f, pct25 = cardWidth * .25f, pct30 = cardWidth * .3f;


    [MenuItem("Card Creator/Open %#1")]
    public static void OpenWindow()
    {
        Init();
        EditorWindow.GetWindow<CardCreatorEditor>();
    }

    public static void Init()
    {
        cardList = new List<Card>();
        cardList.Add(ScriptableObject.CreateInstance("Card") as Card);
    }


    public void OnGUI()
    {

        PartA();
        PartB();

    }

    public void PartA() { }

    public void PartB()
    {

        EditorGUILayout.BeginHorizontal(GUILayout.Width(300));

        //Button "Previous card"
        EditorGUILayout.BeginVertical();
        GUILayout.Button("<<");
        EditorGUILayout.EndVertical();


        //Card Layout
        {
            GUILayout.BeginVertical(Resources.Load<Texture>(Common.GetBorderColor(cardList[currentIndex].cardColor)), new GUIStyle(), GUILayout.Width(cardWidth));
            //Card Name & Mana Cost 
            EditorGUILayout.BeginHorizontal();
            cardList[currentIndex].name = EditorGUILayout.TextField("Name", GUILayout.Width(pct30));
            EditorGUILayout.LabelField("", GUILayout.Width(pct25 * 2));
            Int32.TryParse(EditorGUILayout.TextField("Mana Cost", GUILayout.Width(pct20)), out cardList[currentIndex].manaCost);
            EditorGUILayout.EndHorizontal();

            //Card Art
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(pct10 * .5f));

            if (!cardList[currentIndex].imgPath.Equals("") && cardList[currentIndex].imgPath.Contains("Assets"))
            {
                cardList[currentIndex].imgPath = cardList[currentIndex].imgPath.Remove(0, cardList[currentIndex].imgPath.IndexOf("Textures"));
                cardList[currentIndex].imgPath = cardList[currentIndex].imgPath.Remove(cardList[currentIndex].imgPath.IndexOf("."));
            }

            if (GUILayout.Button((Resources.Load<Texture>(cardList[currentIndex].imgPath)), GUILayout.Width(pct30 * 3), GUILayout.Height(pct30 * 2)))
            {
                cardList[currentIndex].imgPath = EditorUtility.OpenFilePanel("Select Image File", Application.dataPath, "bmp,jpg,jpeg,png");
            }

            EditorGUILayout.LabelField("", GUILayout.Width(pct10 * .5f));
            EditorGUILayout.EndHorizontal();

            //Card rarity logo
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(pct25 * 2.75f));
            EditorGUILayout.LabelField(cardList[currentIndex].cardRarity.ToString(), GUILayout.Width(pct25));
            EditorGUILayout.LabelField("", GUILayout.Width(pct25 * .25f));
            EditorGUILayout.EndHorizontal();

            //Card Text Box (effect and flavor text) 
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(pct10 * .5f));
            cardList[currentIndex].textBox = EditorGUILayout.TextField(cardList[currentIndex].textBox, GUILayout.Width(pct30*3), GUILayout.Height(pct30*1.75f));
            EditorGUILayout.LabelField("", GUILayout.Width(pct10 * .5f));
            EditorGUILayout.EndHorizontal();

            //Artist
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }

        //Button "Next card"
        EditorGUILayout.BeginVertical();
        GUILayout.Button(">>");
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }

}
