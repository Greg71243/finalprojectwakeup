using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    private AudioSource audioSource;
    public AudioClip itemSound;
    public AudioClip completeSound;

    int itemCount;
    private void Start()
    {
        itemCount = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreText.text = "Clock " + score.ToString() + "/" + itemCount.ToString();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag.Equals("Item"))
        {
            Destroy(target.gameObject);
            score += 1;
            scoreText.text = "Clock " + score.ToString() + "/" + itemCount.ToString();
            if (score>=itemCount)
            {
                audioSource.PlayOneShot(completeSound);
                StartCoroutine(NextScene1());
            }
            else
            {
                audioSource.PlayOneShot(itemSound);
            }
        }
    }
    IEnumerator NextScene1()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("BedRoom");
    }


}
