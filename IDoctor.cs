namespace task6_csharp
{
    internal interface IDoctor
    {
        public string Name { get; protected set; }

        public void Examine(String patientName);
        public void Treat(String patientName);
    }
}
