namespace task_04
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
            public int HitsRemaining { get; private set; } = 3;
            public event Action<RoyalGuard> Died;
            public RoyalGuard(string name, King king)
            {
                Name = name;
                king.UnderAttackEvent += Respond;
            }
            public void Respond()
            {
                Console.WriteLine($"Royal Guard {Name} is defending!");
            }
            public void TakeHit(King king)
            {
                HitsRemaining--;
                if (HitsRemaining <= 0)
                {
                    Died?.Invoke(this);
                    king.UnderAttackEvent -= Respond;
                }
            }
        }
        class Lackey
        {
            public string Name { get; set; }
            public int HitsRemaining { get; private set; } = 2;
            public event Action<Lackey> Died;
            public Lackey(string name, King king)
            {
                Name = name;
                king.UnderAttackEvent += Respond;
            }
            public void Respond()
            {
                Console.WriteLine($"Lackey {Name} is panicking!");
            }
            public void TakeHit(King king)
            {
                HitsRemaining--;
                if (HitsRemaining <= 0)
                {
                    Died?.Invoke(this);
                    king.UnderAttackEvent -= Respond;
                }
            }
        }
        static void Main(string[] args)
        {
            string NameKing = Console.ReadLine()!;
            King king = new King(NameKing);
            string[] royalguard = Console.ReadLine()!.Split(' ');
            List<RoyalGuard> r = new List<RoyalGuard>();
            foreach (var guard in royalguard)
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

                if (input == "Attack King")
                {
                    king.UnderAttack();
                }
                string[] arr = input.Split(' ');
                if (arr[0] == "Kill")
                {

                    var lakeyToHit = l.FirstOrDefault(x => x.Name == arr[1]);
                    if (lakeyToHit != null)
                        lakeyToHit.TakeHit(king);

                    var guardToHit = r.FirstOrDefault(x => x.Name == arr[1]);
                    if (guardToHit != null)
                        guardToHit.TakeHit(king);

                    l.RemoveAll(x => x.HitsRemaining <= 0);
                    r.RemoveAll(x => x.HitsRemaining <= 0);
                }
            }
        }
    }
}
