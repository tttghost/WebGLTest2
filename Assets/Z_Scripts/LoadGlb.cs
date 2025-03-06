using GLTFast;
using GLTFast.Loading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using EasyButtons; // UniTask 사용

public class LoadGlb : MonoBehaviour
{
    public TMP_InputField InputField;
    public TMP_Text Text;
    public Button Button;
    private GameObject loadedModel; // 기존 모델 제거용

    [Button]
    private void AAA(int a, string b)
    {
        Debug.Log($"fucdefghi {a} {b}");
    }

    private void Awake()
    {
        Button.onClick.AddListener(() =>
        {
            // 기존 모델 삭제
            if (loadedModel != null)
            {
                Destroy(loadedModel);
            }
            LoadAndInstantiateGlb().Forget();
        });
    }

    private async UniTaskVoid LoadAndInstantiateGlb()
    {
        string url = InputField.text;
        if (!url.StartsWith("http"))
        {
            Text.text = "Invalid URL";
            return;
        }

        var gltf = new GltfImport();
        bool success = await gltf.Load(url);
        if (success)
        {
            Text.text = "success";
            // 인스턴스화 후 기본 머티리얼 강제 적용
            loadedModel = new GameObject("GLB_Model");
            await gltf.InstantiateMainSceneAsync(loadedModel.transform);
            ApplyMaterials(loadedModel);
        }
        else
        {
            Text.text = "fail";
        }
    }

    private void ApplyMaterials(GameObject model)
    {
        var renderers = model.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            if (renderer.material == null)
            {
                // 기본 PBR 머티리얼 적용
                renderer.material = new Material(Shader.Find("Standard"));
            }
        }
    }
}
