using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStack : MonoBehaviour
{
    private RectTransform parentTransform;
    
    [SerializeField]
    private GameObject blockPrefab;    
    [SerializeField]
    private int maxBlocks = 10;

    [SerializeField]
    private AudioSource correctSound;
    [SerializeField]
    private AudioSource incorrectSound;

    // Start is called before the first frame update
    void Start()
    {
        this.parentTransform = GetComponent<RectTransform>();
    }

    public void BeginGeneration()
    {
        StartCoroutine(this.GenerateBlocks());
    }

    private IEnumerator GenerateBlocks()
    {
        yield return new WaitForSeconds(Level.timeBetweenBlocks);
        
        while (this.parentTransform.childCount < this.maxBlocks)
        {
            this.AddBlock();
            yield return new WaitForSeconds(Level.timeBetweenBlocks);
        }

        GameManager.gameOver = true;
    }

    private void AddBlock()
    {
        GameObject blockInstance = Instantiate(this.blockPrefab, this.parentTransform);
        blockInstance.GetComponent<CharacterBlock>().Setup();
    }

    public bool ProcessEntry(string entry)
    {
        if (this.parentTransform.childCount <= 0)
        {
            return false;
        }

        CharacterBlock checkBlock = this.parentTransform.GetChild(this.parentTransform.childCount - 1).GetComponent<CharacterBlock>();
        if (entry == checkBlock.ENCharacter)
        {
            Destroy(checkBlock.gameObject);
            this.correctSound.Play();
            return true;
        }
        else
        {
            this.incorrectSound.Play();
            checkBlock.SwapToEnglish();
            return false;
        }
    }
}
