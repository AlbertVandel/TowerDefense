using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public NavMeshPath path;
    //public Text gameOverText;
    //private int playerHealth = 1;

    void Start()
    {
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;

    }

    void Update()
    {
        path = new NavMeshPath();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        agent.CalculatePath(goal.position, path);
        
        // detects path block
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            Debug.Log("agent's path is blocked");
            RemoveLatestTower();
        }

        float dist = Vector3.Distance(gameObject.transform.position, goal.position);
        //if (gameObject.transform.position == goal.position)
        if(dist <= 30)
        {
            Destroy(gameObject);
            //playerHealth--;
            //if (playerHealth >= 1) {
            //    gameOverText.text = playerHealth.ToString();
            //}
            SceneManager.LoadScene("SampleScene");
        }
        //if (playerHealth <= 0)
        //{
        //    EndGame();
        //}
    }

    void RemoveLatestTower()
    {
        Destroy(GameObject.FindGameObjectsWithTag("Tower")[GameObject.FindGameObjectsWithTag("Tower").Length - 1]);
        Destroy(GameObject.FindGameObjectsWithTag("Tower")[GameObject.FindGameObjectsWithTag("Tower").Length - 2]);
    }

    //void EndGame()
    //{
        //gameOverText.text = "GAME OVER";
        //Debug.Log("GAME OVER");
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene("samplescene");
    //}

}
