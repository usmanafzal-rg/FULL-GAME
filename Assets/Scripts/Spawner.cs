using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] enemies;

	private float timePassed = 0;

	private float totalSecondsToWait;
    
	[SerializeField]
	private string[] characterNames;

	

    void Start()
    {
        //StartCoroutine(SpawnMonsters());
		totalSecondsToWait = Random.Range(1,4);

		
    }

    /*IEnumerator SpawnMonsters()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(1,4));
            int randomIndex = Random.Range(0, enemies.Length);
           
            int randomSide = Random.Range(0, 2);

            GameObject monster = GameController.instance.GetFromPool();
            Enemy e = monster.GetComponent<Enemy>();

            if (randomSide == 0) //left side
            {
                Transform temp = transform.GetChild(0);
                if (temp)
                {
                    monster.transform.position = temp.position;
                }

                e.speed = Random.Range(4, 11);
            }
            else //right side
            {
                Transform temp = transform.GetChild(1);
                if (temp)
                {
                    monster.transform.position = temp.position;
                }

                monster.transform.localScale = new Vector3(-1f,1f,1f);
                e.speed = -1 * Random.Range(4, 11);
                
            }
        }
    }*/
        
    // Update is called once per frame
    void Update()
    {
        
        timePassed += Time.deltaTime;
		
		if(timePassed >= totalSecondsToWait) {

            string randomName = characterNames[Random.Range(0, characterNames.Length)];
            int randomSide = Random.Range(0, 2);

            GameObject monster = GameController.instance.GetFromPool(randomName);
			SpriteRenderer sr = monster.GetComponent<SpriteRenderer>();
            Enemy e = monster.GetComponent<Enemy>();

            if (randomSide == 0) //left side
            {
                Transform temp = transform.GetChild(0);
				
				if(sr.flipX == true)
				{
				sr.flipX = false;
				}
                if (temp)
                {
                    monster.transform.position = temp.position;
                }

                e.speed = Random.Range(4, 11);
            }
            else //right side
            {
                Transform temp = transform.GetChild(1);
                if (temp)
                {
                    monster.transform.position = temp.position;
                }

				if(sr.flipX == false)
				{
				sr.flipX = true;
				}

                
                e.speed = -1 * Random.Range(4, 11);
                
            }

		timePassed = 0;
		totalSecondsToWait = Random.Range(1,4);
		}
    }
}
