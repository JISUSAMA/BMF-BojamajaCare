using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame_UIManager : MonoBehaviour
{
    public GameObject ChooseGamePanel_ob; 
    public GameObject TouchGamePanel_ob;

    private void Start()
    {
        //터치게임을 하고 돌아왔을 경우, 
        if(GameAppManager.instance.play_touchGame == true)
        {
            TouchGamePanel_ob.SetActive(true);
        }
        else
        {
            TouchGamePanel_ob.SetActive(false);
        }
        AppSoundManager.Instance.MainBGM_Sound();
    }
    public void OnClick_KinectGame()
    {
        GameAppManager.instance.play_touchGame = false;
        SceneManager.LoadScene("8.ExerciseChoice");
    }

    //뇌 훈련 게임 버튼 클릭
    public void OnClick_BrainGame()
    {
        GameAppManager.instance.play_touchGame = true;
        GameAppManager.instance.Initialization();
        GameAppManager.instance.GameKind = "Brain";
        while (GameAppManager.instance.QuestionStringList.Count < GameAppManager.instance.Brain_QusetionCount)
        {
            int rand_input = UnityEngine.Random.Range(0, GameAppManager.instance.Brain_QusetionCount);
            if (GameAppManager.instance.QuestionStringList.Count != 0)
            {
                if (!GameAppManager.instance.QuestionStringList.Contains(GameAppManager.instance.Brain_gameName[rand_input]))
                {
                    GameAppManager.instance.rand_GameNumber.Add(rand_input);
                    GameAppManager.instance.QuestionStringList.Add(GameAppManager.instance.Brain_gameName[rand_input]);

                }
            }
            else
            {
                GameAppManager.instance.rand_GameNumber.Add(rand_input);
                GameAppManager.instance.QuestionStringList.Add(GameAppManager.instance.Brain_gameName[rand_input]);
            }
        }
        GameAppManager.instance.GameLoadScene();
    }
    //치매 예방 게임 버튼 클릭
    public void OnClick_Dementia()
    {
        GameAppManager.instance.play_touchGame = true;
        GameAppManager.instance.Initialization();
        GameAppManager.instance.GameKind = "Dementia";
        while (GameAppManager.instance.QuestionStringList.Count < GameAppManager.instance.Dementia_QusetionCount)
        {
            int rand_input = UnityEngine.Random.Range(0, GameAppManager.instance.Dementia_QusetionCount);
            if (GameAppManager.instance.QuestionStringList.Count != 0)
            {
                if (!GameAppManager.instance.QuestionStringList.Contains(GameAppManager.instance.Dementia_gameName[rand_input]))
                {
                    GameAppManager.instance.rand_GameNumber.Add(rand_input);
                    GameAppManager.instance.QuestionStringList.Add(GameAppManager.instance.Dementia_gameName[rand_input]);
                }
            }
            else
            {
                GameAppManager.instance.rand_GameNumber.Add(rand_input);
                GameAppManager.instance.QuestionStringList.Add(GameAppManager.instance.Dementia_gameName[rand_input]);
            }
        }
        GameAppManager.instance.GameLoadScene();
    }
    //손동작 게임 버튼 클릭
    public void OnClick_LeapMotion()
    {
        GameAppManager.instance.play_touchGame = false;
        GameAppManager.instance.Initialization();
        GameAppManager.instance.GameKind = "Real";
        while (GameAppManager.instance.LeapMotion_PlayList.Count < GameAppManager.instance.LeapMotion_SceneName.Length)
        {
            int random = UnityEngine.Random.Range(0, GameAppManager.instance.LeapMotion_SceneName.Length);
            Debug.Log(GameAppManager.instance.LeapMotion_SceneName[random]);
            if (GameAppManager.instance.LeapMotion_PlayList.Count != 0)
            {
                if (!GameAppManager.instance.LeapMotion_PlayList.Contains(GameAppManager.instance.LeapMotion_SceneName[random]))
                {
                   GameAppManager.instance.LeapMotion_PlayList.Add(GameAppManager.instance.LeapMotion_SceneName[random]);
                    GameAppManager.instance.LeapMotion_PlayNumList.Add(random);
                }
            }
            else
            {
                GameAppManager.instance.LeapMotion_PlayList.Add(GameAppManager.instance.LeapMotion_SceneName[random]);
                GameAppManager.instance.LeapMotion_PlayNumList.Add(random);
            }
        }
        GameAppManager.instance.GameLoadScene();
    }

    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnClick_BackButton()
    {
        //게스트가 아닌경우, 데이터 저장!
        if (PlayerPrefs.GetString("CARE_PlayMode") != "GuestMode")
        {
            SceneManager.LoadScene("5.UserExercise");
        }
        else
        {
            SceneManager.LoadScene("0.Main");
        }

    }
}
