using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private int tileSelector;

    public ObjectPooler[] pools;
    public Transform generationPoint;
    private GameObject newTile;

    private int tileLength;

    private void Start()
    {
        tileLength = 40;
    }

    private void Update()
    {
        if(!GameManager.isGameStarted)
        {
            return;
        }
        
        if (transform.position.z < generationPoint.position.z - 200)
        {
            tileSelector = Random.Range(0, pools.Length);

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + tileLength);
            
            newTile = pools[tileSelector].GetPooledObject();
            newTile.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            newTile.SetActive(true);
            for(int i = 0; i < newTile.transform.childCount; i++)
            {
                newTile.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

    
}
