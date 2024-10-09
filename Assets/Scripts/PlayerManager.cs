using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    public float playerHealth = 100;
    private static float _currentPlayerHealth;
    private static bool _isGameOver;
    public TextMeshProUGUI playerHealthText;
    public GameObject redOverlay;
    public AudioSource getDamageAudio;

    // Start is called before the first frame update
    void Start()
    {
        _currentPlayerHealth = playerHealth;
        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "" + _currentPlayerHealth;

        if (_isGameOver)
        {
            SceneManager.LoadScene("EndScreenDefeat");
        }
    }

    public IEnumerator Damage(float damageCount)
    {
        getDamageAudio.Play();
        _currentPlayerHealth -= damageCount;
        redOverlay.SetActive(true);

        if (_currentPlayerHealth <= 0)
        {
            _isGameOver = true;
        }
        yield return new WaitForSeconds(.5f);
        redOverlay.SetActive(false);
    }
}
