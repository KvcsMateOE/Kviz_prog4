namespace Kviz_prog4
{
    public class Question
    {
        private string sorszam;
        private string kerdes;
        private string valasz1;
        private string valasz2;
        private string valasz3;
        private string valasz4;
        private string megoldas;
        bool correct;


        public Question(string sorszam, string kerdes, string valasz1, string valasz2, string valasz3, string valasz4, string megoldas)
        {
            this.sorszam = sorszam;
            this.kerdes = kerdes;
            this.valasz1 = valasz1;
            this.valasz2 = valasz2;
            this.valasz3 = valasz3;
            this.valasz4 = valasz4;
            this.megoldas = megoldas;
        }

        public string Sorszam { get => sorszam; set => sorszam = value; }
        public string Kerdes { get => kerdes; set => kerdes = value; }
        public string Valasz1 { get => valasz1; set => valasz1 = value; }
        public string Valasz2 { get => valasz2; set => valasz2 = value; }
        public string Valasz3 { get => valasz3; set => valasz3 = value; }
        public string Valasz4 { get => valasz4; set => valasz4 = value; }
        public string Megoldas { get => megoldas; set => megoldas = value; }
        public bool? Correct { get; set; }
    }
}