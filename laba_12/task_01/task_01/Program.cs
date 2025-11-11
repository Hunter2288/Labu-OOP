namespace task_01
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    public class NameChangeEventArgs : EventArgs
    {
        public string NewName { get; private set; }
        public NameChangeEventArgs(string newName)
        {
            NewName = newName;
        }
    }
    internal class Program
    {
        class Dispatcher
        {
            private string name;

            public string Name
            {
                get => name;
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnNameChange(new NameChangeEventArgs(name));
                    }
                }
            }

            public event NameChangeEventHandler NameChange;

            public Dispatcher(string initialName = "")
            {
                name = initialName;
            }

            public void OnNameChange(NameChangeEventArgs args)
            {
                NameChange.Invoke(this, args);
            }
        }

        class Handler
        {
            public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
            {
                Console.WriteLine($"Dispatcher's name changed to {args.NewName}.");
            }
        }

        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    dispatcher.Name = input;
                }
            }
        }
    }
}
