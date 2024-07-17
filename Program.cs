namespace task_ado_2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var carsDB = new CarsDB();
            carsDB.AddCar(new Car() { Mark = "BMW", Model = "M5" });
            carsDB.AddCar(new Car() { Mark = "BMW", Model = "M3" });
            carsDB.AddCar(new Car() { Mark = "BMW", Model = "i8" });
            carsDB.AddCar(new Car() { Mark = "BMW", Model = "M4" });
            carsDB.AddCar(new Car() { Mark = "Mercedes", Model = "Benz" });
            carsDB.AddCar(new Car() { Mark = "Mercedes", Model = "AMG" });
            carsDB.AddCar(new Car() { Mark = "Mercedes", Model = "Maybach" });
            carsDB.AddCar(new Car() { Mark = "Lamborghini", Model = "Urus" });
            carsDB.AddCar(new Car() { Mark = "Lamborghini", Model = "Aventador" });
            carsDB.AddCar(new Car() { Mark = "Porche", Model = "Cayenne" });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}