using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem chunkFX;
    public AudioSource getHit;
    public AudioSource die;
    private Animator _animator;
    private string _currentAnimation;
    private float _normalizedTime;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(string animationName)
    {
        if (_animator != null)
        {
            _animator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }
    }

    public IEnumerator TakeDamage(float damage)
    {
        health -= damage;

        StartCoroutine(MakeSomeBlood());

        if (health < 0)
        {
            die.Play();
            PlayAnimation("Die");
            Destroy(gameObject, 3f);
        }
        else
        {
            getHit.Play();
            PlayAnimation("GetHit");
            yield return new WaitForSeconds(.5f);
            PlayAnimation("Walk");
        }
    }

    IEnumerator MakeSomeBlood()
    {
        chunkFX.Play();
        yield return new WaitForSeconds(.5f);
        chunkFX.Stop();
    }
}
