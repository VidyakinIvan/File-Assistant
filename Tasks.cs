namespace File_Assistant
{
    public abstract class Tasks
    {
        public abstract string? InputString { protected get; set; }
        public abstract Person? InputPerson { get; set; }
        public abstract string? FileName { get; set; }
        public abstract bool CanSolveTask(int num);
        public abstract void SolveTask(int num);
        protected abstract void First();
        protected abstract void Second();
        protected abstract void Third();
        protected abstract void Fourth();
        protected abstract void Fifth();
        protected abstract string FileNameInput(string def);
    }
}