using static task_02.Program;

namespace task_02
{
    internal class Program
    {
        public delegate void attack();
        class King
        {
            public string Name { get; set; }
            public King(string name)
            {
                Name = name;
            }

            public event attack UnderAttackEvent;
            public void UnderAttack()
            {
                Console.WriteLine($"King {Name} is under attack!");
                UnderAttackEvent?.Invoke();
            }
        }
        class RoyalGuard
        {
            public string Name { get; set; }
            public RoyalGuard(string name, King king)
            {
                Name = name;
                king.UnderAttackEvent += Respond;
            }
            public void Respond()
            {
                Console.WriteLine($"Royal Guard {Name} is defending!");
            }
            public void Die(King king)
            {
                king.UnderAttackEvent -= Respond;
            }
        }
        class Lackey
        {
            public string Name { get; set; }
            public Lackey(string name, King king)
            {
                Name = name;
                king.UnderAttackEvent += Respond;
            }
            public void Respond()
            {
                Console.WriteLine($"Lackey {Name} is panicking!");
            }
            public void Die(King king)
            {
                king.UnderAttackEvent -= Respond;
            }
        }
        static void Main(string[] args)
        {
            string NameKing = Console.ReadLine()!;
            King king = new King(NameKing);
            string[] royalguard = Console.ReadLine()!.Split(' ');
            List<RoyalGuard> r = new List<RoyalGuard>();
            foreach(var guard in royalguard)
            {
                RoyalGuard rr = new RoyalGuard(guard, king);
                r.Add(rr);
            }
            string[] lackey = Console.ReadLine()!.Split(' ');
            List<Lackey> l = new List<Lackey>();
            foreach (var la in lackey)
            {
                Lackey rr = new Lackey(la, king);
                l.Add(rr);
            }
            while (true)
            {
                string input = Console.ReadLine()!;
                if (input == "End")
                    break;

                if(input == "Attack King")
                {
                    king.UnderAttack();
                }
                string[] arr = input.Split(' ');
                if (arr[0] == "Kill")
                {
                    var lakeyToRemove = l.FirstOrDefault(x => x.Name == arr[1]);
                    if (lakeyToRemove != null)
                    {
                        lakeyToRemove.Die(king);
                        l.Remove(lakeyToRemove);
                    }

                    var guardToRemove = r.FirstOrDefault(x => x.Name == arr[1]);
                    if (guardToRemove != null)
                    {
                        guardToRemove.Die(king);
                        r.Remove(guardToRemove);
                    }
                }
            }
        }
    }
}
