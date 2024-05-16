namespace WolfEmails.Extensions
{
    public class ControllQuestions
    {
        public string[] Questions { get; private set; }
        public string[] Answers { get; private set; }

        private Random random;

        public ControllQuestions()
        {
            Questions = new string[] {"Kolik očí má kočka?", "Kolik nohou má kráva?", "Kolik hlav má had?"};
            Answers = new string[] {"dvě", "čtyři", "jednu"};
            random = new Random();
        }

        public int GenerateIndex()
        {
            if(Questions.Length == Answers.Length)
            {
                return random.Next(Questions.Length);
            }else
            {
                return 0;
            }           
            
        }

        public bool CompareInputs(int index, string input)
        {
            if(Questions.Length == Answers.Length && index < Answers.Length)
            {
                return (Answers[index] == input);
            }
            else
            {
                return false;
            }
        }
    }
}
