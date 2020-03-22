namespace Command
{
    public interface ICommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}