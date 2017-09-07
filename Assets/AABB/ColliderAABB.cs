using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAABB : MonoBehaviour {

    public delegate void CollisionEvent();
    public event CollisionEvent OnCollisionStart;
    public event CollisionEvent OnCollisionEnd;

    List<ColliderAABB> currentOverlaps = new List<ColliderAABB>();

    public Vector3 halfSize;

    Vector3 min = Vector3.zero;
    Vector3 max = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
        calcEdges();
	}

    void calcEdges()
    {
        min = transform.position - halfSize;
        max = transform.position + halfSize;

    }

    public bool checkOverlap(ColliderAABB other)
    {
        if (min.x > other.max.x) return false;
        if (max.x < other.min.x) return false;

        if (min.y > other.max.y) return false;
        if (max.y < other.min.y) return false;

        if (min.z > other.max.z) return false;
        if (max.z < other.min.z) return false;

        return true;
    }

    public void SetCollisionWith(bool isColliding, ColliderAABB other)
    {
        if (isColliding)
        {
            if (!currentOverlaps.Contains(other))
            {
                currentOverlaps.Add(other);
                OnCollisionStart();// dispatch an event (collision start)
                print("collision begins");
            }
        }
        else
        {
            if (currentOverlaps.Contains(other))
            {
                currentOverlaps.Remove(other);
                OnCollisionEnd();// dispatch event (collison end)
                print("collision ends");

            }
        }
    }


}
