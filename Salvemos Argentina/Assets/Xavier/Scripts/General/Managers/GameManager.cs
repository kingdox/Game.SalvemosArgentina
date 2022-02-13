#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using XavHelpTo;
using XavHelpTo.Change;
using XavHelpTo.Set;
using XavHelpTo.Get;
# endregion

public class GameManager : MonoBehaviour
{
    private enum GameScenes
    {
        MENU=0,
        INTRO=1,
        GAME=2,
        END=3
    }
    [SerializeField]
    private enum Status
    {
        GAME=0,
        PAUSE=1,
        END=2
    }
    #region Variables

    [Header("Requirements")]
    [Space]
    [SerializeField] private ValueController<Transform> ctrl_parent_items;
    [SerializeField] private ValueController<GoalEntity> ctrl_goal_left;
    [SerializeField] private ValueController<GoalEntity> ctrl_goal_right;


    [Header("Settings")]
    [SerializeField] private ValueController<Status> ctrl_status;
    [SerializeField] private Vector2Int goals;
    [SerializeField] private int maxGoals;


    [Header("Item Generator")]
    [SerializeField] private GeneratorController<ItemEntity> ctrl_generator_item;
    [SerializeField] private TimerController ctrl_time_item;

    [Header("Ball")]
    [SerializeField] private ValueController<BallEntity> ctrl_ball;
    [SerializeField] private ValueController<Transform> ctrl_center_ballpoint;


    [Header("HUD")]
    [Space]
    [SerializeField] private ValueController<Text> ctrl_text_goal_left;
    [SerializeField] private ValueController<Text> ctrl_text_goal_right;
    [SerializeField] private ValueController<GameObject> ctrl_HUD;
    [SerializeField] private ValueController<GameObject> ctrl_PAUSE;
    [SerializeField] private ValueController<GameObject> ctrl_END;


    private bool ExistAWinner => PlayerWins || goals[1].Equals(maxGoals);
    private bool PlayerWins => goals[0].Equals(maxGoals);

    #endregion
    #region Events
    private void Awake()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

    }
    private void Start()
    {
        ctrl_goal_right.Value.OnEnterGoal += CheckGameConditions;
        ctrl_goal_left.Value.OnEnterGoal += CheckGameConditions;
    }
    private void Update()
    {
        switch (ctrl_status.Value)
        {
            case Status.GAME:
                GameUpdate();
                break;
            case Status.PAUSE:
                break;
            case Status.END:
                break;
        }
    }
    #endregion
    #region Methods
    private void GameUpdate(){
        // Generate Items
        if (ctrl_time_item.Timer())
        {
            ItemEntity item = ctrl_generator_item.Generate();
            item.transform.SetParent(ctrl_parent_items.Value);

        }
    }
    private void CheckGameConditions(bool isPlayerGoal){
        goals[isPlayerGoal.ToInt()]++;
        ctrl_text_goal_left.Value.text = goals[0].ToString();
        ctrl_text_goal_right.Value.text = goals[1].ToString();
        
        if (ExistAWinner)
        {
            "WINNER".Print("red");
            if (PlayerWins) GoToEnd();
            else GameOver();
        }
        else
        {
            ctrl_ball.Value.transform.position = ctrl_center_ballpoint.Value.position;
            ctrl_ball.Value.transform.rotation = ctrl_center_ballpoint.Value.rotation;
            ctrl_ball.Value.ResetForce();
        }
    }

    public void Resume()
    {
        ctrl_PAUSE.Value.SetActive(false);
        ctrl_HUD.Value.SetActive(true);
        ctrl_END.Value.SetActive(false);
        ctrl_status.Value = Status.GAME;
        Cursor.visible = false;
        Time.timeScale = 1;

    }
    public void Pause()
    {
        ctrl_PAUSE.Value.SetActive(true);
        ctrl_HUD.Value.SetActive(false);
        ctrl_END.Value.SetActive(false);
        ctrl_status.Value = Status.PAUSE;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    private void GameOver()
    {
        ctrl_PAUSE.Value.SetActive(false);
        ctrl_HUD.Value.SetActive(false);
        ctrl_END.Value.SetActive(true);
        ctrl_status.Value = Status.END;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void GoToMenu() => SceneManager.LoadScene(GameScenes.MENU.ToInt());
    public void ResetGame() => SceneManager.LoadScene(GameScenes.GAME.ToInt());
    public void GoToEnd() => SceneManager.LoadScene(GameScenes.END.ToInt());
    #endregion
}
