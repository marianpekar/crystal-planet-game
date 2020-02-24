using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    KeyCode leftKey = KeyCode.A;

    [SerializeField]
    KeyCode rightKey = KeyCode.W;

    [SerializeField] 
    KeyCode respawnKey = KeyCode.R;

    [SerializeField]
    GameObject body;

    [SerializeField]
    GameObject[] engines;

    private Vector3 steering;

    void Start()
    {
        PlayerEvents.Instance.OnPlayerDied.Add(HidePlayer);
        PlayerEvents.Instance.OnPlayerRespawned.Add(ShowPlayer);
    }

    void Update()
    {
        GatherInputs();

        if (PlayerStates.Instance.IsDead)
            return;

        Move();
        TiltBody();
        ShakeBody();
    }

    void GatherInputs()
    {
        if (Input.GetKey(leftKey))
            steering.x = -PlayerStates.Instance.SteeringSpeed;
        else if (Input.GetKey(rightKey))
            steering.x = PlayerStates.Instance.SteeringSpeed;
        else
            steering = Vector3.zero;

        if (Input.GetKey(respawnKey) && PlayerStates.Instance.IsDead)
            PlayerManager.Instance.RespawnPlayer();
    }

    private void Move()
    {
        transform.Translate(steering * PlayerStates.Instance.SteeringSpeed * Time.deltaTime);
    }

    private void TiltBody()
    {
        if (steering.x > 0)
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(PlayerStates.Instance.SteeringTiltAngle),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);
        else if (steering.x < 0)
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(-PlayerStates.Instance.SteeringTiltAngle),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);
        else
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation,
                                                        Quaternion.Euler(Vector3.zero),
                                                        PlayerStates.Instance.SteeringTiltSpeed * Time.deltaTime);

    }
    private void ShakeBody()
    {
        float noise = Mathf.PerlinNoise(Random.Range(0f, PlayerStates.Instance.ShakeStrength), Random.Range(0f, PlayerStates.Instance.ShakeStrength));
        body.transform.position = new Vector3(body.transform.position.x, Mathf.Sin(noise), body.transform.position.z);
    }

    private void HidePlayer()
    {
        EnablePlayer(false);
    }

    private void ShowPlayer()
    {
        EnablePlayer(true);
    }

    void EnablePlayer(bool enabled)
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = enabled;

        foreach (var light in GetComponentsInChildren<Light>())
            light.enabled = enabled;

        foreach (GameObject engine in engines)
            engine.SetActive(enabled);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Crystal"))
        {
            PlayerEvents.Instance.CrystalCollision();
            PlayerManager.Instance.TakeDamage();
            collider.GetComponent<CrystalController>().Respawn();
        }
    }
}
