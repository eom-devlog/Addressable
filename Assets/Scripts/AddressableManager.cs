using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    string assetAddress = "Assets/Addressables/GameObject/Black.prefab"; // Addressables에 설정된 주소

    void Start()
    {
        LoadAsset();
    }

    public void LoadAsset()
    {
        Debug.Log("Attempting to load asset: " + assetAddress);
        var handle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
        handle.Completed += OnLoadDone;
    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(obj.Result); // 에셋 인스턴스화
        }
        else
        {
            Debug.LogError("Failed to load Addressable asset.");
        }
    }
}
