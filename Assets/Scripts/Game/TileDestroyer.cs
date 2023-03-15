using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    private Transform destructionPoint;
    private void Start()
    {
        destructionPoint = GameObject.Find("TileDestructionPoint").GetComponent<Transform>();
    }
    private void Update()
    {
        if(transform.position.z <= destructionPoint.position.z)
        {
            gameObject.SetActive(false);
        }
    }
}
