using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Transform> cameraPos = new List<Transform>();
    public List<Transform> respawnPos = new List<Transform>();

    Vector3 playerRespawnPos;
    Camera cam;
    Player player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void NewRoom(int id)
    {

        cam.transform.position = cameraPos[id].position;
        playerRespawnPos = respawnPos[id].position;

        player.transform.position = playerRespawnPos;
    }

}
