using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField] 
    float damping = 3f;

    void LateUpdate()
    {
        float currentXPosition = transform.position.x;
        float desiredXPosition = target.transform.position.x;
        float positionX = Mathf.Lerp(currentXPosition, desiredXPosition, Time.deltaTime * damping);

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);

        transform.LookAt(target.transform);
    }
}
