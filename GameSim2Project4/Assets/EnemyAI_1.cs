using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour
{

    public int enemyLevel;

    public enum EnemyState
    {
        Red,
        Green,
        TransitionToGreen,
        TransitionToRed
    }
    public bool lightChange;
    

    public GameObject spotLight;
    private float _lightTimer;
    private float _lightTimer2;
    private float stateTimer;
    private float transitionTimer;
    
    public float stateInterval;
    public float stateChangeLength; 
    public EnemyState enemyState = EnemyState.Red;

    public void LightChange()
    {
        switch (enemyState)
        {
            case EnemyState.Red:
            {
                stateTimer += Time.deltaTime;
                if (stateTimer > stateInterval)
                {
                    stateTimer = 0;
                    enemyState = EnemyState.TransitionToGreen;
                }
            }
                break;

            case EnemyState.TransitionToGreen:
            {
                transitionTimer += Time.deltaTime;
                spotLight.GetComponent<Light>().color = Color.Lerp(Color.red, Color.green, transitionTimer / stateChangeLength);
                if (transitionTimer / stateChangeLength > 1)
                {
                    transitionTimer = 0;
                    enemyState = EnemyState.Green;
                }
            } break;

            case EnemyState.Green:
            {
                stateTimer += Time.deltaTime;
                if (stateTimer > stateInterval)
                {
                    stateTimer = 0;
                    enemyState = EnemyState.TransitionToRed;
                }
            } break;

            case EnemyState.TransitionToRed:
            {
                transitionTimer += Time.deltaTime;
                spotLight.GetComponent<Light>().color = Color.Lerp(Color.green, Color.red, transitionTimer / stateChangeLength);
                if (transitionTimer / stateChangeLength > 1)
                {
                    transitionTimer = 0;
                    enemyState = EnemyState.Red;
                }
            } break;
        } 
    }
    
    public void UpdateEnemy()
    {
        if (lightChange)
        {
            LightChange();
        }
        
        //transform.position += Vector3.left * Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
