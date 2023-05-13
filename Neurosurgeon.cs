namespace task6_csharp
{
    enum DiagnosisMethod
    {
        None, CT, MRI, PET
    }

    internal class Neurosurgeon : Surgeon
    {
        public DiagnosisMethod diagnosisMethod { get; set; }
        public bool isRoboticAssisted { get; set; }
        
        public Neurosurgeon(string name, string education, int successfulOperations, 
            DiagnosisMethod diagnosisMethod, bool isRoboticAssisted) : base(name, education, successfulOperations)
        {
            this.diagnosisMethod = diagnosisMethod;
            this.isRoboticAssisted = isRoboticAssisted;
        }

        public override void Examine(string patientName)
        {
            Console.WriteLine("Neurosurgeon " + Name +  " examined patient " + patientName + " using " + diagnosisMethod.ToString() + "\n");
        }

        public override void Operate(string patientName)
        {
            string details = (isRoboticAssisted ? " " : " without ") + "using robotic arm assistance";
            Console.WriteLine("    Neurosurgeon " + Name + " operating patient " + patientName + details + "\n");
            SuccessfulOperations++;
        }

        public override void Treat(string patientName)
        {
            Console.WriteLine("Neurosurgeon " + Name + " treating patient " + patientName + ":");
            Operate(patientName);
        }

        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                                  select $"{prop.Name} = {prop.GetValue(this)}";
            return "Neurosurgeon:\n    " + string.Join("\n    ", propertyStrings) + "\n";
        }
    }
}
