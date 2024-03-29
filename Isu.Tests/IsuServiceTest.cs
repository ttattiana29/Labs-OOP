using Isu.Classes;
using Isu.Service;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group,"Tanya");
            Assert.AreEqual(group, student.Group);
        }
        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = _isuService.AddGroup("M3200");
            for (int i = 1; i <= 24; i++)
            {
                _isuService.AddStudent(group, "Vanya");
            }
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddStudent(group, "Masha");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group group = _isuService.AddGroup("M36010");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group, "Masha");
            Group group2 = _isuService.AddGroup("M3200");
            for (int i = 1; i <= 24; i++)
            {
                _isuService.AddStudent(group2, "Tanya");
            }
            Assert.Catch<IsuException>(() =>
            {
                _isuService.ChangeStudentGroup(student, group2);
            });
        }
    }
}