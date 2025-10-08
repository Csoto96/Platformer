using UnityEngine;
[CreateAssetMenu(menuName = "GenericSpawner")]
public class GenericSpawner : ScriptableObject
{
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab is null");
            return null;
        }
        GameObject spawnedObject = Instantiate(prefab, position, rotation);
        return spawnedObject;
    }
}
