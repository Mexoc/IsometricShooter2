using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float enemyHealth = 100;
    public float enemyAmmo = 25;
    public float currentAmmo;
    public bool enemyIsDead = false;
    private string gameobjectName;
    private Animator anim;
    [SerializeField]
    private GameObject keycard;
    public int enemyIndex;
    private CapsuleCollider[] enemyColliders = new CapsuleCollider[2];

    public float EnemyHealth
    {
        get { return enemyHealth; }
        set { enemyHealth = value; }
    }

    private void Start()
    {
        enemyColliders = gameObject.GetComponents<CapsuleCollider>();
        currentAmmo = enemyAmmo;
        gameobjectName = this.gameObject.name;           
        EnemyIndex();
    }

    private void Update()
    {
        EnemyDead();
    }

    public int EnemyIndex()
    {
        string str = string.Empty;
        for (int i = 0; i < gameobjectName.Length; i++)
        {
            if (char.IsDigit(gameobjectName[i]))
            {
                str += gameobjectName[i];
            }
        }
        if (str.Length > 0)
        {
            enemyIndex = int.Parse(str);
            return enemyIndex;
        }
        else
            return 0;        
    }

    public void EnemyDead()
    {
        if (enemyHealth <= 0)
        {
            GameObject temp;
            enemyIsDead = true;
            Vector3 tempRot = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 90);
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<EnemyAI>());
            Destroy(gameObject.GetComponent<LineRenderer>());
            //gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            foreach (var col in enemyColliders)
            {
                col.isTrigger = true;
            }
            gameObject.GetComponent<Animator>().enabled = false;
            temp = gameObject.transform.Find("minimapIcon").gameObject;
            temp.SetActive(false);
            gameObject.tag = "Untagged";
            gameObject.transform.eulerAngles = tempRot;            
        }
    }

    public void DropKeycard()
    {
        if (this.enemyIsDead)
        {
            Instantiate(keycard, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
