using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LightWizard : ScriptableWizard
{
    public new string name;
    public float range = 10;
    public float intensity = 20;
    public Color color = Color.red;

    [MenuItem("GameObject/Create Light Wizard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<LightWizard>("Create Light", "Create", "Apply");
    }

    void OnWizardCreate()
    {
        GameObject go = new GameObject("New Light");
        go.name = name;
        Light lt = go.AddComponent<Light>();
        lt.range = range;
        lt.color = color;
    }

    void OnWizardUpdate()
    {
        helpString = "Please set the color of the light!";
    }

    // When the user presses the "Apply" button OnWizardOtherButton is called.
    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            GameObject[] slected = Selection.gameObjects;

            foreach (GameObject go in slected)
            {
                Light light = go.GetComponent<Light>();
                light.color = color;
                light.range = range;
                light.intensity = intensity;
            }
        }
    }
}
