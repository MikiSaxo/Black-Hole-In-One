using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevels : MonoBehaviour
{
    public GameObject levelPrefab;
    public RectTransform Content;
    public List<LevelInfos> levelsMenu = new List<LevelInfos>();
    //public GameObject[] GLevelMenu;
    public List<LevelInfoUI> GLevelMenu = new List<LevelInfoUI>();


    public static SelectLevels Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i <= ManageLevel.Instance.SpawnPoint.Length + 1; i++)
        {
            LevelInfos infos = new LevelInfos();
            levelsMenu.Add(infos);
        }

            //Content.transform.localScale = new Vector3(1 + ((ManageLevel.Instance.SpawnPoint.Length - 5) * .3f), 1, 1);
            for (int i = 0; i <= ManageLevel.Instance.SpawnPoint.Length + 1; i++)
        {
            GameObject go = Instantiate(levelPrefab, Content.transform, Content.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
            LevelInfoUI levelInfoUI = go.GetComponent<LevelInfoUI>();
            GLevelMenu.Add(levelInfoUI);
            levelInfoUI.numbers.text = "" + (i + 1);
            levelInfoUI.Initialize(levelsMenu[i]);


            //levelsMenu.Add(go.GetComponent<LevelsMenu>());
        }
        //Content.offsetMax = new Vector2(1076.387f, 0);
        //Content.offsetMin += new Vector2(2000, 0);
        //UpdateLevelInfos(0, 2);
        levelsMenu[0].isUnlocked = true;
    }

    public void UpdateLevelInfos( int level , int startCount)
    {
        levelsMenu[level].yellowStars = startCount;
        levelsMenu[level].isUnlocked = true;
        levelsMenu[level + 1].isUnlocked = true;

        GLevelMenu[level].Refresh();
        GLevelMenu[level+1].Refresh();
    }
}
