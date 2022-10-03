using System;
using System.Reflection;

namespace Assignmnet1
{
    
    enum enumGender{
        MALE,
        FEMALE,
        OTHERS,
    };
     
    class ClassMember{
        public ClassMember(){}
        public ClassMember(string FirstNameA, string lastNameA,enumGender genderA, DateTime dateOfBirthA, string phoneNumberA, string birthPlaceA, bool isGraduatedA){
            // "A" suffix is short for argument
            firstName = FirstNameA.Trim();
            lastName = lastNameA.Trim();
            gender = genderA;
            dateOfBirth = dateOfBirthA;
            phoneNumber = phoneNumberA;
            birthPlace = birthPlaceA;
            age = getCurrentAge();
            isGraduated = isGraduatedA;
        }
        public string firstName;
        public string lastName;
        public enumGender gender;
        public DateTime dateOfBirth; 
        public string phoneNumber;
        public string birthPlace;
        public int age;
        public bool? isGraduated;
        public string FullName() { return lastName + " " + firstName; }
        public string GetInfo() { return lastName + " " + firstName + " | " + age + " | " + 
        (gender == enumGender.MALE?"MALE":gender == enumGender.FEMALE?"FEMALE":gender == enumGender.OTHERS?"OTHERS":"") 
        + " | " + dateOfBirth.ToString("dd/MM/yyyy") + " | " + phoneNumber + " | " + birthPlace 
        + " | " + (isGraduated == true?"Graduated":"Not Graduated") ; }

        public int getCurrentAge(){
                
            return (DateTime.Now.Year - dateOfBirth.Year) +
                (DateTime.Now.Month < dateOfBirth.Month ?(-1) // if member's birth month is larger than current month then -1
                    :(DateTime.Now.Day < dateOfBirth.Day)?(-1):0); // if member's birth day is larger than current day then -1
        }
    }	
    class Program{

