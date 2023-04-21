
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject follower = null;
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else {
            Debug.Log("Warning: multiple" + this + "in scene!");
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        follower = GameObject.Find("EntityFollower");
    }
}