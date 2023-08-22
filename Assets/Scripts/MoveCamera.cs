using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    
    public string PLAYER_TAG = "Player";

    [HideInInspector]
    public Transform player = null;
    
    private Transform trans = null;

    private float maxX = 58f, minX = -8.71f;

    void Awake()
    {
        
    }
    void Start()
    {
		if(GameObject.FindWithTag(PLAYER_TAG))
        	player = GameObject.FindWithTag(PLAYER_TAG).transform;
        
        trans = GetComponent<Transform>();
    }
    
    void LateUpdate()
    {
        if (!player)
            return;
        
        Vector3 temp = trans.position;
        temp.x = player.position.x;

        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        trans.position = temp;
    }
}
