using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMaster : MonoBehaviour
{
    public Transform anchorObject;

    //List<Transform> generatedAnchor = new List<Transform>();
    public bool isPlaced = false;
    public int anchorCount = 0;
    private Vector3 groundedAnchorCorner;
    // Start is called before the first frame update
    void Start()
    {
        anchorObject = Instantiate(anchorObject, transform.position, transform.rotation);
        groundedAnchorCorner = new Vector3(1000, 1000, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //GameObject placedAnchor = null;
            if(!isPlaced)
            {
                anchorObject.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
                anchorCount++;
                //generatedAnchor.Add(anchorObject);
                isPlaced = true;
                FindObjectOfType<AudioManager>().Play("Anchor");
            }
            else if(isPlaced){
                anchorObject.position = groundedAnchorCorner;
                anchorCount--;
                isPlaced = false;
            }
        }
    }
}
