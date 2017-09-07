using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    ColliderAABB player;
    static public List<ColliderAABB> powerups = new List<ColliderAABB>();

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<ColliderAABB>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        DoCollisionDetection();
	}

    void DoCollisionDetection()
    {
        foreach(ColliderAABB powerup in powerups)
        {

            bool result = player.checkOverlap(powerup);

            player.SetCollisionWith(result, powerup);

            powerup.SetCollisionWith(result, player);
            /*if (player.checkOverlap(powerup))
            {
                print("COLLIDE");
                //Destroy(powerup.gameObject);
                powerup.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
            }*/
        }
    }
}
