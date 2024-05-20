using UnityEngine;

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite sprite;
    public GameObject prefab;
    public Vector3 offsetPosition;
    public Vector3 rotation;
}
