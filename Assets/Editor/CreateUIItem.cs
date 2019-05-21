using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateUIItem {

    [MenuItem("MasterStyles/Apply Header Style")]
    public static void ApplyHeaderStyle() {
        if (Selection.activeGameObject == null || Selection.activeGameObject.GetComponent<Text>() == null) {
            Debug.LogError("No Selected Text Object");
        } else {
            Text t = Selection.activeGameObject.GetComponent<Text>();
            MasterStyles.ApplyStyle(t, TextStyle.Header);
        }
    }

    [MenuItem("GameObject/UI/Header")]
    public static void CreateHeader() {
        CreateText(TextStyle.Header);
    }

    [MenuItem("GameObject/UI/Paragraph")]
    public static void CreateParagraph() {
        Debug.Log("Creating a Paragraph.");
        CreateText(TextStyle.Paragraph);
    }

    public static void CreateText(TextStyle ts) {
        GameObject g = new GameObject(ts.ToString());
        Text t = g.AddComponent<Text>();
        t.text = "New " + ts.ToString();

        Transform p;

        if (Selection.activeGameObject == null || Selection.activeGameObject.GetComponent<Canvas>() == null) {
            if (GameObject.FindObjectOfType<Canvas>() == null) {
                new GameObject("Canvas").AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            }
            p = GameObject.FindObjectOfType<Canvas>().transform;
        } else {
            p = Selection.activeGameObject.transform;
        }

        g.transform.SetParent(p, false);
        Selection.activeGameObject = g;

        MasterStyles.ApplyStyle(t, ts);
    }
	
}

public class MasterStyles {

    public static void ApplyStyle(Text t, TextStyle ts) {
        if(ts == TextStyle.Header) {
            t.color = Color.black;
            t.alignment = TextAnchor.MiddleCenter;
            t.verticalOverflow = VerticalWrapMode.Overflow;
            t.font = Font.CreateDynamicFontFromOSFont(Font.GetOSInstalledFontNames()[0], 20);
            t.fontStyle = FontStyle.Bold;
            t.fontSize = 24;
        } else if (ts == TextStyle.Paragraph) {
            t.color = Color.gray;
            t.verticalOverflow = VerticalWrapMode.Truncate;
            t.font = Font.CreateDynamicFontFromOSFont(Font.GetOSInstalledFontNames()[0], 20);
            t.fontStyle = FontStyle.Normal;
            t.fontSize = 16;
        }

    }
}

public enum TextStyle {
    Paragraph, 
    Header
}
