using UnityEngine;
using UnityEditor;

public class SceneSetup : ScriptableWizard
{
    [MenuItem("SceneSetup/SetupStandard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<SceneSetup>("Setup", "Create", "Sort");
    }

    void OnWizardCreate()
    {
        GameObject coreItems = new GameObject();
        coreItems.name = "---------CoreItems";
        GameObject lightParent = new GameObject();
        lightParent.name = "---------Lights";
        GameObject environment = new GameObject();
        environment.name = "---------Environment";
        GameObject sound = new GameObject();
        sound.name = "---------Sound";
    }

    void OnWizardUpdate()
    {
        helpString = "Basic setup/sorting";
    }

    private void OnWizardOtherButton()
    {
        GameObject[] collections = FindObjectsOfType<GameObject>();
        Light[] allLights = FindObjectsOfType<Light>();
        Camera[] allCameras = FindObjectsOfType<Camera>();
        AudioSource[] audio = FindObjectsOfType<AudioSource>();

        foreach (GameObject go in collections)
        {
            if (go.name.EndsWith("Lights"))
            {
                foreach (Light lig in allLights)
                {
                    lig.transform.parent = go.transform;
                }
            }
            else if (go.name.EndsWith("CoreItems"))
            {
                foreach (Camera cam in allCameras)
                {
                    cam.transform.parent = go.transform;
                }
            }
            else if (go.name.EndsWith("Environment"))
            {

            }
            else if (go.name.EndsWith("Sound"))
            {
                foreach (AudioSource aud in audio)
                {
                    aud.transform.parent = go.transform;
                }
            }
        }
    }
}
