namespace task6_lib_csharp
{
    internal class CardiacSurgeon : Surgeon
    {
        public bool AllowedTransplant { get; set; }

        public CardiacSurgeon(string name, string education, int successfulOperations, bool allowedTransplant) 
            : base(name, education, successfulOperations)
        {
            AllowedTransplant = allowedTransplant;
        }

        public override void Examine(string patientName)
        {
            Console.WriteLine("Cardiac Surgeon " + Name + " examining patient " + patientName + "\n");
        }

        public override void Treat(string patientName)
        {
            Console.WriteLine("Cardiac Surgeon " + Name + " treating patient " + patientName + "\n");
            Operate(patientName);
        }

        public override void Operate(string patientName)
        {
            Console.WriteLine("Cardiac Surgeon " + Name + " operating patient " + patientName + "\n");
            SuccessfulOperations++;
        }

        public void TransplantHeart(string patientName, string from)
        {
            if (AllowedTransplant)
            {
                Console.WriteLine("Cardiac Surgeon " + Name + " transplanting heart from " + from + " to " + patientName + "\n");
                SuccessfulOperations++;
            }
            else 
            {
                Console.WriteLine("Cardiac Surgeon " + Name + " is not allowed to perform heart transplantation\n");
            }
        }
    }
}
