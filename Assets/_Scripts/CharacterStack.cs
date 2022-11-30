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
    }

    private void AddBlock()
    {
        GameObject blockInstance = Instantiate(this.blockPrefab, this.parentTransform);
        blockInstance.GetComponent<CharacterBlock>().Setup();
    }

    public bool ProcessEntry(string entry)
    {
        CharacterBlock checkBlock = this.parentTransform.GetChild(this.parentTransform.childCount - 1).GetComponent<CharacterBlock>();
        if (entry == checkBlock.ENCharacter)
        {
            Destroy(checkBlock.gameObject);
            //Play correct sound
            return true;
        }
        else
        {
            //Play incorrect sound
            return false;
        }
    }
}
