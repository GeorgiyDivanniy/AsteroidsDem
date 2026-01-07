namespace Models
{
    public class ScoreSystem
    {
        public int Score { get; private set; }

        public void Add(int value)
        {
            Score += value;
        }
    }
}