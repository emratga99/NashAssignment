using System;
using System.Reflection;
using System.Linq;

namespace Assignment1
{
    // Find all male members method
    static class Methods
    {
        static public List<ClassMember> getAllMaleMembers(List<ClassMember> classMembers)
        {
            var maleMemberList = new List<ClassMember>();
            if (classMembers.Count() > 0)
                foreach (var member in classMembers)
                {
                    if (member.Gender == EnumGender.MALE)
                        maleMemberList.Add(member);
                }
            return maleMemberList;
        }
        static public ClassMember FindOldestOne(List<ClassMember> classMembers)
        {
            if (classMembers.Count() > 0)
            {
                int index = 0;
                for (int i = 0; i < classMembers.Count(); i++)
                {
                    if (DateTime.Compare(classMembers[index].DateOfBirth, classMembers[i].DateOfBirth) > 0)
                    {
                        index = i;
                    }
                }
                return classMembers[index];
            }
            return null;
        }
        static public ClassMember FindFirstOneBornInHanoi(List<ClassMember> classMembers)
        {
            if (classMembers.Count() > 0)
                foreach (ClassMember member in classMembers)
                {
                    if (member.BirthPlace.ToLower().Contains("ha noi"))
                    {
                        return member;
                    }
                }
            return null;
        }
    }
}
