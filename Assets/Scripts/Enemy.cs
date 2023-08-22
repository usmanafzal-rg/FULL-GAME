using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rig;
    // Start is called before the first frame update
    void Awake()
    {
        speed = 7f;
		rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }
}     //class




















