namespace task6_lib_csharp
{
    internal interface IDoctor
    {
        public string Name { get; set; }

        void Examine(String patientName);
        void Treat(String patientName);
    }
}
