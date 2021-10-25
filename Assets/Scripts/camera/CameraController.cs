using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private Vector3 offset;     
    [SerializeField][Range(1,10)]private float smoothFactor; 
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        follow();
    }

    // Update is called once per frame
    void follow()
    {
        // transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);      Lars sätt
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
