using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyBaseFSM
{
    private GameObject[] waypoints;
    int waypointsNumber = 4;
    int currentWaypoint = 0;
    private GameObject waypointsGO;
    public int index;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<EnemyAI>().enemyIsShotAt = false;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SetWaypoints();        
        currentWaypoint = 0;
    }

    private void OnStateUpdate()
    {
        if (Vector3.Distance(enemy.transform.position, waypoints[currentWaypoint].transform.position) < 2f)
        {
            currentWaypoint++;
            if (currentWaypoint >= this.waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        var direction = this.waypoints[currentWaypoint].transform.position - enemy.transform.position;
        direction.y = 0;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        enemy.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void SetWaypoints()
    {
        index = this.enemy.gameObject.GetComponent<EnemyStats>().EnemyIndex();
        if (this.waypoints != null)
            return;
        waypointsGO = GameObject.Find("waypointsGO");
        GameObject circle = new GameObject();
        Vector3 pointPos;
        circle.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 50, enemy.transform.position.z);
        for (int i = 0; i < waypointsNumber; i++)
        {
            pointPos = new Vector3(circle.transform.position.x + Random.Range(40, 200), circle.transform.position.y, circle.transform.position.z + Random.Range(40, 200));
            GameObject point = new GameObject();
            point.transform.position = pointPos;
            RaycastHit hit;
            Physics.Raycast(point.transform.position, Vector3.down * 1000, out hit);
            if (hit.collider.tag == "Ground")
            {
                GameObject waypoint = new GameObject();
                waypoint.name = "waypoint" + (i + 1);
                waypoint.transform.position = hit.point;
                if (index == 0)
                {
                    waypoint.tag = "Waypoint";
                }
                else
                    waypoint.tag = "Waypoint" + index;
                waypoint.transform.parent = waypointsGO.transform;
            }
            else
                continue;
            Destroy(point);
        }
        Destroy(circle);
        if (index == 0)
        {
            this.waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }
        else 
            this.waypoints = GameObject.FindGameObjectsWithTag("Waypoint"+index);
    }
}
