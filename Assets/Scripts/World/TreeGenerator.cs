using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treeObject;

    public GameObject treesInWorldObject;

    public int treeAmount;

    List<GameObject> treesList = new List<GameObject>();

    GameObject[] treesArray;

    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;

    public void Generate(){
        Clear();
        treesList.Clear();

        
        for(int i = 0; i <= treeAmount; i++){

            float sampleX = Random.Range(-MapGenerator.mapChunkSize/2, MapGenerator.mapChunkSize/2);
            float sampleY = Random.Range(-MapGenerator.mapChunkSize/2, MapGenerator.mapChunkSize/2);
            Vector3 rayStart = new Vector3(sampleX, maxHeight, sampleY);

            if(!Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, Mathf.Infinity)){
                continue;
            }

            Debug.Log(hit.point.y);
            if(hit.point.y < 0.2){
                continue;
            }

            GameObject tree = (GameObject)Instantiate(treeObject, transform.position, transform.rotation);
            tree.transform.position = hit.point;
            tree.transform.parent = treesInWorldObject.transform;
                    

           
        }
    }

    public void Clear(){
       foreach (Transform child in treesInWorldObject.transform) {
            GameObject.DestroyImmediate(child.gameObject);
    }

    }
}
