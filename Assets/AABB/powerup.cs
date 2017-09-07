using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //GameObject.Find("Main Camera").GetComponent<CollisionManager>().powerups.Add(GetComponent<ColliderAABB>());

        ColliderAABB collider = GetComponent<ColliderAABB>();

        collider.OnCollisionStart += StartCollide;
        collider.OnCollisionEnd += EndCollide;

        CollisionManager.powerups.Add(collider);
    }

    void OnDestroy()
    {
        ColliderAABB collider = GetComponent<ColliderAABB>();

        CollisionManager.powerups.Remove(collider);
    }

    void StartCollide()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    void EndCollide()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
