using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour

{
    [SerializeField] AudioClip breaksound;
    [SerializeField] GameObject blockSparkelsVFX;
    //[SerializeField] int maxHit;
    [SerializeField] Sprite[] hitSprites;

     Level level;
    GameStatus gameStatus;
    // Start is called before the first frame update
    [SerializeField] int timesHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHit = hitSprites.Length + 1;
            if (timesHit >= maxHit)
                destroyblock();
            else
            {
                showNextHitSprite();
            }
        }    


        // Debug.Log(collision.gameObject.name);
    }

    private void destroyblock()
    {
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position);
        Destroy(gameObject);
        level.blockdestroy();
        gameStatus.addtoscore();
        TriggerSparkelsVFX();
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        level.countbreakableblocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void TriggerSparkelsVFX()
    {
        GameObject sparkels = Instantiate(blockSparkelsVFX, transform.position, transform.rotation);
        Destroy(sparkels, 1f);

    }
    private void showNextHitSprite ()
    {
        int SpriteIndex = timesHit - 1;
        if(hitSprites[SpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing from array" + gameObject.name);
        }
    }
}
