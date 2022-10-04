using System;
using System.Reflection;

namespace Assignment1
{
     
    class Program{

        
        static void Main(string[] args){ 
            var classMembers = new List<ClassMember>(); 
            var getAllMale = new List<ClassMember>();
            var membersBornBefore2000 = new List<ClassMember>();
            var membersBornIn2000 = new List<ClassMember>();
            var membersBornAfter2000 = new List<ClassMember>();
            var nameList = new List<string>();
            var firstOneBornInHanoi = new ClassMember();
            var oldestOne = new ClassMember();
 
            classMembers.Add(new ClassMember("truong", "trinh", EnumGender.MALE,new DateTime(2000,3,23), "0969696969", "Ha Loi Vietnam", true));
            classMembers.Add(new ClassMember("alonso", "fonso", EnumGender.FEMALE,new DateTime(2000,8,3), "0969698969", "Ha 1oi Viet nam", true));
            classMembers.Add(new ClassMember("chau bac", "ho", EnumGender.MALE,new DateTime(1999,5,13), "0969697969", "Quang Dong Trung Quoc", true));
            classMembers.Add(new ClassMember("ALO ALO", "1234", EnumGender.FEMALE,new DateTime(1999,5,13), "0962327969", "Quang Dong Trung Hoa", true));
            classMembers.Add(new ClassMember("ALO 1234", "1234", EnumGender.FEMALE,new DateTime(2001,5,13), "093422327969", "Ha 1oi dong Hoa", true));
            classMembers.Add(new ClassMember("alonso", "fonso2", EnumGender.MALE,new DateTime(1998,8,3), "0969698969", "Ha Noi Vim", true));
            
            bool inLoop = true;
            while(inLoop)
            {
            Console.WriteLine("Enter a key: 1 2 3 4 5. Press X to end:");
            var key = Console.ReadLine();
            if(key!=null)
            switch(key.ToString().Trim().ToLower()){
                case("1"):
                {
                // first task
                    Console.WriteLine("First Task:");
                    getAllMale = Methods.getAllMaleMembers(classMembers);
                    foreach(ClassMember member in getAllMale)
                    Console.WriteLine(member.GetInfo());
                    break;
                }
                case("2"):
                {
                // second task 
                    Console.WriteLine("Second Task:");
                    oldestOne = Methods.FindOldestOne(classMembers);
                    Console.WriteLine(oldestOne.GetInfo());
                    break;
                }
                case("3"):
                {
                // third task
                    Console.WriteLine("Third Task:");
                    foreach(ClassMember member in classMembers){
                        nameList.Add(member.FullName());
                    }
                    foreach(string member in nameList)
                        Console.WriteLine(member);
                    
                    break;
                }

                case("4"):
                {
                // forth task
                    Console.WriteLine("Forth Task:");
                    foreach(ClassMember member in classMembers){
                        switch(member.DateOfBirth.Year){
                        case (>2000):
                        membersBornAfter2000.Add(member);
                        break;
                        case (2000):
                        membersBornIn2000.Add(member);
                        break;
                        case (<2000):
                        membersBornBefore2000.Add(member);
                        break;
                        }
                    }
                
                    Console.WriteLine("Members born after 2000:");
                    foreach(ClassMember member in membersBornAfter2000)
                        Console.WriteLine(member.GetInfo());
                    Console.WriteLine("Members born in 2000:");
                    foreach(ClassMember member in membersBornIn2000)
                        Console.WriteLine(member.GetInfo());
                    Console.WriteLine("Members born before 2000:");
                    foreach(ClassMember member in membersBornBefore2000)
                        Console.WriteLine(member.GetInfo());

                    break;
                }

                case("5"):
                {
                //fifth task
                    Console.WriteLine("Fifth Task:");
                    firstOneBornInHanoi = Methods.FindFirstOneBornInHanoi(classMembers);
                    Console.WriteLine(firstOneBornInHanoi.GetInfo());
                    break;
                }
                case("x"):
                {
                    inLoop = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid input!");
                    break;
                }
            }
            else 
                Console.WriteLine("Invalid input!");
            }

        }
    }
}
