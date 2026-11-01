using UnityEngine;

public abstract class MenuItem : MonoBehaviour
{
    public string Name { get; set; }
    public float Price { get; set; }

    public virtual float GetPrice() { return Price; }
}

