using Mosha.StatePattern.Test.Models.Models;
using Mosha.StatePattern.Test.Models.States;
using Mosha.StatePattern.Test.Unit.Db;

namespace Mosha.StatePattern.Test.Unit;

public class TestPersonStateWithDb
{
    private TestDbContext _Db;

    [SetUp]
    public void CreateDb()
    {
        _Db = new TestDbContext();
        _Db.Database.EnsureDeleted();
        _Db.Database.EnsureCreated();

        var person = new Person(DateOnly.FromDateTime(DateTime.Now.AddYears(-14)), "moein", "hi i moein", PersonEducationEnum.NotYetGoToSchool);
        _Db.Add(person);
        _Db.SaveChanges();
    }


    [Test]
    public void NotYetGoToSchoolStateTest()
    {
        var person = _Db.Persons.First();

        try
        {
            if (person.State != PersonEducationEnum.NotYetGoToSchool) throw new Exception();

            person.GoToSchool();
            _Db.SaveChanges();
        }
        catch (Exception)
        {
            Assert.Fail();
        }

        person = _Db.Persons.First();
        if (person.State != PersonEducationEnum.GoToSchool) Assert.Fail();
    }


    [Test]
    public void GoToUniStateFailTest()
    {
        try
        {
            NotYetGoToSchoolStateTest();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }

        var person = _Db.Persons.First();

        try
        {
            person.GoToUniversity();
            _Db.SaveChanges();
            Assert.Fail();
        }
        catch (Exception)
        {

        }

        person = _Db.Persons.First();
        if (person.State != PersonEducationEnum.GoToSchool) Assert.Fail();
        Assert.Pass();
    }

    [Test]
    public void GoToSchoolStateFailTest()
    {
        try
        {
            NotYetGoToSchoolStateTest();
        }
        catch (Exception)
        {
            Assert.Pass();
        }

        var person = _Db.Persons.First();
        person.SetBirthDate(DateOnly.FromDateTime(DateTime.Now.AddYears(-12)));

        try
        {
            person.EndSchool();
            _Db.SaveChanges();
            Assert.Fail();
        }
        catch (Exception)
        {
        }

        person = _Db.Persons.First();
        if (person.State != PersonEducationEnum.GoToSchool) Assert.Fail();
    }

    [Test]
    public void GoToSchoolStateSuccessTest()
    {
        try
        {
            NotYetGoToSchoolStateTest();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }

        var person = _Db.Persons.First();

        try
        {
            person.EndSchool();
            _Db.SaveChanges();
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }

        person = _Db.Persons.First();
        if (person.State != PersonEducationEnum.EndSchool) Assert.Fail();
    }
}