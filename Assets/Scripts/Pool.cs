using UnityEngine;
[CreateAssetMenu(menuName = "Custom/Pool")]
public class Pool : ScriptableObject
{
    public string tag;
    public GameObject desiredPrefab;
    public int size;
}
