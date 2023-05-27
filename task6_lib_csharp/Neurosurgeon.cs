namespace task6_lib_csharp
{
    internal class Neurosurgeon : Surgeon
    {
        public bool IsRoboticAssisted { get; set; }

        public Neurosurgeon(string name, string education, int successfulOperations, bool isRoboticAssisted)
            : base(name, education, successfulOperations)
        {
            this.IsRoboticAssisted = isRoboticAssisted;
        }

        public override void Examine(string patientName)
        {
            Console.WriteLine("Neurosurgeon " + Name + " examining patient " + patientName + "\n");
        }

        public override void Treat(string patientName)
        {
            Console.WriteLine("Neurosurgeon " + Name + " treating patient " + patientName + "\n");
            Operate(patientName);
        }

        public override void Operate(string patientName)
        {
            string details = (IsRoboticAssisted ? " " : " without ") + "using robotic assistance";
            Console.WriteLine("Neurosurgeon " + Name + " operating brain of patient " + patientName + details + "\n");
            SuccessfulOperations++;
        }
    }
}
