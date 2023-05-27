namespace task6_lib_csharp
{
    internal abstract class Surgeon : IDoctor
    {
        public string Name { get; set; }
        public string Education { get; set; }
        public int SuccessfulOperations { get; set; }

        public Surgeon(string name, string education, int successfulOperations)
        {
            Name = name;
            Education = education;
            SuccessfulOperations = successfulOperations;
        }

        public abstract void Examine(string patientName);
        public abstract void Treat(string patientName);
        public abstract void Operate(string patientName);

        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                                  select $"{prop.Name} = {prop.GetValue(this)}";
            return GetType().Name + ":\n    " + string.Join("\n    ", propertyStrings) + "\n";
        }
    }
}
