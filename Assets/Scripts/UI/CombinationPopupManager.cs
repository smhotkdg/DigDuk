using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationPopupManager : MonoBehaviour {

    // Use this for initialization
    public GameObject ImageBG;
    public GameObject ImageCollectionBG;
    public GameObject ImgRibbon;
    List<GameObject> CombiList = new List<GameObject>();
    List<GameObject> CollectionList = new List<GameObject>();
    private void Awake()
    {
        for(int i=0; i< 33; i++)
        {
            int index = i + 1;
            string name = "Combi" + index;
            CombiList.Add(ImageBG.transform.Find(name).gameObject);
        }
        for (int i = 0; i < 15; i++)
        {
            int index = i + 1;
            string name = "Collection" + index;
            CollectionList.Add(ImageCollectionBG.transform.Find(name).gameObject);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
    public void SetCollectionView(int i)
    {
        ImageCollectionBG.SetActive(true);
        if (CollectionList.Count > i)
        {
            CollectionList[i].SetActive(true);
        }
    }
    public void SetCombiView(int i)
    {
        ImageBG.SetActive(true);
        ImgRibbon.SetActive(true);
        if (CombiList.Count >i)
        {
            CombiList[i].SetActive(true);
        }
    }
	void Update () {
		
	}
    private void OnDisable()
    {
        ImageBG.SetActive(false);
        ImageCollectionBG.SetActive(false);
        ImgRibbon.SetActive(false);
        for (int i=0; i< CombiList.Count; i++)
        {
            CombiList[i].SetActive(false);
        }
        for (int i = 0; i < CollectionList.Count; i++)
        {
            CollectionList[i].SetActive(false);
        }
    }
}
