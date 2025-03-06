using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGlb2 : MonoBehaviour
{
    public TMP_InputField InputField;
    public Button Button;
    public TMP_Text Text;
    private void Start()
    {
        Button.onClick.AddListener(DoStart);
    }
    async void DoStart()
    {
        // First step: load glTF
        var gltf = new GLTFast.GltfImport();
        var success = await gltf.Load(InputField.text);

        if (success)
        {
            // Here you can customize the post-loading behavior

            // Get the first material
            var material = gltf.GetMaterial();
            Debug.LogFormat("The first material is called {0}", material.name);
            Text.text = material.name;

            // Instantiate the glTF's main scene
            await gltf.InstantiateMainSceneAsync(new GameObject("Instance 1").transform);
            // Instantiate the glTF's main scene
            await gltf.InstantiateMainSceneAsync(new GameObject("Instance 2").transform);

            // Instantiate each of the glTF's scenes
            for (int sceneId = 0; sceneId < gltf.SceneCount; sceneId++)
            {
                await gltf.InstantiateSceneAsync(transform, sceneId);
            }
        }
        else
        {
            Debug.LogError("Loading glTF failed!");
        }
    }
}
