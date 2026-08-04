using TMPro;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    public TMP_Text missionTitle;

    public TMP_Text task1;

    public TMP_Text task2;

    public void SetMission(string title, MissionTask firstTask, MissionTask secondTask)
    {
        missionTitle.text = title;

        UpdateTask(task1, firstTask);

        UpdateTask(task2, secondTask);
    }

    public void UpdateTask(TMP_Text textObject, MissionTask task)
    {
        if(task.completed)
        {
            textObject.text = "☑ " + task.taskName;
            textObject.color = Color.gray;
        }
        else
        {
            textObject.text = "☐ " + task.taskName;
            textObject.color = Color.white;
        }
    }
}