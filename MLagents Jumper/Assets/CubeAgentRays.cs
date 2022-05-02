using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
public class CubeAgentRays : Agent
{
    public Transform floor;
    public Rigidbody rb;
    public bool jump = true;

    public override void OnEpisodeBegin()
    {
        jump = true;
        
        // reset de positie en orientatie als de agent gevallen is
            this.transform.localPosition = new Vector3(3, 0.5f, 0);
            rb.transform.rotation = Quaternion.Euler(0, 267, 0);
    }
    
    public override void CollectObservations(VectorSensor sensor)
    {
        // Target en Agent posities
       sensor.AddObservation(this.transform.localPosition);
    }
    
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2
        if (actionBuffers.ContinuousActions[0] > 0)
        {
            if (jump)
            {
                rb.AddForce(Vector3.up * 340, ForceMode.Acceleration);
                
                jump = false;
            }
        }
    }



    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;

        continuousActionsOut[0] = Input.GetAxis("Vertical");
        
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstical") == true)
        {
            AddReward(-1.0f);
            Destroy(collision.gameObject);
            EndEpisode();
        }
        if (collision.gameObject.CompareTag("point") == true)
        {
            AddReward(1.0f);
            Destroy(collision.gameObject);
        }
    }
 

    public void jumpEN() {
        jump = true;
    }

}
