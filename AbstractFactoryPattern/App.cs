namespace AbstractFactoryPattern
{
    internal class App
    {
        private readonly Factory.IAbstractFactory _abstractFactory;
        public App(Factory.IAbstractFactory abstractFactory)
        {
            _abstractFactory = abstractFactory;
        }
        public void Run()
        {
            var chairTypeList = new List<Type>
            {
                typeof(Features.ModernChairFurniture),
                typeof(Features.VintageChairFurniture),
            };
            var tableTypeList = new List<Type>
            {
                typeof(Features.ModernTableFurniture),
                typeof(Features.VintageTableFurniture)
            };

            var randomChairTypeIndex = new Random().Next(chairTypeList.Count);
            var randomTableTypeIndex = new Random().Next(tableTypeList.Count);
            var chair = _abstractFactory.CreateChair(chairTypeList[randomChairTypeIndex]);
            var table = _abstractFactory.CreateTable(tableTypeList[randomTableTypeIndex]);
            Console.WriteLine(chair.DisplayMessage());
            Console.WriteLine(table.DisplayMessage());
        }
    }
}
