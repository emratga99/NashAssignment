using System;

namespace Assignmnet1
{
    
    enum enumGender{
        MALE,
        FEMALE,
        OTHERS,
    };
    class classMember{
        public classMember(){}
        public classMember(string FirstNameA, string lastNameA,enumGender genderA, DateTime dateOfBirthA, string phoneNumberA, string birthPlaceA, bool isGraduatedA){
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

        public int getCurrentAge(){
                
            return (DateTime.Now.Year - dateOfBirth.Year) +
                (DateTime.Now.Month < dateOfBirth.Month ?(-1) // if member's birth month is larger than current month then -1
                    :(DateTime.Now.Day < dateOfBirth.Day)?(-1):0); // if member's birth day is larger than current day then -1
        }
    }	
    class Program{

        // Find all male members method
        static public List<classMember> getAllMaleMembers(List<classMember> classMembers){
            var maleMemberList = new List<classMember>();
            if(classMembers.Count() >0)
            foreach(var member in classMembers){
                if(member.gender == enumGender.MALE)
                maleMemberList.Add(member);
            }
        return maleMemberList;
        }
        static classMember FindOldestOne(List<classMember> classMembers){
                if(classMembers.Count() >0){
                    int index = 0; 
                    for(int i = 0; i < classMembers.Count();i++)
                    if(DateTime.Compare(classMembers[index].dateOfBirth,classMembers[i].dateOfBirth) > 0 ){
                        index = i;
                    }
                    return classMembers[index];
                }
                    return new classMember();
        }
        static classMember FindOldestOneBornInHanoi(List<classMember> classMembers){
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
                        if(i>=j)
                            break;
                    }
                    if(index != -1)
                    return classMembers[index];
                }
                    return new classMember();
        }
        static void Main(string[] args){ 
            var classMembers = new List<classMember>(); 

            var getAllMale = new List<classMember>();

            var membersBornBefore2000 = new List<classMember>();
            var membersBornIn2000 = new List<classMember>();
            var membersBornAfter2000 = new List<classMember>();

            var nameList = new List<string>();

            var firstOneBornInHanoi = new classMember();
            var oldestOne = new classMember();

            // classMembers.Add(new classMember("truong", "trinh", enumGender.MALE,new DateTime(2000,3,23), "0969696969", "Ha Loi Vietnam", true));
            // classMembers.Add(new classMember("alonso", "fonso", enumGender.FEMALE,new DateTime(2000,8,3), "0969698969", "Ha Noi Viet nam", true));
            // classMembers.Add(new classMember("chau bac", "ho", enumGender.MALE,new DateTime(1999,5,13), "0969697969", "Quang Dong Trung Quoc", true));
            // classMembers.Add(new classMember("ALO ALO", "1234", enumGender.FEMALE,new DateTime(1999,5,13), "0962327969", "Quang Dong Trung Hoa", true));
            // classMembers.Add(new classMember("ALO 1234", "1234", enumGender.FEMALE,new DateTime(2001,5,13), "093422327969", "Ha Noi dong Hoa", true));
            // classMembers.Add(new classMember("alonso", "fonso2", enumGender.MALE,new DateTime(1998,8,3), "0969698969", "Ha Noi Vim", true));

            classMembers.Add(new classMember("truong", "trinh", enumGender.MALE,new DateTime(2000,3,23), "0969696969", "Ha Loi Vietnam", true));
            classMembers.Add(new classMember("alonso", "fonso", enumGender.FEMALE,new DateTime(2000,8,3), "0969698969", "Ha 1oi Viet nam", true));
            classMembers.Add(new classMember("chau bac", "ho", enumGender.MALE,new DateTime(1999,5,13), "0969697969", "Quang Dong Trung Quoc", true));
            classMembers.Add(new classMember("ALO ALO", "1234", enumGender.FEMALE,new DateTime(1999,5,13), "0962327969", "Quang Dong Trung Hoa", true));
            classMembers.Add(new classMember("ALO 1234", "1234", enumGender.FEMALE,new DateTime(2001,5,13), "093422327969", "Ha 1oi dong Hoa", true));
            classMembers.Add(new classMember("alonso", "fonso2", enumGender.MALE,new DateTime(1998,8,3), "0969698969", "H1a Noi Vim", true));
            // first task
            getAllMale = getAllMaleMembers(classMembers);
            
            // second task 
            oldestOne = FindOldestOne(classMembers);


            // third task
            foreach(var member in classMembers){
                nameList.Add(member.FullName());
            }
            
            // forth task
            foreach(var member in classMembers){
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

            //fifth task
            firstOneBornInHanoi = FindOldestOneBornInHanoi(classMembers);

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
