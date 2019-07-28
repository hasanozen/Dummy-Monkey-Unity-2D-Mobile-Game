using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private bool followPlayer;
    public float min_Y_Treshold = -2.6f; // karakterin dusmeye basladıgında kameranın takibi bırakacagı noktayı belirlemek için

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {

        if(target.position.y < (transform.position.y - min_Y_Treshold))
        {
            followPlayer = false;
        }

        if(target.position.y > transform.position.y)
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
    }
}
