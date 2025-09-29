using NameGenerator;

namespace NameGeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 生成并显示5个随机英文名称
            Console.WriteLine("生成5个随机英文名称：");
            for (int i = 0; i < 5; i++)
            {
                string randomName = EnglishNameGenerator.GenerateRandomName();
                Console.WriteLine($"{i + 1}. {randomName}");
            }

            // 等待用户按任意键退出
            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}