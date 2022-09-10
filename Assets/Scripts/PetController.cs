using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PetController : MonoBehaviour
{
    
    public bool fly = true;

    float difference = 1f;
    public Transform player;

    public float bobbleSpeed = 1f;
    float maxBobble = 0.25f;
    float minBobble = -0.25f;
    float currentBobble = 0f;

    bool adding = true;
    float distance;
    public float floatRange = 3f;
    public AIPath aiPath;
    public float speedMultiplier = 2f;

    void Update()
    {
        if (fly)
        {
            if (adding)
            {
                currentBobble += bobbleSpeed * Time.deltaTime;
            }
            else
            {
                currentBobble -= bobbleSpeed * Time.deltaTime;
            }

            currentBobble = Mathf.Clamp(currentBobble, minBobble, maxBobble);

            if (currentBobble == maxBobble || currentBobble == minBobble)
            {
                adding = !adding;
            }

            transform.position = new Vector3(transform.position.x, player.position.y + difference + currentBobble, transform.position.z);

        }

        distance = Vector3.Distance(player.position, transform.position);
        
        if (distance < floatRange)
        {
            aiPath.canMove = false;
        }
        else
        {
            aiPath.canMove = true;
            aiPath.maxSpeed = distance * speedMultiplier;
        }
    }
}
