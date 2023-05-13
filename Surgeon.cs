namespace task6_csharp
{
    internal abstract class Surgeon : IDoctor
    {
        public string Name { get; set; }
        public string Education { get; protected set; }
        public int SuccessfulOperations { get; protected set; }

        protected Surgeon(string name, string education, int successfulOperations)
        {
            Name = name;
            Education = education;
            SuccessfulOperations = successfulOperations;
        }

        public abstract void Examine(string patientName);
        public abstract void Treat(string patientName);
        public abstract void Operate(string patientName);
    }
}