        // Find all male members method
        static public List<ClassMember> getAllMaleMembers(List<ClassMember> classMembers){
            var maleMemberList = new List<ClassMember>();
            if(classMembers.Count() >0)
            foreach(var member in classMembers){
                if(member.gender == enumGender.MALE)
                maleMemberList.Add(member);
            }
        return maleMemberList;
        }
        static ClassMember FindOldestOne(List<ClassMember> classMembers){
                if(classMembers.Count() >0){
                    int index = 0; 
                    for(int i = 0; i < classMembers.Count();i++)
                    if(DateTime.Compare(classMembers[index].dateOfBirth,classMembers[i].dateOfBirth) > 0 ){
                        index = i;
                    }
                    return classMembers[index];
                }
                    return new ClassMember();
        }
        static ClassMember FindOldestOneBornInHanoi(List<ClassMember> classMembers){
                if(classMembers.Count() >0){
                    int index = -1;
                    int i =0;
                    int j =classMembers.Count() -1;
                    while(true){
                        bool validPair = true;
                        if(!classMembers[i].birthPlace.ToLower().Contains("ha noi")){
                            i++;
                            validPair = false;
                        }
                        else {if(index == -1) index = i;}
                        if(!classMembers[j].birthPlace.ToLower().Contains("ha noi")){
                            j--;
                            validPair = false;
                        }
                        else {if(index == -1) index = j;}
                        if(validPair){
                            if(DateTime.Compare(classMembers[i].dateOfBirth,classMembers[j].dateOfBirth) > 0 ){
                                index = j;
                                i++;
                            }   
                            else{
                                index = i;
                                j--;
                            }   
                        }
                        if(i>j)
                            break;
                    }
                    if(index != -1)
                    return classMembers[index];
                }
                    return new ClassMember();
        }
        static ClassMember FindFirstOneBornInHanoi(List<ClassMember> classMembers)
        {
            if (classMembers.Count() > 0)
                foreach(ClassMember member in classMembers)
                    if (member.birthPlace.ToLower().Contains("ha noi"))
                    {
                        return member;
                    }  
            return new ClassMember();
        }
        static void Main(string[] args){ 
            var classMembers = new List<ClassMember>(); 

            var getAllMale = new List<ClassMember>();

            var membersBornBefore2000 = new List<ClassMember>();
            var membersBornIn2000 = new List<ClassMember>();
            var membersBornAfter2000 = new List<ClassMember>();

            var nameList = new List<string>();

            var firstOneBornInHanoi = new ClassMember();
            var oldestOne = new ClassMember();

            // classMembers.Add(new classMember("truong", "trinh", enumGender.MALE,new DateTime(2000,3,23), "0969696969", "Ha Loi Vietnam", true));
            // classMembers.Add(new classMember("alonso", "fonso", enumGender.FEMALE,new DateTime(2000,8,3), "0969698969", "Ha Noi Viet nam", true));
            // classMembers.Add(new classMember("chau bac", "ho", enumGender.MALE,new DateTime(1999,5,13), "0969697969", "Quang Dong Trung Quoc", true));
            // classMembers.Add(new classMember("ALO ALO", "1234", enumGender.FEMALE,new DateTime(1999,5,13), "0962327969", "Quang Dong Trung Hoa", true));
            // classMembers.Add(new classMember("ALO 1234", "1234", enumGender.FEMALE,new DateTime(2001,5,13), "093422327969", "Ha Noi dong Hoa", true));
            // classMembers.Add(new classMember("alonso", "fonso2", enumGender.MALE,new DateTime(1998,8,3), "0969698969", "Ha Noi Vim", true));

            classMembers.Add(new ClassMember("truong", "trinh", enumGender.MALE,new DateTime(2000,3,23), "0969696969", "Ha Loi Vietnam", true));
            classMembers.Add(new ClassMember("alonso", "fonso", enumGender.FEMALE,new DateTime(2000,8,3), "0969698969", "Ha 1oi Viet nam", true));
            classMembers.Add(new ClassMember("chau bac", "ho", enumGender.MALE,new DateTime(1999,5,13), "0969697969", "Quang Dong Trung Quoc", true));
            classMembers.Add(new ClassMember("ALO ALO", "1234", enumGender.FEMALE,new DateTime(1999,5,13), "0962327969", "Quang Dong Trung Hoa", true));
            classMembers.Add(new ClassMember("ALO 1234", "1234", enumGender.FEMALE,new DateTime(2001,5,13), "093422327969", "Ha 1oi dong Hoa", true));
            classMembers.Add(new ClassMember("alonso", "fonso2", enumGender.MALE,new DateTime(1998,8,3), "0969698969", "Ha Noi Vim", true));
            // first task
            
            bool inLoop = true;
            while(inLoop)
            {
            Console.WriteLine("Enter a key: 1 2 3 4 5. Press X to end:");
            var key = Console.ReadLine();
            switch(key.ToString().Trim()){
                case("1"):
                {
                Console.WriteLine("First Task:");
                getAllMale = getAllMaleMembers(classMembers);
                foreach(ClassMember member in getAllMale)
                Console.WriteLine(member.GetInfo());
                break;
                }
                case("2"):
                {
                // second task 
                Console.WriteLine("Second Task:");
                oldestOne = FindOldestOne(classMembers);
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
                    switch(member.dateOfBirth.Year){
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
                firstOneBornInHanoi = FindFirstOneBornInHanoi(classMembers);
                Console.WriteLine(firstOneBornInHanoi.GetInfo());

                break;
                }
                case("X"):
                {
                    inLoop = false;
                    break;
                }
                default:
                {
                Console.WriteLine("Invalid input!");
                break;
                }


            }}


            // int i = 0;
            // if(classMembers.Count()>0)
            // while(true){
            //     if(classMembers[1].birthPlace.ToLower().Contains("ha noi")){
            //     firstOneBornInHanoi = classMembers[1];
            //     break;
            //     }
            //     i++;
            //     if(classMembers.Count() == i)
            //     break;
            // }

             

        }
    }
}
