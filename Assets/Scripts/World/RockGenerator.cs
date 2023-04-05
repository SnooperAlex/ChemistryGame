using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject treeObject;

    public GameObject treesInWorldObject;

    public int treeAmount;

    private List<GameObject> trees = new List<GameObject>();

    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;

    private List<Vector3> rays = new List<Vector3>();

    public void Generate(){
        Clear();


        for(int i = 0; i <= treeAmount; i++){

            float sampleX = Random.Range(-MapGenerator.mapChunkSize/2, MapGenerator.mapChunkSize/2);
            float sampleY = Random.Range(-MapGenerator.mapChunkSize/2, MapGenerator.mapChunkSize/2);
            Vector3 rayStart = new Vector3(sampleX, maxHeight, sampleY);
            
            if(!Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, Mathf.Infinity)){
                continue;
            }

            if(hit.point.y < 0.2){
                continue;
            }

            GameObject tree = (GameObject)Instantiate(treeObject, transform.position, transform.rotation);
            tree.transform.position = hit.point;
            tree.transform.parent = treesInWorldObject.transform;
                    

           
        }
    }
    
    public void CreateRaysData(Vector2 position)
    {
        float scale = 10f;
        for(int i = 0; i <= treeAmount; i++){
            float sampleX = Random.Range(position.x-MapGenerator.mapChunkSize/2 * scale, position.x + MapGenerator.mapChunkSize/2* scale);
            float sampleY = Random.Range(position.y-MapGenerator.mapChunkSize/2* scale, position.y + MapGenerator.mapChunkSize/2* scale);
            Vector3 rayStart = new Vector3(sampleX, maxHeight, sampleY);
            
            rays.Add(rayStart);
            
        }
    }

    public void GenerateTrees()
    {
        for (int i = 0; i <= rays.Count-1; i++)
        {
            if(!Physics.Raycast(rays[i], Vector3.down, out RaycastHit hit, Mathf.Infinity)){
                continue;
            }
            
            if(hit.point.y < 0.2){
                continue;
            }

            GameObject tree = (GameObject)Instantiate(treeObject, transform.position, transform.rotation);
            tree.transform.position = hit.point;
            tree.transform.parent = treesInWorldObject.transform;
            trees.Add(tree);
        }
    }

    public void Clear(){
        while (treesInWorldObject.transform.childCount > 0) {
            DestroyImmediate(treesInWorldObject.transform.GetChild(0).gameObject);
        }

    }
    
    
    public void SetTreesVisible(bool isVisible)
    {
        for (int i = 0; i <= trees.Count - 1; i++)
        {
            DestroyImmediate(trees[i].gameObject);
        }
    }
}
