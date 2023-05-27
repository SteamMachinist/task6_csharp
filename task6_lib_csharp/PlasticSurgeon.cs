namespace task6_lib_csharp
{
    internal class PlasticSurgeon : Surgeon
    {
        double OperationCost { get; set; }
        public PlasticSurgeon(string name, string education, int successfulOperations, double operationCost) 
            : base(name, education, successfulOperations)
        {
            OperationCost = operationCost;
        }

        public override void Examine(string patientName)
        {
            Console.WriteLine("Plastic surgeon " + Name + " examining patient " + patientName + "\n");
        }

        public override void Treat(string patientName)
        {
            Console.WriteLine("Plastic surgeon does not treat anything\n");
        }

        public override void Operate(string patientName)
        {
            Console.WriteLine("Plastic Surgeon " + Name + " operating patient " + patientName + "\n");
            SuccessfulOperations++;
        }

        public void performPlasticSurgery(string patientName, string bodypart)
        {
            Console.WriteLine("Plastic Surgeon " + Name + " made " + bodypart + " of patient " + patientName 
                + " more beautiful, which costed him " + OperationCost.ToString() + "\n");
        }
    }
}
