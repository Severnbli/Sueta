using UnityEngine;
using UnityEditor;

public class AssignMaterial : ScriptableWizard
{
    public bool isRecursively = true;
    public Material material;
    string label = "Select Game Objects";
    GameObject[] objects;

    void OnWizardUpdate()
    {
        helpString = label;
        isValid = (material != null);
    }

    void OnWizardCreate()
    {
        objects = Selection.gameObjects;
        foreach (GameObject go in objects)
        {
            changeMaterial(go);
        }
    }

    void changeMaterial(GameObject go)
    {
        if (go.GetComponent<Renderer>())
        {
            go.GetComponent<Renderer>().material = material;
        }
        if (isRecursively)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                changeMaterial(go.transform.GetChild(i).gameObject);
            }
        }
    }

    [MenuItem("Custom/Assign Material", false, 4)]
    static void assignMaterial()
    {
        ScriptableWizard.DisplayWizard("Assign Material", typeof(AssignMaterial), "Assign");
    }
}