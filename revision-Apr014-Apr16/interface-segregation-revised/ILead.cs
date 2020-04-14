namespace interface_segregation_revised
{
    public interface ILead
    {
        void CreateTask();
        void AssignTask();
    }

    public interface IWorker
    {
        void CompleteTask();
    }

    public class Programmer : IWorker
    {
        public void CompleteTask()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Manager : ILead
    {
        public void CreateTask()
        {
            throw new System.NotImplementedException();
        }

        public void AssignTask()
        {
            throw new System.NotImplementedException();
        }
    }
}