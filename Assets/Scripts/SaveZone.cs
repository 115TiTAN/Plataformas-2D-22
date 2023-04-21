using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    public Animator controlPanelAnimator;
    public GameObject[] panels;
    public int activePanelIndex = 0;
    public GameObject StructureMenuUI;

    private bool firstAnimationPlayed = false;
    private bool firstTime = true;

    public float timeDelayMax = 1.0f;
    private float timeDelay = 0.0f;

    void Update()
    {
    

        if (firstAnimationPlayed)
        {
            if (timeDelay > 0.0f)
            {
                timeDelay -= Time.deltaTime;
            }
            else
            {
                panels[activePanelIndex].SetActive(false);
                activePanelIndex = (activePanelIndex + 1) % panels.Length;
                panels[activePanelIndex].SetActive(true);
                Pause();
            }
        }
       

    }
    

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!firstAnimationPlayed)
                {
                    controlPanelAnimator.SetTrigger("PlayAnimation1");
                    firstAnimationPlayed = true;
                }

                if (firstTime)
                {
                    timeDelay = timeDelayMax;

                }
                else
                {
                    timeDelay = 0.0f;
                }

            }
            Debug.Log("Trigger entered.");
        }
    }
    public void Resume()
    {
        StructureMenuUI.SetActive(false);
        Time.timeScale = 1f;



    }
    void Pause()
    {
        StructureMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

