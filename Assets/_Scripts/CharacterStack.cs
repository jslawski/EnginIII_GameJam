using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStack : MonoBehaviour
{
    private RectTransform parentTransform;

    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject blockPrefab;    
    [SerializeField]
    private int maxBlocks = 10;

    // Start is called before the first frame update
    void Start()
    {
        this.parentTransform = GetComponent<RectTransform>();
        this.BeginGeneration();
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

        this.gameManager.TriggerGameOver();
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
            return true;
        }
        else
        {
            checkBlock.SwapToEnglish();
            return false;
        }
    }
}
