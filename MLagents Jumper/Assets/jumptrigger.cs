using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ob;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        CubeAgentRays sn = ob.GetComponent<CubeAgentRays>();
        sn.jumpEN();
    }
}
