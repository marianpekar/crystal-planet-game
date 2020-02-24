using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    KeyCode loadGameKey;

    [SerializeField]
    int GameSceneIndex;

    void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetKey(loadGameKey))
                SceneManager.LoadScene(GameSceneIndex);
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene(GameSceneIndex);
                }
            }
        }
    }
}
