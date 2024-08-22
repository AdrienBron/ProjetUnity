using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class men : MonoBehaviour
{
    private CharacterController characterController;
    private int point;
    public TMP_Text labelPoint;
    public TMP_Text labelTimer;
    public TMP_Text labelPointGameOver;
    public TMP_Text labelPointVictory;
    public int timer;
    public GameObject menuGameOver;
    public GameObject menuVictory;
    public int scoreVictory;

    void Start()
    {
        labelTimer.text = timer.ToString();
        StartCoroutine(Timer());
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        characterController.Move(transform.right * Input.GetAxis("Horizontal") * 0.2f);
        characterController.Move(transform.forward * Input.GetAxis("Vertical") * 0.2f);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            point++;
            labelPoint.text = point.ToString();
            Destroy(other.gameObject);
            if (point == scoreVictory)
            {
                labelPointVictory.text = "Vous avez obtenu les "+point.ToString()+" points !";
                menuVictory.SetActive(true);
            }
        }
    }
    public IEnumerator Timer()
    {
        for (int i = timer; i > -1; i--)
        {
            labelTimer.text = i.ToString();
            if (i == 0 && point < scoreVictory){
                labelPointGameOver.text = "Score : "+point.ToString();
                menuGameOver.SetActive(true);
            };
            yield return new WaitForSeconds(1);
        }
    }
}
