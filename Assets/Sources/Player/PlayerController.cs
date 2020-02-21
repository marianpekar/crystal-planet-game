using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    KeyCode leftKey;

    [SerializeField]
    KeyCode rightKey;

    [SerializeField]
    GameObject body;

    private Vector3 steering;

    void Update()
    {
        GatherInputs();
        Move();
        TiltBody();
    }

    void GatherInputs()
    {
        if (Input.GetKey(leftKey))
            steering.x -= PlayerStates.Instance.SteeringSpeed;
        else if (Input.GetKey(rightKey))
            steering.x += PlayerStates.Instance.SteeringSpeed;
        else
            steering = Vector3.zero;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * PlayerStates.Instance.FlightSpeed + steering * PlayerStates.Instance.SteeringSpeed * Time.deltaTime);
    }

    private void TiltBody()
    {
        if (steering.x > 0)
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(-PlayerStates.Instance.SteeringTiltAngle),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);
        else if (steering.x < 0)
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(PlayerStates.Instance.SteeringTiltAngle),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);
        else
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(Vector3.zero),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);

    }
}
