using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyBaseFSM
{
    GameObject[] waypoints;
    int waypointsNumber = 4;
    int currentWaypoint;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SetWaypoints();        
        currentWaypoint = 0;
    }

    private void OnStateUpdate()
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(enemy.transform.position, waypoints[currentWaypoint].transform.position) < 2f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        var direction = waypoints[currentWaypoint].transform.position - enemy.transform.position;
        direction.y = 0;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        enemy.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void SetWaypoints()
    {
        if (waypoints != null)
            return;
        GameObject circle = new GameObject();
        Vector3 pointPos;
        circle.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 50, enemy.transform.position.z);
        for (int i = 0; i < waypointsNumber; i++)
        {
            pointPos = new Vector3(circle.transform.position.x + Random.Range(20, 60), circle.transform.position.y, circle.transform.position.z + Random.Range(20, 60));
            GameObject point = new GameObject();
            point.transform.position = pointPos;
            RaycastHit hit;
            Physics.Raycast(point.transform.position, Vector3.down * 100, out hit);
            if (hit.collider.tag == "Ground")
            {
                GameObject waypoint = new GameObject();
                waypoint.name = "waypoint" + (i + 1);
                waypoint.transform.position = hit.point;
                waypoint.tag = "Waypoint";
            }
            Destroy(point);
        }
        Destroy(circle);
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
}
