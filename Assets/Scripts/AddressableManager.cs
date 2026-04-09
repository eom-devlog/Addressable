using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    public string address; // Addressables에 등록한 주소
    private AsyncOperationHandle<GameObject> handle;

    public void Load()
    {
        handle = Addressables.LoadAssetAsync<GameObject>(address);
        handle.Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(op.Result);
            }
            else
            {
                Debug.LogError($"Addressables load failed: {op.OperationException}");
            }
        };
    }

    public void Release()
    {
        if (handle.IsValid())
        {
            Addressables.Release(handle);
        }
    }
}
