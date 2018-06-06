using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NumberTable : MonoBehaviour {
    public UnityEngine.UI.Text _LblNumbers;
    public GameObject btnYes;
    public GameObject btnNo;
    public GameObject restart;

    private int pointer = 0;

    public readonly int[ , ] allNum = {
        {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59 },
        {0, 8, 9, 10, 11,12,13,14,15,21,25,23,27,28,29,30,31,40,41,42,43,44,45,46,47,56,57,58,59,60},
        {0, 4,5,6,7,12,13,14,15,20,21,22,23,28,29,30,31,36,37,38,39,44,45,46,47,52,53,54,55,60},
        {0,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60},
        {0,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,48,49,50,51,52,53,54,55,56,57,58,59,60},
        {2,3,6,7,10,11,14,15,18,19,22,23,26,27,30,31,34,35,38,39,42,43,46,47,50,51,54,55,58,59}
    };

    private List<int> q = new List<int>();

    // Use this for initialization
    void Start () {
        fillNumbers();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public int guess () {
        int total = 0;
        foreach (int item in q) {
            total += item;
        }
        pointer = 0;
        if(total < 1 || total > 60) {
            _LblNumbers.text = "-___-''";
        }
        else {
            _LblNumbers.text = "Your number is " + total + ".";
        }
        
        clear();
        btnYes.SetActive(false);
        btnNo.SetActive(false);
        return total;
    }

    void add () {
        //Pick next if number is zero
        q.Add(allNum[pointer, allNum[pointer, 0] == 0 ? 1 : 0]);
    }
    void clear () { q.Clear(); }
    private void fillNumbers() {
        string strb = "";
        for (int i = 0; i < 30; i++) {
            if (allNum[pointer, i] == 0) continue;
            strb += allNum[pointer, i] + ", ";
        }
        _LblNumbers.text = strb;
        
    }
    public void btnYesClick () {
        add();
        pointer++;
        if (pointer == 5) {
            guess();
        }
        else {
            fillNumbers();
        }   
        
        Debug.Log("Pointer: " + pointer);
    }
    public void btnNoClick () {
        pointer++;
        if (pointer == 5) {
            guess();
        }
        else {
            fillNumbers();
        }
        Debug.Log("Pointer: " + pointer);
    }
    public void btnRestart () {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
    }
}
