using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class OpenDefaultScene
{
    static OpenDefaultScene()
    {
        EditorApplication.update += LoadSceneOnStart;
    }

    static void LoadSceneOnStart()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode) return;

        string scenePath = "Assets/Scenes/SampleScene.unity";
        if (!EditorSceneManager.GetActiveScene().path.Equals(scenePath))
        {
            EditorSceneManager.OpenScene(scenePath);
        }

        EditorApplication.update -= LoadSceneOnStart;
    }
}
