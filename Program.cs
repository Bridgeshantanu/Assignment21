namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer.InsertRecord();
            Customer.RetrieveData();
            Customer.Delete();
            Customer.Update();
            
        }
    }
}
