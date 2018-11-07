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


    [MenuItem("Card Creator/Open")]
    public static void OpenWindow()
    {
        Init();
        EditorWindow.GetWindow<CardCreatorEditor>();
    }

    public static void Init()
    {
        cardList = new List<Card>();
        cardList.Add(new Card());
    }


    public void OnGUI()
    {

        PartA();
        PartB();

    }

    public void PartA() { }

    public void PartB()
    {

        EditorGUILayout.BeginHorizontal();

        //Button "Previous card"
        EditorGUILayout.BeginVertical();
        GUILayout.Button("<<");
        EditorGUILayout.EndVertical();


        //Card Layout
        EditorGUILayout.BeginVertical();
        //Card Name & Mana Cost 
        EditorGUILayout.BeginHorizontal();
        cardList[currentIndex].name = EditorGUILayout.TextField("Name", GUILayout.Width(100));
        Int32.TryParse(EditorGUILayout.TextField("Mana Cost", GUILayout.Width(btnWidth)), out cardList[currentIndex].manaCost);
        EditorGUILayout.EndHorizontal();

        //Card Art
        EditorGUILayout.BeginHorizontal();
        if (!GUILayout.Button((Texture)(Resources.Load("Textures/1")), GUILayout.Width(200f), GUILayout.Height(150f)))
        { }
        EditorGUILayout.EndHorizontal();

        //Card rarity logo
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.EndHorizontal();

        //Card Text Box (effect and flavor text) 
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.EndHorizontal();

        //Artist
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();


        //Button "Next card"
        EditorGUILayout.BeginVertical();
        GUILayout.Button(">>");
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }

}
