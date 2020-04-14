using System;

namespace isp
{
    public interface ILead
    {
        void CreateTask();
        void AssignTask();
        void CompleteTask();
    }

    public class TeamLeader : ILead
    {
        public void CreateTask() => throw new System.NotImplementedException();

        public void AssignTask() => throw new System.NotImplementedException();

        public void CompleteTask() => throw new System.NotImplementedException();
    }

    public class ProjectManager : ILead
    {
        public void CreateTask() => throw new System.NotImplementedException();

        public void AssignTask() => throw new System.NotImplementedException();

        // Manager can't complete tasks as they don't work on them
        public void CompleteTask() => throw new InvalidOperationException();
    }
}