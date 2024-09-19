using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    public GameObject brickPrefab; 

    void Awake()
    {   
        for (int y = 0; y < 5; ++y) {
	        for (int x = 0; x < 20; ++x) {
			    GameObject brick = Instantiate(brickPrefab, new Vector2(x - 9.5f, y * 0.5f + 1), Quaternion.identity);
			    brick.transform.SetParent(this.transform, false);
			}
		}
    }

    // Start is called before the first frame update
    void Start()
    {
            //Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
	
    void LateUpdate() {	
        if (transform.childCount == 0) {
            Awake();
        }
    }
}
