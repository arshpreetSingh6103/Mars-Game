using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public MissionUI ui;

    MissionTask task1;

    MissionTask task2;

    void Start()
    {
        task1 = new MissionTask();
        task1.taskName = "Find Communication Core";
        task1.completed = false;

        task2 = new MissionTask();
        task2.taskName = "Reactivate Tower";
        task2.completed = false;

        ui.SetMission(
            "Repair Communication Tower",
            task1,
            task2);
    }

    public void CompleteTask1()
    {
        task1.completed = true;

        ui.UpdateTask(ui.task1,task1);
    }

    public void CompleteTask2()
    {
        task2.completed = true;

        ui.UpdateTask(ui.task2,task2);
    }
}