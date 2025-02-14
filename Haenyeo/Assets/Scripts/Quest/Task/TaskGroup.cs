using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum TaskGroupState
{
    Inactive,
    Running,
    Complete
}

[System.Serializable]
public class TaskGroup
{
    [SerializeField]
    Task[] tasks;

    public IReadOnlyList<Task> Tasks => tasks;

    public Quest_ Owner { get; set; }
    public bool IsAllTaskComplete => tasks.All(x => x.IsComplete);
    public bool IsComplete => State == TaskGroupState.Complete;

    public TaskGroupState State { get; set; }

    public TaskGroup(TaskGroup copyTarget)
    {
        tasks = copyTarget.Tasks.Select(x => Object.Instantiate(x)).ToArray();
    }

    public void SetUp(Quest_ owner)
    {
        Owner = owner;
        foreach (var task in tasks)
            task.Setup(owner);
    }

    public void Start()
    {
        State = TaskGroupState.Running;
        foreach (var task in tasks)
            task.Start();
    }

    public void End()
    {
        foreach (var task in tasks)
            task.End();
    }

    public void ReceiveReport(string category, object target, int successCount)
    {
        foreach( var task in tasks)
        {
            if (task.IsTarget(category, target))
                task.ReceiveReport(successCount);
        }
    }

    public void Complete()
    {
        if (IsComplete)
            return;

        State = TaskGroupState.Complete;

        foreach( var task in tasks)
        {
            if (!task.IsComplete)
                task.Complete();
        }
    }
}
